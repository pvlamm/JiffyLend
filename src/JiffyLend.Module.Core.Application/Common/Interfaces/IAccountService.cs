namespace JiffyLend.Module.Core.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IAccountService
{
    bool AccountExists(string accountNumber);
    bool AccountExists(Guid id);
    bool HasAvailableFunds(string accountNumber, long amount);
}
