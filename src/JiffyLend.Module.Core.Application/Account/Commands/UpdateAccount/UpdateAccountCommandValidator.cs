namespace JiffyLend.Module.Core.Application.Account.Commands;

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