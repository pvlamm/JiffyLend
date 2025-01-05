namespace JiffyLend.Core.Infrastructure.Interfaces;
using System;
using System.Threading.Tasks;

using JiffyLend.Core.Infrastructure.Models;

public interface ICoreHttpClient
{
    Task<AccountInfo> GetAccountInfo(Guid accountId, CancellationToken token);
    Task<CustomerInfo> GetCustomerInfo(Guid customerId, CancellationToken token);
}
