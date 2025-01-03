namespace JiffyLend.Module.Card.Domain.Entities;
using System;

public record CardTransaction
{
    public Guid Id { get; set; }
    public Guid CardId { get; set; }
    public Guid AccountId { get; set; }
    public Guid CardholderId { get; set; }
    public Guid? MemoPostId { get; set; }
    public bool IsPending { get; set; }
    public string Description { get; set; }
    public long Amount { get; set; }
}
