namespace JiffyLend.Tests.Core.Modules;

using JiffyLend.Module.Card.Application.Common.Interfaces;
using JiffyLend.Module.Card.Infrastructure.Persistence;
using JiffyLend.Module.Core.Application.Common.Interfaces;
using JiffyLend.Module.Core.Infrastructure.Persistence;

using MassTransit;

using MediatR;

using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

public class ModuleTestBase : IDisposable
{
    private readonly IServiceScope _scope;
    
    public readonly WebApplicationFactory<Program> Factory;
    public readonly ISender Sender;
    public readonly IPublishEndpoint Publisher;
    public readonly CoreDbContext CoreDbContext;
    public readonly CardDbContext CardDbContext;


    public ModuleTestBase()
    {
        Factory = new FunctionalCoreWebAPIFactory();

        _scope = Factory.Services.CreateScope();
        Sender = _scope.ServiceProvider.GetRequiredService<ISender>();
        Publisher = _scope.ServiceProvider.GetRequiredService<IPublishEndpoint>();

        CoreDbContext = _scope.ServiceProvider.GetRequiredService<CoreDbContext>();
        CardDbContext = _scope.ServiceProvider.GetRequiredService<CardDbContext>();

        if (CoreDbContext.Database.GetPendingMigrations().Any())
        {
            CoreDbContext.Database.Migrate();
        }

        if (CardDbContext.Database.GetPendingMigrations().Any())
        {
            CardDbContext.Database.Migrate();
        }
    }

    public void Dispose()
    {
        Factory?.Dispose();
    }
}
