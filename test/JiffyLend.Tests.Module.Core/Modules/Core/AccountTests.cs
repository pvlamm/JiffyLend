namespace JiffyLend.Tests.Module.Core.Modules.Core;
using System.Net.Http.Json;

using JiffyLend.Module.Core.Application.Common.Models;
using JiffyLend.Tests.Core.Modules;


[Collection("TestContainers")]
public class AccountTests
{
    private readonly ModuleTestBase _testBase;

    public AccountTests(ModuleTestBase testBase)
    {
        _testBase = testBase;
    }

    [Fact]
    public async Task CreateAccountCommandHandler_ShouldCreateAccount()
    {
        var httpClient = _testBase.Factory.CreateClient();

        var account = new CreateAccount
        {
            Title = "JiffyLend Test Account, LLC.",
        };

        var response = await httpClient.PostAsJsonAsync("/account", account);

        Assert.True(response.IsSuccessStatusCode);
        Assert.Equal(response.StatusCode, System.Net.HttpStatusCode.Created);

    }
}
