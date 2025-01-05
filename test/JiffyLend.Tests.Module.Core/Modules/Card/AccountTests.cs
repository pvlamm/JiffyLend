namespace JiffyLend.Tests.Module.Core.Modules.Card;
using System;
using System.Linq;
using System.Threading.Tasks;

using JiffyLend.Core.Extensions;
using JiffyLend.Core.Infrastructure.Messages;
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
    public async Task CreatedAccount_FromCore_ShouldCreateInCard()
    {
        var id = JiffyGuid.NewId();
        await _testBase.Publisher.Publish<ICreatedAnAccount>(new
        {
            Id = id,
            Title = Faker.Name.FullName(),
            ChangeDate = DateTime.UtcNow,
        });

        // Let the consumer have a moment...
        await Task.Delay(1500);

        var accountExists = _testBase.CardDbContext.Accounts.Any(x => x.Id == id);

        Assert.True(accountExists);

    }
}