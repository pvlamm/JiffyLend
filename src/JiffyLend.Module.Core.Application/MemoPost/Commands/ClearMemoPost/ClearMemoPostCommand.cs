namespace JiffyLend.Module.Core.Application.MemoPost.Commands;
using System;
using System.Threading;
using System.Threading.Tasks;

using JiffyLend.Module.Core.Application.Common.Interfaces;

using MediatR;

public class ClearMemoPostCommand : IRequest
{
    public Guid Id { get; set; }
}

public class ClearMemoPostCommandHandler : IRequestHandler<ClearMemoPostCommand>
{
    private readonly IMemoPostService _memoPostService;
    public ClearMemoPostCommandHandler(IMemoPostService memoPostService)
    {
        _memoPostService = memoPostService;
    }

    public async Task Handle(ClearMemoPostCommand request, CancellationToken cancellationToken)
    {
        await _memoPostService.Clear(request.Id, cancellationToken);
    }
}
