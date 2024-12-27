namespace JiffyLend.Module.Core.Application.Customer.Queries;

using FluentValidation;

using JiffyLend.Module.Core.Application.Common.Interfaces;

public class GetCustomerInfoByIdQueryValidator : AbstractValidator<GetCustomerInfoByIdQuery>
{
    public static string ERROR_CUSTOMER_MUST_EXIST = "Customer Not Found";
    public GetCustomerInfoByIdQueryValidator(ICustomerService customerService)
    {
        RuleFor(x => x.Id)
            .Must(customerService.Exists)
            .WithMessage(ERROR_CUSTOMER_MUST_EXIST);
    }
}
