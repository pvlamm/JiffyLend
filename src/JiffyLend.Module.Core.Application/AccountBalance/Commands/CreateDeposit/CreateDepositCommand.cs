namespace JiffyLend.Module.Core.Application.AccountBalance.Commands;

using System;

public class CreateDepositCommand
{
    public string AccountNumber { get; set; }
    public DateTime? DepositDate { get; set; }
    public long Amount { get; set; }
}