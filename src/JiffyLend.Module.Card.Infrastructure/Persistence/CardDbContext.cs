namespace JiffyLend.Module.Card.Infrastructure.Persistence;

using System.Data;
using System.Reflection;
using System.Threading.Tasks;

using JiffyLend.Module.Card.Application.Common.Interfaces;
using JiffyLend.Module.Card.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

public class CardDbContext : DbContext, ICardDbContext
{

    public CardDbContext(DbContextOptions<CardDbContext> options) : base(options)
    {
    }
    public DbSet<Account> Accounts => Set<Account>();

    public DbSet<Card> Cards => Set<Card>();

    public DbSet<Cardholder> Cardholders => Set<Cardholder>();

    public DbSet<CardTransaction> CardTransactions => Set<CardTransaction>();

    private IDbContextTransaction _currentTransaction;

    public async Task BeginTransactionAsync()
    {
        if (_currentTransaction != null)
        {
            return;
        }

        _currentTransaction = await base.Database.BeginTransactionAsync(IsolationLevel.ReadCommitted).ConfigureAwait(false);
    }

    public async Task CommitTransactionAsync()
    {
        try
        {
            await SaveChangesAsync().ConfigureAwait(false);

            _currentTransaction?.Commit();
        }
        catch
        {
            RollbackTransaction();
            throw;
        }
        finally
        {
            if (_currentTransaction != null)
            {
                _currentTransaction.Dispose();
                _currentTransaction = null;
            }
        }
    }

    public void RollbackTransaction()
    {
        try
        {
            _currentTransaction?.Rollback();
        }
        finally
        {
            if (_currentTransaction != null)
            {
                _currentTransaction.Dispose();
                _currentTransaction = null;
            }
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
