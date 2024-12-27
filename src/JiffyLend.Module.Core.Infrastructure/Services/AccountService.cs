namespace JiffyLend.Module.Core.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using JiffyLend.Module.Core.Application.Common.Interfaces;
using JiffyLend.Module.Core.Domain.Entities;

public class AccountService : IAccountService
{
    public bool AccountExists(string accountNumber)
    {
        throw new NotImplementedException();
    }

    public bool AccountExists(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Guid> Create(Account account, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }

    public Task Delete(Guid id, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }

    public Task<Account> GetAccountAccountNumber(string accountNumber, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }

    public Task<Account> GetAccountById(Guid id, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }

    public bool HasAvailableFunds(string accountNumber, long amount)
    {
        throw new NotImplementedException();
    }

    public Task Update(Account account, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }
}
