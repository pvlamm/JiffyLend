﻿namespace JiffyLend.Module.Core.Application.Common.Models;
using System;

public class AccountBalance
{
    public string AccountNumber { get; set; }
    public DateTime BalanceAsOf { get; set; }
    public long AvailableBalance { get; set; }
    public long Balance { get; set; }
}
