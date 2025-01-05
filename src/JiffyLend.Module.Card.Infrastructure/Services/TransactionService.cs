namespace JiffyLend.Module.Card.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JiffyLend.Core.Infrastructure.Interfaces;
using JiffyLend.Module.Card.Application.Common.Interfaces;
using JiffyLend.Module.Card.Domain.Entities;

public class TransactionService : ITransactionService
{
    private readonly ICardDbContext _cardDbContext;
    private readonly ICoreHttpClient _coreHttpClient;

    public TransactionService(ICardDbContext cardDbContext, ICoreHttpClient coreHttpClient)
    {
        _cardDbContext = cardDbContext;
        _coreHttpClient = coreHttpClient;
    }

    public Task ClearTransaction(Guid transactionId)
    {
        // get MemoPostId
        // coreHttpCall to Clear Transaction
        // Update Local Transaction
        throw new NotImplementedException();
    }

    public Task<Guid> CreateTransaction(CardTransaction transaction)
    {
        // Get
        throw new NotImplementedException();
    }
}
