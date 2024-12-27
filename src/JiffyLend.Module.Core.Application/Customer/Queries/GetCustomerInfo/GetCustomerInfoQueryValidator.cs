namespace JiffyLend.Module.Core.Application.Customer.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentValidation;

using JiffyLend.Module.Core.Application.Common.Interfaces;

public class GetCustomerInfoQueryValidator : AbstractValidator<GetCustomerInfoByIdQuery>
{
    public static string ERROR_CUSTOMER_MUST_EXIST = "Customer Not Found";
    public GetCustomerInfoQueryValidator(ICustomerService customerService)
    {
        RuleFor(x => x.Id)
            .Must(customerService.Exists)
            .WithMessage(ERROR_CUSTOMER_MUST_EXIST);
    }
}
