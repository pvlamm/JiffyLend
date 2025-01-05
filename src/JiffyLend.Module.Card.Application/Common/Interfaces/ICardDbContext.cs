namespace JiffyLend.Module.Card.Application.Common.Interfaces;
using System.Threading.Tasks;

using JiffyLend.Module.Card.Domain.Entities;

using Microsoft.EntityFrameworkCore;

public interface ICardDbContext
{
    DbSet<Account> Accounts { get; }
    DbSet<Card> Cards { get; }
    DbSet<Cardholder> Cardholders { get; }
    DbSet<CardTransaction> CardTransactions { get; }

    Task BeginTransactionAsync();

    Task CommitTransactionAsync();

    void RollbackTransaction();

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
