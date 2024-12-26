namespace JiffyLend.Module.Core.Application.Common.Models.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JiffyLend.Module.Core.Application.Account.Commands;

using Riok.Mapperly.Abstractions;

[Mapper]
public partial class AccountMapper
{
    public partial CreateAccountCommand ToCreateAccountCommand(CreateAccount createAccount);
    public partial UpdateAccountCommand ToUpdateAccountCommand(UpdateAccount updateAccount);
}
