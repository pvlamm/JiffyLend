namespace JiffyLend.Module.Core.Application.Account.Commands;

using System.Threading;
using System.Threading.Tasks;

using JiffyLend.Module.Core.Application.Common.Interfaces;
using JiffyLend.Module.Core.Application.Common.Models;
using JiffyLend.Module.Core.Application.Common.Models.Mapper;

using MediatR;

public class CreateAccountCommand : IRequest<Result<Guid>>
{
    public string Title { get; set; }
    public Guid CustomerId { get; set; }
}

public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, Result<Guid>>
{
    private readonly IAccountService _accountService;
    public CreateAccountCommandHandler(IAccountService accountService)
    {
        IAccountService _accountService = accountService;
    }

    public async Task<Result<Guid>> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
    {
        return await _accountService.Create(request.ToAccount(), cancellationToken);
    }
}
