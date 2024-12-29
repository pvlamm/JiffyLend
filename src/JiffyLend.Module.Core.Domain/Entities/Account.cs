namespace JiffyLend.Module.Core.Domain.Entities;

public record Account
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string AccountNumber { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime UpdateDate { get; set; }

    public IEnumerable<Customer> Customers { get; set; }
}