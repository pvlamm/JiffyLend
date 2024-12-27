namespace JiffyLend.Module.Core.Application.Account.Queries;
using System;
using System.Threading.Tasks;

using JiffyLend.Module.Core.Application.Common.Interfaces;
using JiffyLend.Module.Core.Application.Common.Models;
using JiffyLend.Module.Core.Application.Common.Models.Mapper;

using MediatR;

public class GetAccountInfoByIdQuery : IRequest<AccountInfo>
{
    public Guid Id { get; set; }
}

public class GetAccountInfoQueryHandler : IRequestHandler<GetAccountInfoByIdQuery, AccountInfo>
{
    private readonly IAccountService _accountService;
    public GetAccountInfoQueryHandler(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public async Task<AccountInfo> Handle(GetAccountInfoByIdQuery request, CancellationToken cancellationToken)
    {
        var account = await _accountService.GetAccountById(request.Id, cancellationToken);

        return account.ToAccountInfo();
    }
}
