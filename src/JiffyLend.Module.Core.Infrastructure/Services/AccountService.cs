namespace JiffyLend.Module.Core.Infrastructure.Services;

using System;
using System.Threading;
using System.Threading.Tasks;

using JiffyLend.Core.Extensions;
using JiffyLend.Module.Core.Application.Common.Interfaces;
using JiffyLend.Module.Core.Domain.Entities;

using Microsoft.EntityFrameworkCore;

public class AccountService : IAccountService
{
    private readonly ICoreDbContext _context;

    public AccountService(ICoreDbContext context)
    {
        _context = context;
    }

    public bool AccountExists(string accountNumber)
    {
        return _context.Accounts.Any(x => x.AccountNumber == accountNumber);
    }

    public bool AccountExists(Guid id)
    {
        return _context.Accounts.Any(x => x.Id == id);
    }

    public async Task<Guid> Create(Account account, CancellationToken token = default)
    {
        account.Id = JiffyGuid.NewId();
        await _context.Accounts.AddAsync(account, token);
        await _context.SaveChangesAsync(token);
        return account.Id;
    }

    public async Task Delete(Guid id, CancellationToken token = default)
    {
        await _context.Accounts.Where(x => x.Id == id)
            .ExecuteUpdateAsync(x => 
                x.SetProperty(a => a.IsActive, false), 
                token);
    }

    public async Task<Account> GetAccountAccountNumber(string accountNumber, CancellationToken token = default)
    {
        return await _context.Accounts.SingleAsync(x => x.AccountNumber == accountNumber, token);
    }

    public async Task<Account> GetAccountById(Guid id, CancellationToken token = default)
    {
        return await _context.Accounts.SingleAsync(x => x.Id == id, token);
    }

    public bool HasAvailableFunds(string accountNumber, long amount)
    {
        var account = _context.Accounts
            .Select(x => new { x.Id, x.AccountNumber })
            .Single(x => x.AccountNumber == accountNumber);

        return HasAvailableFunds(account.Id, amount);
    }

    public bool HasAvailableFunds(Guid id, long amount)
    {
        var currentPendingAmount = _context.MemoPosts
            .Select(x => new
            {
                x.AccountId,
                x.CompleteDate,
                x.CancelDate,
                x.Amount
            })
            .Where(x => x.AccountId == id 
                && x.CompleteDate == null
                && x.CancelDate == null)
            .Sum(x => x.Amount);

        var currentBalance = _context.AccountActivities
            .Select(x => new
            {
                x.ParentId,
                x.Amount,
            })
            .Where(x => x.ParentId == id)
            .Sum(x => x.Amount);

        return (currentPendingAmount +  currentBalance) > amount;
    }

    public async Task Update(Account account, CancellationToken token = default)
    {
        _context.Accounts.Attach(account);
        await _context.SaveChangesAsync(token);
    }
}