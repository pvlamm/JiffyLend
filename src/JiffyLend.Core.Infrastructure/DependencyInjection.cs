namespace JiffyLend.Core.Infrastructure;

using System;
using System.Reflection;

using FluentValidation;

using JiffyLend.Core.Common;
using JiffyLend.Core.Common.Interfaces;
using JiffyLend.Core.Infrastructure.Interfaces;
using JiffyLend.Core.Infrastructure.Security.Behaviors;

using MediatR;

using Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Handles the wireups for JiffyLand.Core and
/// JiffyLand.Core.Infrastructure
/// </summary>
public static class DependencyInjection
{
    public static IServiceCollection AddCoreInfrastructure(this IServiceCollection services)
    {
        Assembly[] assemblies = AppDomain.CurrentDomain
    .GetAssemblies()
    .Where(a => a.FullName.Contains("Application"))
    .ToArray();

        services.AddValidatorsFromAssemblies(assemblies);
        services.AddMediatR(cfg => {
            cfg.RegisterServicesFromAssemblies(assemblies);
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<>));
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehavior<,>));
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(PerformanceBehavior<,>));
        });

        services.AddSingleton<IDateTime, JiffyTime>();
        services.AddTransient<IUser, User>();

        return services;
    }
}

/// <summary>
/// This is a glorified Testing Experiment
/// So we are hard setting this because shorterm, 
/// we are ignoring Security Concerns
/// </summary>
public class User : IUser
{
    public Guid Id => Guid.Parse("B987B5E1-10AB-40D2-8470-444BB9086A77");

    public string DisplayName => "Steve Ledbetter";

    public string EmailAddress => "steve.ledbetter@jiffylend.com";
}