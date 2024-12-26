namespace JiffyLend.Module.Core.Application.Common.Models.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JiffyLend.Module.Core.Application.Customer.Commands;

using Riok.Mapperly.Abstractions;

[Mapper]
public partial class CustomerMapper
{
    public partial CreateCustomerCommand ToCreateCustomerCommand(CreateCustomer createCustomer);
    public partial UpdateCustomerCommand ToUpdateCustomerCommand(UpdateCustomer updateCustomer);
}
