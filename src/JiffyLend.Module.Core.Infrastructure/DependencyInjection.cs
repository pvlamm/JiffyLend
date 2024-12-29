namespace JiffyLend.Module.Core.Infrastructure;

using JiffyLend.Module.Core.Application.Common.Interfaces;
using JiffyLend.Module.Core.Infrastructure.Persistance;
using JiffyLend.Module.Core.Infrastructure.Services;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddModuleCoreInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Core");

        services.AddDbContext<CoreDbContext>((sp, options) =>
        {
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());

            options.UseSqlServer(connectionString);
        });

        services.AddScoped<ICoreDbContext>(provider => provider.GetRequiredService<CoreDbContext>());

        services.AddTransient<IAccountService, AccountService>();
        services.AddTransient<ICustomerService, CustomerService>();
        services.AddTransient<IMemoPostService, MemoPostService>();

        return services;
    }
}