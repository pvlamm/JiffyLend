﻿namespace JiffyLend.Module.Core.Application.AccountBalance.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentValidation;

public class AccountBalanceQueryValidator : AbstractValidator<AccountBalanceQuery>
{
    public AccountBalanceQueryValidator()
    {
    }
}