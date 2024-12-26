namespace JiffyLend.Module.Core.Application.Customer.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentValidation;

public class CreateCustomerCommandValidation : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerCommandValidation()
    {
    }
}
