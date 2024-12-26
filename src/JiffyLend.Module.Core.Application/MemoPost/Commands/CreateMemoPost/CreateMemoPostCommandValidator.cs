namespace JiffyLend.Module.Core.Application.MemoPost.Commands.CreateMemoPost;

using FluentValidation;

using JiffyLend.Module.Core.Application.Common.Interfaces;

public class CreateMemoPostCommandValidator : AbstractValidator<CreateMemoPostCommand>
{
    public static string ERROR_ACCOUNT_DOES_NOT_EXIST = "Account does not exist";
    public static string ERROR_INSUFFICIENT_FUNDS = "Insufficient Funds";

    public CreateMemoPostCommandValidator(IAccountService accountService, 
        IMemoPostService memoPostService)
    {
        RuleFor(x => x)
            .Must(x => accountService
                .AccountExists(x.AccountNumber))
                .WithMessage(ERROR_ACCOUNT_DOES_NOT_EXIST)
            .Must(x => accountService
                .HasAvailableFunds(x.AccountNumber, x.Amount))
                .WithMessage(ERROR_INSUFFICIENT_FUNDS);
    }
}
