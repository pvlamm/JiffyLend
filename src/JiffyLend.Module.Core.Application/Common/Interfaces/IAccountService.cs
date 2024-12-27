namespace JiffyLend.Module.Core.Application.Common.Interfaces;
using System;
using System.Threading.Tasks;

using JiffyLend.Module.Core.Domain.Entities;

public interface IAccountService
{
    bool AccountExists(string accountNumber);
    bool AccountExists(Guid id);
    bool HasAvailableFunds(string accountNumber, long amount);
    Task<Account> GetAccount(string accountNumber);

}
