namespace JiffyLend.Module.Card.Infrastructure.Messaging.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JiffyLend.Core.Infrastructure.Messages;
using JiffyLend.Module.Card.Application.Common.Interfaces;
using JiffyLend.Module.Card.Domain.Entities;

using MassTransit;

public class AccountHandler : IConsumer<ICreatedAnAccount>,
    IConsumer<IUpdatedAnAccount>
{
    private readonly ICardDbContext _cardDbContext;
    public AccountHandler(ICardDbContext cardDbContext)
    {
        _cardDbContext = cardDbContext;
    }

    public async Task Consume(ConsumeContext<IUpdatedAnAccount> context)
    {
        var message = context.Message;
        if (message == null) return;

        var account = await _cardDbContext.Accounts.FindAsync(message.Id);

        account.Title = message.Title;
        account.UpdateDate = message.ChangeDate;
        account.IsActive = message.IsActive;

        await _cardDbContext.SaveChangesAsync();
    }

    public async Task Consume(ConsumeContext<ICreatedAnAccount> context)
    {
        var message = context.Message;
        if (message == null) return;

        if (!_cardDbContext.Accounts.Any(x => x.Id == message.Id))
        {
            var account = new Account
            {
                Id = message.Id,
                Title = message.Title,
                IsActive = message.IsActive,
                UpdateDate = message.ChangeDate
            };
            await _cardDbContext.Accounts.AddAsync(account);
            await _cardDbContext.SaveChangesAsync();
        }

    }
}
