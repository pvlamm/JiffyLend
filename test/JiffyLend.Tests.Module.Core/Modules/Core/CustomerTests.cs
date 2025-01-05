namespace JiffyLend.Tests.Module.Core.Modules.Core;
using System;
using System.Threading.Tasks;

using JiffyLend.Tests.Core.Modules;
using JiffyLend.Module.Core.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;
using JiffyLend.Module.Core.Domain.Entities;
using JiffyLend.Core.Extensions;
using System.Net.Http.Json;
using JiffyLend.Module.Core.Application.Common.Models;

[Collection("TestContainers")]
public class CustomerTests
{
    private readonly ModuleTestBase _testBase;
    public CustomerTests(ModuleTestBase testBase)
    {
        _testBase = testBase;
    }

    [Fact]
    public async Task CreateCustomer_Succeeds()
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

        var customer = new CreateCustomer
        {
            AccountId = account.Id,
            FirstName = Faker.Name.First(),
            LastName = Faker.Name.Last(),
            EmailAddress = Faker.Internet.Email(),
            DateOfBirth = Faker.Identification.DateOfBirth(),
        };

        await _testBase.CoreDbContext.Accounts.AddAsync(account);
        await _testBase.CoreDbContext.SaveChangesAsync();

        var response = await httpClient.PostAsJsonAsync("/customer", customer);

        Assert.True(response.IsSuccessStatusCode);
        Assert.Equal(response.StatusCode, System.Net.HttpStatusCode.Created);

    }
}
