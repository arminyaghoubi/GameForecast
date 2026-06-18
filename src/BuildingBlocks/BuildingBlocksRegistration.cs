using BuildingBlocks.Messaging;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BuildingBlocks;

public static class BuildingBlocksRegistration
{
    public static IServiceCollection AddMeditor(this IServiceCollection services, params Assembly[] assemblies)
    {
        services.AddScoped<Mediator>();
        services.Scan(scan => scan
            .FromAssemblies(assemblies)
            .AddClasses(c => c.AssignableTo(typeof(IHandler<,>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        return services;
    }
}
