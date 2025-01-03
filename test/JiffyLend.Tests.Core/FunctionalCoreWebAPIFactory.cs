namespace JiffyLend.Tests.Core;

using JiffyLend.Tests.Core.Fixtures;

using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

public class FunctionalCoreWebAPIFactory : WebApplicationFactory<Program>, IDisposable
{
    public readonly MsSqlFixture DatabaseFixture = new();
    public readonly RabbitMQFixture MessagingFixture = new ();

    protected override IHost CreateHost(IHostBuilder builder)
    {
        Task.WaitAll(
            DatabaseFixture.InitializeAsync(),
            MessagingFixture.InitializeAsync());

        builder.ConfigureHostConfiguration(config =>
        {
            config.AddJsonFile(
                Path.Combine(Environment.CurrentDirectory, "appsettings.Tests.json"), 
                        false, 
                        true);
        });

        return base.CreateHost(builder);
    }

    public new void Dispose()
    {
        Task.WaitAll(
            DatabaseFixture.DisposeAsync(),
            MessagingFixture.DisposeAsync());

        base.Dispose();
    }

}
