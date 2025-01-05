namespace JiffyLend.Tests.Module.Core.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JiffyLend.Module.Core.Application.Common.Models;
using JiffyLend.Module.Core.Application.Common.Models.Mapper;
using JiffyLend.Module.Core.Application.Customer.Commands;

public class CustomerMapperTests
{
    [Fact]
    public void ToCreateCustomerCommand_FromCreateCustomer_ShouldMap()
    {
        var createCustomer = new CreateCustomer
        {
            AccountId = Guid.NewGuid(),
            FirstName = Faker.Name.First(),
            LastName = Faker.Name.Last(),
            EmailAddress = Faker.Internet.Email(),
        };

        var customer = createCustomer.ToCreateCustomerCommand();

        Assert.Equal(createCustomer.AccountId, customer.AccountId);
    }

    [Fact]
    public void ToCustomer_FromCreateCustomerCommand_ShouldMap()
    {
        var createCustomer = new CreateCustomerCommand
        {
            AccountId = Guid.NewGuid(),
            FirstName = Faker.Name.First(),
            LastName = Faker.Name.Last(),
            EmailAddress = Faker.Internet.Email(),
        };

        var customer = createCustomer.ToCustomer();

        Assert.Equal(createCustomer.AccountId, customer.ParentId);
    }
}
