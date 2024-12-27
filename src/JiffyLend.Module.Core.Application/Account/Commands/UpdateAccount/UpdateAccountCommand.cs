namespace JiffyLend.Module.Core.Application.Account.Commands;
using System;

using JiffyLend.Module.Core.Application.Common.Interfaces;
using JiffyLend.Module.Core.Application.Common.Models.Mapper;

using MediatR;

public class UpdateAccountCommand : IRequest
{
    public Guid Id { get; set; }
    public string Title { get; set; }
}

public class UpdateAccountCommandHandler : IRequestHandler<UpdateAccountCommand>
{
    private readonly IAccountService _accountService;
    public UpdateAccountCommandHandler(IAccountService accountService)
    {
        _accountService = accountService;
    }
    public async Task Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
    {
        await _accountService.Update(request.ToAccount(), cancellationToken);
    }
}