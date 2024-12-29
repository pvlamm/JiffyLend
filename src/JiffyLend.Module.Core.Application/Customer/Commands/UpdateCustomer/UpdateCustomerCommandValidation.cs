namespace JiffyLend.Module.Core.Application.Customer.Commands;

using FluentValidation;

public class UpdateCustomerCommandValidation : AbstractValidator<UpdateCustomerCommand>
{
    public UpdateCustomerCommandValidation()
    {
    }
}