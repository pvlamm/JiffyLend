namespace JiffyLend.Module.Core.Application.MemoPost.Commands;

using System;
using System.Threading;
using System.Threading.Tasks;

using JiffyLend.Module.Core.Application.Common.Interfaces;
using JiffyLend.Module.Core.Application.Common.Models;

using MediatR;

public class DeleteMemoPostCommand : IRequest<Result<bool>>
{
    public Guid Id { get; set; }
}

public class DeleteMemoPostCommandHandler : IRequestHandler<DeleteMemoPostCommand, Result<bool>>
{
    private readonly IMemoPostService _memoPostService;

    public DeleteMemoPostCommandHandler(IMemoPostService memoPostService)
    {
        _memoPostService = memoPostService;
    }

    public async Task<Result<bool>> Handle(DeleteMemoPostCommand request, CancellationToken cancellationToken)
    {
        await _memoPostService.Delete(request.Id, cancellationToken);

        return true;
    }
}