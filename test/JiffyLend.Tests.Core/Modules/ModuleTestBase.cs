namespace JiffyLend.Tests.Core.Modules;

using JiffyLend.Module.Card.Application.Common.Interfaces;
using JiffyLend.Module.Card.Infrastructure.Persistence;
using JiffyLend.Module.Core.Application.Common.Interfaces;
using JiffyLend.Module.Core.Infrastructure.Persistence;

using MediatR;

using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

public abstract class ModuleTestBase
{
    private readonly IServiceScope _scope;
    
    protected readonly WebApplicationFactory<Program> _webAPIFactory;
    protected readonly ISender Sender;
    protected readonly CoreDbContext _coreDbContext;
    protected readonly CardDbContext _cardDbContext;


    protected ModuleTestBase(FunctionalCoreWebAPIFactory webAPIFactory)
    {
        _webAPIFactory = webAPIFactory;

        _scope = _webAPIFactory.Services.CreateScope();
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
}
