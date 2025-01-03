namespace JiffyLend.Module.Card.Infrastructure.Services;
using System;
using System.Threading;
using System.Threading.Tasks;

using JiffyLend.Module.Card.Application.Common.Interfaces;
using JiffyLend.Module.Card.Domain.Entities;

public class CardService : ICardService
{
    private readonly ICardDbContext _cardDbContext;
    public CardService(ICardDbContext cardDbContext)
    {
        _cardDbContext = cardDbContext;
    }

    public async Task<Guid> CreateCard(Card card, CancellationToken token)
    {
        await _cardDbContext.Cards.AddAsync(card, token);
        await _cardDbContext.SaveChangesAsync(token);

        return card.Id;
    }
}
