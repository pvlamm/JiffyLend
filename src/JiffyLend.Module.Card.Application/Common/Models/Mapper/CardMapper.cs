namespace JiffyLend.Module.Card.Application.Common.Models.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JiffyLend.Module.Card.Application.Card.Commands;
using JiffyLend.Module.Card.Domain.Entities;

using Riok.Mapperly.Abstractions;

[Mapper]
public static partial class CardMapper
{
    public static partial CreateCardCommand ToCreateCardCommand(this CreateCard createCard);
    public static partial Card ToCard(this CreateCardCommand createCardCommand);

}
