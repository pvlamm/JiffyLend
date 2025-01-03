namespace JiffyLend.Module.Card.Application.Common.Models;
using System;

public class CreateTransaction
{
    public Guid CardId { get; set; }
    public string Description { get; set; }
    public long Amount { get; set; }
}
