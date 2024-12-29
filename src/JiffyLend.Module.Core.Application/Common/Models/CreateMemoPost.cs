namespace JiffyLend.Module.Core.Application.Common.Models;

public class CreateMemoPost
{
    public string AccountNumber { get; set; }
    public string Description { get; set; }
    public long Amount { get; set; }
}