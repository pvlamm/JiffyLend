namespace JiffyLend.Module.Core.Application.Account.Queries;

using System;
using System.Threading.Tasks;

using JiffyLend.Core.Infrastructure.Models;
using JiffyLend.Module.Core.Application.Common.Interfaces;
using JiffyLend.Module.Core.Application.Common.Models;
using JiffyLend.Module.Core.Application.Common.Models.Mapper;

using MediatR;

public class GetAccountInfoByIdQuery : IRequest<Result<AccountInfo>>
{
    public Guid Id { get; set; }
}

public class GetAccountInfoQueryHandler : IRequestHandler<GetAccountInfoByIdQuery, Result<AccountInfo>>
{
    private readonly IAccountService _accountService;

    public GetAccountInfoQueryHandler(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public async Task<Result<AccountInfo>> Handle(GetAccountInfoByIdQuery request, CancellationToken cancellationToken)
    {
        var account = await _accountService.GetAccountById(request.Id, cancellationToken);

        return account.ToAccountInfo();
    }
}