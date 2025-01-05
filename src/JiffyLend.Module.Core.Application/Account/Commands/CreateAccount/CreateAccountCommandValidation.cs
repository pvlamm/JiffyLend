namespace JiffyLend.Module.Core.Application.Account.Commands;

using FluentValidation;

using JiffyLend.Module.Core.Application.Common.Interfaces;

public class CreateAccountCommandValidation : AbstractValidator<CreateAccountCommand>
{
    public static string ERROR_TITLE_ALREADY_IN_USE = "Account Title already in Use";

    public CreateAccountCommandValidation(IAccountService accountService,
        ICustomerService customerService)
    {
        RuleFor(x => x.Title)
            .Must(x => { return !accountService.AccountExists(x); })
            .WithMessage(ERROR_TITLE_ALREADY_IN_USE);
    }
}