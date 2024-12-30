namespace JiffyLend.Module.Core.Application.Account.Commands;

using System.Threading;
using System.Threading.Tasks;

using JiffyLend.Core.Infrastructure.Messages;
using JiffyLend.Module.Core.Application.Common.Interfaces;
using JiffyLend.Module.Core.Application.Common.Models;
using JiffyLend.Module.Core.Application.Common.Models.Mapper;

using MassTransit;

using MediatR;

public class CreateAccountCommand : IRequest<Result<Guid>>
{
    public string Title { get; set; }
    public Guid CustomerId { get; set; }
}

public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, Result<Guid>>
{
    private readonly IAccountService _accountService;
    private readonly IPublishEndpoint _publish;

    public CreateAccountCommandHandler(IAccountService accountService, IPublishEndpoint publish)
    {
        IAccountService _accountService = accountService;
        _publish = publish;
    }

    public async Task<Result<Guid>> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
    {
        var account = request.ToAccount();

        await _accountService.Create(account, cancellationToken);
        await _publish.Publish<ICreatedAnAccount>(new
        {
            account.Id,
            DisplayName = account.Title,
            ChangeDate = account.CreateDate
        }, cancellationToken);

        return account.Id;
    }
}