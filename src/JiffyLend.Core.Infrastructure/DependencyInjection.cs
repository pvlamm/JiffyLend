namespace JiffyLend.Core.Infrastructure;

using JiffyLend.Core.Common.Interfaces;
using JiffyLend.Core.Common;
using Microsoft.Extensions.DependencyInjection;
using JiffyLend.Core.Infrastructure.Interfaces;
using System;

/// <summary>
/// Handles the wireups for JiffyLand.Core and
/// JiffyLand.Core.Infrastructure
/// </summary>
public static class DependencyInjection
{
    public static IServiceCollection AddCoreInfrastructure(this IServiceCollection services)
    {
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