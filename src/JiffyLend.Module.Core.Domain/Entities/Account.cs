namespace JiffyLend.Module.Core.Domain.Entities;

public record Account
{
    public Guid Id { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime UpdateDate { get; set; }
}
