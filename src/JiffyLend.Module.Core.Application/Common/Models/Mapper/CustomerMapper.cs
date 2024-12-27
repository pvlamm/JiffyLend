namespace JiffyLend.Module.Core.Application.Common.Models.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JiffyLend.Module.Core.Application.Customer.Commands;
using JiffyLend.Module.Core.Domain.Entities;

using Riok.Mapperly.Abstractions;

[Mapper]
public static partial class CustomerMapper
{
    public static partial CreateCustomerCommand ToCreateCustomerCommand(this CreateCustomer createCustomer);
    public static partial UpdateCustomerCommand ToUpdateCustomerCommand(this UpdateCustomer updateCustomer);
    public static partial Customer ToCustomer(this UpdateCustomerCommand updateCustomerCommand);
    public static partial Customer ToCustomer(this CreateCustomerCommand createCustomerCommand);

    public static partial CustomerInfo ToCustomerInfo(this Customer customer);

    private static void ToCustomerInfo(Customer customer, CustomerInfo customerInfo)
    {
        customerInfo.FullName 
            = FormatFullName(customer.FirstName, customer.LastName);
    }

    private static string FormatFullName(string firstName, string lastName)
    {
        return $"{firstName} {lastName}";
    }
}
