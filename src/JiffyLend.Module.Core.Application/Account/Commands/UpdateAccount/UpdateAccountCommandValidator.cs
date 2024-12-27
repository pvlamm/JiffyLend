namespace JiffyLend.Module.Core.Application.Account.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentValidation;

using JiffyLend.Module.Core.Application.Common.Interfaces;

public class UpdateAccountCommandValidator : AbstractValidator<UpdateAccountCommand>
{
    public static string ERROR_ACCOUNT_NOT_FOUND = "Account Not Found";
    public UpdateAccountCommandValidator(IAccountService accountService)
    {
        RuleFor(x => x.Id)
            .Must(accountService.AccountExists)
            .WithMessage(ERROR_ACCOUNT_NOT_FOUND);
    }
}
