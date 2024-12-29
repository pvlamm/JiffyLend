namespace JiffyLend.Module.Core.Application.MemoPost.Commands.CreateMemoPost;

using System;
using System.Threading;
using System.Threading.Tasks;

using JiffyLend.Module.Core.Application.Common.Interfaces;
using JiffyLend.Module.Core.Application.Common.Models;
using JiffyLend.Module.Core.Application.Common.Models.Mapper;

using MediatR;

public class CreateMemoPostCommand : IRequest<Result<Guid>>
{
    public string AccountNumber { get; set; }
    public string Description { get; set; }
    public long Amount { get; set; }
}

public class CreateMemoPostCommandHandler : IRequestHandler<CreateMemoPostCommand, Result<Guid>>
{
    private readonly IMemoPostService _memoPostService;

    public CreateMemoPostCommandHandler(IMemoPostService memoPostService)
    {
        _memoPostService = memoPostService;
    }

    public async Task<Result<Guid>> Handle(CreateMemoPostCommand request, CancellationToken cancellationToken)
    {
        var mapper = new MemoPostMapper();
        var memoPost = mapper.ToMemoPost(request);

        return await _memoPostService.Create(memoPost, cancellationToken);
    }
}