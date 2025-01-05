namespace JiffyLend.Module.Core.Application.Customer.Commands;

using FluentValidation;

using JiffyLend.Module.Core.Application.Common.Interfaces;

public class CreateCustomerCommandValidation : AbstractValidator<CreateCustomerCommand>
{
    public static string ERROR_CUSTOMER_EMAIL_ALREADY_EXISTS = "Customer Email already in use";
    public static string ERROR_ACCOUNT_DOES_NOT_EXIST = "Account Referenced Not Found";

    public CreateCustomerCommandValidation(IAccountService accountService, 
        ICustomerService customerService)
    {
        RuleFor(x => x.AccountId)
            .Must(x => { return accountService.AccountExists(x); })
            .WithMessage(ERROR_ACCOUNT_DOES_NOT_EXIST);

        RuleFor(x => x.EmailAddress)
            .Must(x => { return !customerService.EmailExists(x); })
            .WithMessage(ERROR_CUSTOMER_EMAIL_ALREADY_EXISTS);
    }
}