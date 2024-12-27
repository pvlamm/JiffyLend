namespace JiffyLend.Module.Core.Application.AccountBalance.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JiffyLend.Module.Core.Application.Common.Models;

using MediatR;

public class AccountBalanceQuery : IRequest<AccountInfo>
{
}
