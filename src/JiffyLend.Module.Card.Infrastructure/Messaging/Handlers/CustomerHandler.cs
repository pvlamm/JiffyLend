namespace JiffyLend.Module.Card.Infrastructure.Messaging.Handlers;
using System.Linq;
using System.Threading.Tasks;

using JiffyLend.Core.Infrastructure.Messages;
using JiffyLend.Module.Card.Application.Common.Interfaces;
using JiffyLend.Module.Card.Domain.Entities;

using MassTransit;

public class CustomerHandler : IConsumer<ICreatedACustomer>,
    IConsumer<IUpdatedACustomer>
{
    private readonly ICardDbContext _cardDbContext;
    public CustomerHandler(ICardDbContext cardDbContext)
    {
        _cardDbContext = cardDbContext;
    }

    public async Task Consume(ConsumeContext<IUpdatedACustomer> context)
    {
        var message = context.Message;
        if (message == null) return;

        var cardholder = await _cardDbContext.Cardholders.FindAsync(message.Id);
        if (cardholder == null) return;

        cardholder.DisplayName = message.DisplayName;
        cardholder.UpdateDate = message.ChangeDate;

        await _cardDbContext.SaveChangesAsync(default);
    }

    public async Task Consume(ConsumeContext<ICreatedACustomer> context)
    {
        var message = context.Message;
        if (message == null) return;

        if(!_cardDbContext.Cardholders.Any(x => x.Id == message.Id))
        {
            var cardholder = new Cardholder
            {
                Id = message.Id,
                DisplayName = message.DisplayName,
                UpdateDate = message.ChangeDate
            };
            await _cardDbContext.Cardholders.AddAsync(cardholder, default);
            await _cardDbContext.SaveChangesAsync(default);
        }

    }
}
