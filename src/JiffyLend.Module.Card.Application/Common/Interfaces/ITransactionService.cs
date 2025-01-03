namespace JiffyLend.Module.Card.Application.Common.Interfaces;
using System;
using System.Threading.Tasks;

using JiffyLend.Module.Card.Domain.Entities;

public interface ITransactionService
{
    Task<Guid> CreateTransaction(CardTransaction transaction);
    Task ClearTransaction(Guid transactionId);
}
