namespace JiffyLend.Module.Card.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JiffyLend.Module.Card.Domain.Entities;

public interface ICardService
{
    Task<Guid> CreateCard(Card card, CancellationToken token);
}
