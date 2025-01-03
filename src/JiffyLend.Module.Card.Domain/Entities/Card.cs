namespace JiffyLend.Module.Card.Domain.Entities;

public record Card
{
    public Guid Id { get; set; }
    public Guid AccountId { get; set; }
    public Guid CardholderId { get; set; }
    public string CreditCardNumber { get; set; }
}