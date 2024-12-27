namespace JiffyLend.Module.Core.Application.Customer.Commands;

using FluentValidation;

using JiffyLend.Module.Core.Application.Common.Interfaces;

public class CreateCustomerCommandValidation : AbstractValidator<CreateCustomerCommand>
{
    public static string ERROR_CUSTOMER_EMAIL_ALREADY_EXISTS = "Customer Email already in use";

    public CreateCustomerCommandValidation(ICustomerService customerService)
    {
        RuleFor(x => x.EmailAddress)
            .Must(customerService.EmailExists)
            .WithMessage(ERROR_CUSTOMER_EMAIL_ALREADY_EXISTS);
    }
}
