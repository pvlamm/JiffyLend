namespace JiffyLend.Module.Core.Application.MemoPost.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using JiffyLend.Module.Core.Application.Common.Interfaces;

using MediatR;

public class DeleteMemoPostCommand : IRequest<bool>
{
    public Guid Id { get; set; }
}

public class DeleteMemoPostCommandHandler : IRequestHandler<DeleteMemoPostCommand, bool>
{
    private readonly IMemoPostService _memoPostService;
    public DeleteMemoPostCommandHandler(IMemoPostService memoPostService)
    {
        _memoPostService = memoPostService;
    }

    public async Task<bool> Handle(DeleteMemoPostCommand request, CancellationToken cancellationToken)
    {
        return await _memoPostService.Delete(request.Id);
    }
}
