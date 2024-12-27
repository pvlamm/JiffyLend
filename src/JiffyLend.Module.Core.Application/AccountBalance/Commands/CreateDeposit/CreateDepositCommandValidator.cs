namespace JiffyLend.Module.Core.Application.AccountBalance.Commands;

using FluentValidation;

public class CreateDepositCommandValidator : AbstractValidator<CreateDepositCommand>
{
    public static string ERROR_ACCOUNT_DOES_NOT_EXIST = "Account does not exist";
    public static string ERROR_ACCOUNT_IS_CLOSED = "Account is Closed";

    public CreateDepositCommandValidator()
    {
    }
}
