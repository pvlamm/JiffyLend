namespace JiffyLend.Module.Core.Application.Account.Commands;

using System.Threading;
using System.Threading.Tasks;

using JiffyLend.Core.Common.Interfaces;
using JiffyLend.Core.Extensions;
using JiffyLend.Core.Infrastructure.Messages;
using JiffyLend.Core.Infrastructure.Models;
using JiffyLend.Module.Core.Application.Common.Interfaces;
using JiffyLend.Module.Core.Application.Common.Models;
using JiffyLend.Module.Core.Application.Common.Models.Mapper;

using MassTransit;

using MediatR;

public class CreateAccountCommand : IRequest<Result<AccountInfo>>
{
    public string Title { get; set; }
}

public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, Result<AccountInfo>>
{
    private readonly IAccountService _accountService;
    private readonly IPublishEndpoint _publish;
    private readonly IDateTime _dateTime;

    public CreateAccountCommandHandler(IAccountService accountService, IDateTime dateTime, IPublishEndpoint publish)
    {
        _accountService = accountService;
        _dateTime = dateTime;
        _publish = publish;
    }

    public async Task<Result<AccountInfo>> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
    {
        var account = request.ToAccount();
        var createdDate = _dateTime.Now;

        account.Id = JiffyGuid.NewId();
        account.AccountNumber = createdDate.Ticks.ToString();
        account.CreateDate = createdDate;
        account.UpdateDate = createdDate;

        await _accountService.Create(account, cancellationToken);
        await _publish.Publish<ICreatedAnAccount>(new
        {
            account.Id,
            DisplayName = account.Title,
            ChangeDate = account.CreateDate
        }, cancellationToken);

        return account.ToAccountInfo();
    }
}