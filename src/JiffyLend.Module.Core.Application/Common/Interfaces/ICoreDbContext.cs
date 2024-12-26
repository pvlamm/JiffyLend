namespace JiffyLend.Module.Core.Application.Common.Interfaces;
using System.Threading.Tasks;

using JiffyLend.Module.Core.Domain.Entities;

using Microsoft.EntityFrameworkCore;

public interface ICoreDbContext
{
    DbSet<Account> Accounts { get; }
    DbSet<AccountBalance> AccountBalances { get; }
    DbSet<AccountCustomer> AccountCustomers { get; }
    DbSet<MemoPost> MemoPosts { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
