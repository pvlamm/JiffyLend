namespace JiffyLend.Module.Card.Application.Common.Models;
using System;

public class CreateCard
{
    public Guid AccountId { get; set; }
    public Guid CustomerId { get; set; }
}
