namespace JiffyLend.Module.Core.Application.MemoPost.Commands.CreateMemoPost;
using System;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

public class CreateMemoPostCommand : IRequest<Guid>
{
    public string AccountNumber { get; set; }
    public string Description { get; set; }
    public long Amount { get; set; }
}

public class CreateMemoPostCommandHandler : IRequestHandler<CreateMemoPostCommand, Guid>
{
    public Task<Guid> Handle(CreateMemoPostCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
