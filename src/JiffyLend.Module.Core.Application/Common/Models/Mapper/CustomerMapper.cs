﻿namespace JiffyLend.Module.Core.Application.Common.Models.Mapper;

using JiffyLend.Core.Infrastructure.Models;
using JiffyLend.Module.Core.Application.Customer.Commands;
using JiffyLend.Module.Core.Domain.Entities;

using Riok.Mapperly.Abstractions;

[Mapper]
public static partial class CustomerMapper
{
    [MapProperty(nameof(CreateCustomer.AccountId), nameof(CreateCustomerCommand.AccountId))]
    public static partial CreateCustomerCommand ToCreateCustomerCommand(this CreateCustomer createCustomer);

    public static partial UpdateCustomerCommand ToUpdateCustomerCommand(this UpdateCustomer updateCustomer);

    public static partial Customer ToCustomer(this UpdateCustomerCommand updateCustomerCommand);

    [MapProperty(nameof(CreateCustomerCommand.AccountId), nameof(Customer.ParentId))]
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