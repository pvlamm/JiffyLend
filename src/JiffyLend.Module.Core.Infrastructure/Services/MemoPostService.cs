namespace JiffyLend.Module.Core.Infrastructure.Services;

using System;
using System.Threading;
using System.Threading.Tasks;

using JiffyLend.Core.Common.Interfaces;
using JiffyLend.Core.Extensions;
using JiffyLend.Module.Core.Application.Common.Interfaces;
using JiffyLend.Module.Core.Domain.Entities;
using JiffyLend.Module.Core.Domain.Enums;

using Microsoft.EntityFrameworkCore;

public class MemoPostService : IMemoPostService
{
    private readonly ICoreDbContext _context;
    private readonly IDateTime _dateTime;
    public MemoPostService(ICoreDbContext context, IDateTime dateTime)
    {
        _context = context;
        _dateTime = dateTime;
    }
    public bool CanClear(Guid id)
    {
        return _context.MemoPosts.Any(x => x.Id == id 
                        && x.CancelDate == null 
                        && x.CompleteDate == null
                        && x.ExpiresAt <= _dateTime.Now );

    }

    public bool CanDelete(Guid id)
    {
        return _context.MemoPosts.Any(x => x.Id == id
                        && x.CancelDate == null
                        && x.CompleteDate == null);
    }

    public async Task Clear(Guid id, CancellationToken token = default)
    {
        var executionDate = _dateTime.Now;

        await _context.MemoPosts
            .Where(x => x.Id == id)
            .ExecuteUpdateAsync(update => update
                .SetProperty(p => p.CompleteDate, executionDate), 
            token);

        var memoPost = await _context.MemoPosts.Select(x => new { x.Id, x.ReferenceNumber, x.Amount, x.AccountId }).SingleAsync(x => x.Id == id, token);

        await _context.AccountActivities.AddAsync(new AccountActivity
        {
            Id = JiffyGuid.NewId(),
            ParentId = memoPost.AccountId,
            DepositType = DepositTypes.Other,
            Amount = memoPost.Amount,
            MemoPostId = memoPost.Id,
            ReferenceNumber = memoPost.ReferenceNumber,
            CreateDate = executionDate,
            UpdateDate = executionDate,
        }, token);

        await _context.SaveChangesAsync(token);

    }

    public async Task<Guid> Create(MemoPost memoPost, CancellationToken token = default)
    {
        await _context.MemoPosts.AddAsync(memoPost, token);
        await _context.SaveChangesAsync(token);

        return memoPost.Id;
    }

    public async Task Delete(Guid id, CancellationToken token = default)
    {
        await _context.MemoPosts
            .Where(x => x.Id == id)
            .ExecuteUpdateAsync(update => update
                .SetProperty(p => p.CancelDate, _dateTime.Now),
            token);

        await _context.SaveChangesAsync(token);
    }

    public bool Exists(Guid id)
    {
        return _context.MemoPosts.Any(x => x.Id == id);
    }
}