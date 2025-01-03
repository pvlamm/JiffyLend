namespace JiffyLend.Module.Card.Domain.Entities;
using System;

public record Account
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public DateTime UpdateDate { get; set; }
    public bool IsActive { get; set; }
}
