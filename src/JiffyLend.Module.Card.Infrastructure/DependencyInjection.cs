namespace JiffyLend.Module.Card.Infrastructure;

using JiffyLend.Module.Card.Application.Common.Interfaces;
using JiffyLend.Module.Card.Infrastructure.Persistence;
using JiffyLend.Module.Card.Infrastructure.Services;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddModuleCardInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Card");

        services.AddDbContext<CardDbContext>((sp, options) =>
        {
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());

            options.UseSqlServer(connectionString);
        });

        services.AddScoped<ICardDbContext>(provider => provider.GetRequiredService<CardDbContext>());

        services.AddTransient<ICardService, CardService>();
        services.AddTransient<ITransactionService, TransactionService>();

        return services;
    }
}