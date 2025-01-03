namespace JiffyLend.Module.Core.Application.Common.Interfaces;

using System;
using System.Threading.Tasks;

using JiffyLend.Module.Core.Domain.Entities;

public interface IAccountService
{
    bool AccountExists(string accountNumber);

    bool AccountExists(Guid id);

    bool HasAvailableFunds(string accountNumber, long amount);

    bool HasAvailableFunds(Guid id, long amount);

    Task<Account> GetAccountAccountNumber(string accountNumber, CancellationToken token = default);

    Task<Account> GetAccountById(Guid id, CancellationToken token = default);

    Task<Guid> Create(Account account, CancellationToken token = default);

    Task Update(Account account, CancellationToken token = default);

    Task Delete(Guid id, CancellationToken token = default);
}