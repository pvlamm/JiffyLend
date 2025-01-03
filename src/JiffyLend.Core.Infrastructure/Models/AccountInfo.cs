namespace JiffyLend.Core.Infrastructure.Models;

using System;

public class AccountInfo
{
    public string AccountNumber { get; set; }
    public string Title { get; set; }
    public bool IsActive { get; set; }
    public DateTime BalanceAsOf { get; set; }
    public long AvailableBalance { get; set; }
    public long Balance { get; set; }

    public IEnumerable<string> NamesOnAccount { get; set; } = Enumerable.Empty<string>();
}