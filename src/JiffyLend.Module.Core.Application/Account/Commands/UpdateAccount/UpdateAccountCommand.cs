namespace JiffyLend.Module.Core.Application.Account.Commands;

using System;

using JiffyLend.Module.Core.Application.Common.Interfaces;
using JiffyLend.Module.Core.Application.Common.Models;
using JiffyLend.Module.Core.Application.Common.Models.Mapper;

using MediatR;

public class UpdateAccountCommand : IRequest<Result<bool>>
{
    public Guid Id { get; set; }
    public string Title { get; set; }
}

public class UpdateAccountCommandHandler : IRequestHandler<UpdateAccountCommand, Result<bool>>
{
    private readonly IAccountService _accountService;

    public UpdateAccountCommandHandler(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public async Task<Result<bool>> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
    {
        await _accountService.Update(request.ToAccount(), cancellationToken);

        return true;
    }
}