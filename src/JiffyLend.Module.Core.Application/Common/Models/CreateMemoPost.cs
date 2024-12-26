namespace JiffyLend.Module.Core.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CreateMemoPost
{
    public string AccountNumber { get; set; }
    public string Description { get; set; }
    public long Amount { get; set; }
}
