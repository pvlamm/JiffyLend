namespace JiffyLend.Module.Core.Domain.Entities;
using System;

public record AccountBalance
{
    public Guid Id { get; set; }
    public Guid ParentId { get; set; }
    
}
