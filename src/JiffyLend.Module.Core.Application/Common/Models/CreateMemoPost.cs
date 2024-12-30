namespace JiffyLend.Module.Core.Application.Common.Models;

public class CreateMemoPost
{
    public string AccountNumber { get; set; }
    public string Description { get; set; }
    public string ReferenceNumber { get; set; }
    public long Amount { get; set; }
}