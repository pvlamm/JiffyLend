namespace JiffyLend.Tests.Core.Modules;

using JiffyLend.Module.Card.Application.Common.Interfaces;
using JiffyLend.Module.Card.Infrastructure.Persistence;
using JiffyLend.Module.Core.Application.Common.Interfaces;
using JiffyLend.Module.Core.Infrastructure.Persistence;

using MediatR;

using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

// : IClassFixture<FunctionalCoreWebAPIFactory>, 
public class ModuleTestBase : IClassFixture<FunctionalCoreWebAPIFactory>, IDisposable
{
    private readonly IServiceScope _scope;
    
    public readonly WebApplicationFactory<Program> Factory;
    public readonly ISender Sender;
    public readonly CoreDbContext _coreDbContext;
    public readonly CardDbContext _cardDbContext;


    protected ModuleTestBase()
    {
        Factory = new FunctionalCoreWebAPIFactory();
        _scope = Factory.Services.CreateScope();
        Sender = _scope.ServiceProvider.GetRequiredService<ISender>();
        _coreDbContext = _scope.ServiceProvider.GetRequiredService<CoreDbContext>();
        _cardDbContext = _scope.ServiceProvider.GetRequiredService<CardDbContext>();

        if (_coreDbContext.Database.GetPendingMigrations().Any())
        {
            _coreDbContext.Database.Migrate();
        }

        if (_cardDbContext.Database.GetPendingMigrations().Any())
        {
            _cardDbContext.Database.Migrate();
        }
    }

    public void Dispose()
    {
        Factory?.Dispose();
    }
}
