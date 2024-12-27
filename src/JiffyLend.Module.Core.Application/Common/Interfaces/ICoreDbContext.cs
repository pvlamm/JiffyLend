namespace JiffyLend.Module.Core.Application.Common.Interfaces;
using System.Threading.Tasks;

using JiffyLend.Module.Core.Domain.Entities;

using Microsoft.EntityFrameworkCore;

public interface ICoreDbContext
{
    DbSet<Account> Accounts { get; }
    DbSet<AccountActivity> AccountActivities { get; }
    DbSet<Customer> AccountCustomers { get; }
    DbSet<MemoPost> MemoPosts { get; }

    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    void RollbackTransaction();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
