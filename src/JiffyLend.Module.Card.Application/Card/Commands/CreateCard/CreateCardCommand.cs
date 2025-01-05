namespace JiffyLend.Module.Card.Application.Card.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using JiffyLend.Module.Card.Application.Common.Interfaces;
using JiffyLend.Module.Card.Application.Common.Models.Mapper;
using JiffyLend.Module.Core.Application.Common.Models;

using MediatR;

public class CreateCardCommand : IRequest<Result<Guid>>
{
    public Guid AccountId { get; set; }
    public Guid CustomerId { get; set; }
}

public class CreateCardCommandHandler : IRequestHandler<CreateCardCommand, Result<Guid>>
{
    private readonly ICardService _cardService;
    public CreateCardCommandHandler(ICardService cardService)
    {
        _cardService = cardService;
    }

    public async Task<Result<Guid>> Handle(CreateCardCommand request, CancellationToken cancellationToken)
    {
        var card = request.ToCard();
        
        await _cardService.CreateCard(card, cancellationToken);

        return card.Id;
    }
}
