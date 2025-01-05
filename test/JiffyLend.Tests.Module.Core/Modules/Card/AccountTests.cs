namespace JiffyLend.Tests.Module.Core.Modules.Card;
using System;
using System.ComponentModel;
using System.Net.Http.Json;

using JiffyLend.Core.Infrastructure.Models;
using JiffyLend.Module.Core.Application.Common.Models;
using JiffyLend.Tests.Core;
using JiffyLend.Tests.Core.Modules;


public class AccountTests // : ModuleTestBase, IClassFixture<FunctionalCoreWebAPIFactory>
{
    private readonly ModuleTestBase _testBase;
]
    public AccountTests(ModuleTestBase testBase)
    {
        _testBase = testBase;
    }

    [Fact]
    public void CreateAccountCommandHandler_ShouldCreateAccount()
    {
        var httpClient = _testBase.Factory.CreateClient();

        var account = new CreateAccount
        {
            Title = "JiffyLend Test Account, LLC.",
        };

        var response = httpClient.PostAsJsonAsync("/account", account).Result;

        Assert.True(response.IsSuccessStatusCode);
        Assert.True(response.StatusCode == System.Net.HttpStatusCode.Created);

        var accountInfo = response.Content.ReadFromJsonAsync<AccountInfo>().Result;
        Console.WriteLine(response.Content.ReadAsStringAsync().Result);
    }
}
