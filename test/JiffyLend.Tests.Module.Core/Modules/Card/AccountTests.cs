namespace JiffyLend.Tests.Module.Core.Modules.Card;
using System;
using System.Net.Http.Json;

using JiffyLend.Tests.Core;
using JiffyLend.Tests.Core.Modules;

public class AccountTests : ModuleTestBase, IClassFixture<FunctionalCoreWebAPIFactory>
{
    public AccountTests(FunctionalCoreWebAPIFactory webAPIFactory) 
        : base(webAPIFactory)
    {
    }

    [Fact]
    public void CreateAccountCommandHandler_ShouldCreateAccount()
    {
        var httpClient = _webAPIFactory.CreateClient();

        var response = httpClient.PostAsJsonAsync("/api/account", new
        {
            Title = "Test Account",
            CustomerId = Guid.NewGuid()
        }).Result;

        Console.WriteLine(response.Content.ReadAsStringAsync().Result);
    }
}
