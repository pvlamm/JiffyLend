namespace JiffyLend.Tests.Module.Core.Modules.Card;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JiffyLend.Tests.Core.Modules;
using JiffyLend.Tests.Core;
using JiffyLend.Module.Core.Infrastructure.Persistence;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using JiffyLend.Module.Core.Domain.Entities;
using System.Net.Http;
using JiffyLend.Core.Extensions;
using System.Net.Http.Json;

public class CustomerTests
{
    private readonly ModuleTestBase _testBase;
    public CustomerTests(ModuleTestBase testBase)
    {
        _testBase = testBase;
    }

    [Fact]
    public void CreateCustomer_Succeeds()
    {
        var httpClient = _testBase.Factory.CreateClient();

        var _scope = _testBase.Factory.Services.CreateScope();
        var _coreDbContext = _scope.ServiceProvider.GetRequiredService<CoreDbContext>();

        var account = new Account
        {
            Id = JiffyGuid.NewId(),
            Title = Faker.Company.Name(),
            AccountNumber = Faker.RandomNumber.Next(100000, 999999).ToString(),
            IsActive = true,
            CreateDate = DateTime.Now,
            UpdateDate = DateTime.Now
        };

        var customer = new Customer
        {
            Id = JiffyGuid.NewId(),
            ParentId = account.Id,
            FirstName = Faker.Name.First(),
            LastName = Faker.Name.Last(),
            EmailAddress = Faker.Internet.Email(),
            DateOfBirth = Faker.Identification.DateOfBirth(),
            CreateDate = DateTime.Now,
            UpdateDate = DateTime.Now
        };

        _coreDbContext.Accounts.Add(account);
        _coreDbContext.SaveChanges();

        var response = httpClient.PostAsJsonAsync("/customer", customer).Result;

        Assert.True(response.IsSuccessStatusCode);
        Assert.True(response.StatusCode == System.Net.HttpStatusCode.Created);

    }
}
