namespace JiffyLend.Module.Core.Application.Account.Queries;

using FluentValidation;

using JiffyLend.Module.Core.Application.Common.Interfaces;

public class GetAccountInfoByIdQueryValidator : AbstractValidator<GetAccountInfoByIdQuery>
{
    public static string ERROR_ACCOUNT_NOT_FOUND = "Account Not Found";

    public GetAccountInfoByIdQueryValidator(IAccountService accountService)
    {
        RuleFor(x => x.Id)
            .Must(accountService.AccountExists)
            .WithMessage(ERROR_ACCOUNT_NOT_FOUND);
    }
}