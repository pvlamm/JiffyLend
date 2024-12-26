namespace JiffyLend.Module.Core.Application.AccountBalance.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CreateDepositCommand
{
    public string AccountNumber { get; set; }
    public DateTime? DepositDate { get; set; }
    public long Amount { get; set; }
}
