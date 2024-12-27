namespace JiffyLend.Module.Core.Application.Account.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JiffyLend.Module.Core.Application.Common.Interfaces;
using JiffyLend.Module.Core.Application.Common.Models;

using MediatR;

public class GetAccountInfoQuery : IRequest<AccountInfo>
{
    public string AccountNumber { get; set; }
}

public class GetAccountInfoQueryHandler : IRequestHandler<GetAccountInfoQuery, AccountInfo>
{
    private readonly IAccountService _accountService;
    public GetAccountInfoQueryHandler(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public async Task<AccountInfo> Handle(GetAccountInfoQuery request, CancellationToken cancellationToken)
    {

    }
}
