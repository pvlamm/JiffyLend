namespace JiffyLend.Module.Core.Application.Account.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentValidation;

using JiffyLend.Module.Core.Application.Common.Interfaces;

public class CreateAccountCommandValidation : AbstractValidator<CreateAccountCommand>
{
    public static string ERROR_CUSTOMER_ID_MUST_EXIST = "Customer Id must exist";
    public static string ERROR_TITLE_ALREADY_IN_USE = "Account Title already in Use";

    public CreateAccountCommandValidation(IAccountService accountService, 
        ICustomerService customerService)
    {
        RuleFor(x => x.CustomerId)
            .Must(customerService.Exists)
            .WithMessage(ERROR_CUSTOMER_ID_MUST_EXIST);

        RuleFor(x => x.Title)
            .Must(accountService.AccountExists)
            .WithMessage(ERROR_TITLE_ALREADY_IN_USE);

    }
}
