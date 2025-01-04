namespace JiffyLend.Tests.Module.Core.Modules.Card;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JiffyLend.Tests.Core;
using JiffyLend.Tests.Core.Modules;

public class AccountTests : ModuleTestBase
{
    public AccountTests(FunctionalCoreWebAPIFactory webAPIFactory) 
        : base(webAPIFactory)
    {
    }

    public void CreateAccountCommandHandler_ShouldCreateAccount()
    {
        // Arrange
        var accountService = new Mock<IAccountService>();
        var publish = new Mock<IPublishEndpoint>();
        var handler = new CreateAccountCommandHandler(accountService.Object, publish.Object);
        var command = new CreateAccountCommand
        {
            Title = "Test Account",
            CustomerId = Guid.NewGuid()
        };
        // Act
        var result = await handler.Handle(command, CancellationToken.None);
        // Assert
        Assert.NotNull(result);
        Assert.Equal(command.Title, result.Value);
    }
}
