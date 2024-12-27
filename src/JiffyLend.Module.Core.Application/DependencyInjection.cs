namespace JiffyLend.Module.Core.Application;
using JiffyLend.Core.Infrastructure.Extensions;

using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddModuleCoreServices(this IServiceCollection services)
    {
        services.AddEndpoints(typeof(DependencyInjection).Assembly);
        return services;
    }
}
