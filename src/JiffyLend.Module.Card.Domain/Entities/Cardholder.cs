namespace JiffyLend.Module.Card.Domain.Entities;

public record Cardholder
{
    public virtual Guid Id { get; set; }
    public virtual string DisplayName { get; set; }
    public DateTime UpdateDate { get; set; }
}