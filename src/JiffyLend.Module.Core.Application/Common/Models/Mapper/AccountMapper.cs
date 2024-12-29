namespace JiffyLend.Module.Core.Application.Common.Models.Mapper;

using JiffyLend.Module.Core.Application.Account.Commands;
using JiffyLend.Module.Core.Domain.Entities;

using Riok.Mapperly.Abstractions;

[Mapper]
public static partial class AccountMapper
{
    public static partial CreateAccountCommand ToCreateAccountCommand(this CreateAccount createAccount);

    public static partial UpdateAccountCommand ToUpdateAccountCommand(this UpdateAccount updateAccount);

    public static partial Account ToAccount(this CreateAccountCommand createAccountCommand);

    public static partial Account ToAccount(this UpdateAccountCommand updateAccountCommand);

    public static partial AccountInfo ToAccountInfo(this Account account);

    private static void ToAccountInfo(Account account, AccountInfo accountInfo) => accountInfo.NamesOnAccount =
            account.Customers.Select(c => c.ToCustomerInfo().FullName).ToList();
}