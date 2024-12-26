namespace JiffyLend.Module.Core.Application.Account.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentValidation;

public class CreateAccountCommandValidation : AbstractValidator<CreateAccountCommand>
{
    public CreateAccountCommandValidation()
    {
    }
}
