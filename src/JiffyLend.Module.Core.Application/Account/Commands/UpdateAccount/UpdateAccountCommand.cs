namespace JiffyLend.Module.Core.Application.Account.Commands;

using System;

using JiffyLend.Core.Infrastructure.Messages;
using JiffyLend.Module.Core.Application.Common.Interfaces;
using JiffyLend.Module.Core.Application.Common.Models;
using JiffyLend.Module.Core.Application.Common.Models.Mapper;

using MassTransit;

using MediatR;

public class UpdateAccountCommand : IRequest<Result<bool>>
{
    public Guid Id { get; set; }
    public string Title { get; set; }
}

public class UpdateAccountCommandHandler : IRequestHandler<UpdateAccountCommand, Result<bool>>
{
    private readonly IAccountService _accountService;
    private readonly IPublishEndpoint _publish;
    public UpdateAccountCommandHandler(IAccountService accountService, IPublishEndpoint publish)
    {
        _accountService = accountService;
        _publish = publish;
    }

    public async Task<Result<bool>> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
    {
        var account = await _accountService.GetAccountById(request.Id);

        account.Title = request.Title;

        await _accountService.Update(account, cancellationToken);
        await _publish.Publish<IUpdatedAnAccount>(new
        {
            request.Id,
            DisplayName = account.Title,
            ChangeDate = account.UpdateDate
        }, cancellationToken);

        return true;
    }
}