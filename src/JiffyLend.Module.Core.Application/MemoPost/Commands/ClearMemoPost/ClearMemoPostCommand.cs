namespace JiffyLend.Module.Core.Application.MemoPost.Commands;

using System;
using System.Threading;
using System.Threading.Tasks;

using JiffyLend.Module.Core.Application.Common.Interfaces;
using JiffyLend.Module.Core.Application.Common.Models;

using MediatR;

public class ClearMemoPostCommand : IRequest<Result<bool>>
{
    public Guid Id { get; set; }
}

public class ClearMemoPostCommandHandler : IRequestHandler<ClearMemoPostCommand, Result<bool>>
{
    private readonly IMemoPostService _memoPostService;

    public ClearMemoPostCommandHandler(IMemoPostService memoPostService)
    {
        _memoPostService = memoPostService;
    }

    public async Task<Result<bool>> Handle(ClearMemoPostCommand request, CancellationToken cancellationToken)
    {
        await _memoPostService.Clear(request.Id, cancellationToken);

        return true;
    }
}