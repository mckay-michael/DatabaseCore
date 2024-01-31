using System;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace DatabaseCore.Registration;

public static class ServiceRegistrar
{
    public static IServiceCollection AddDatabaseCore(this IServiceCollection services, Assembly assembly)
    {
        var databaseInterfaces = new[]
        {
            typeof(IGetQuery<>),
            typeof(IGetQuery<,>),
            typeof(ISaveCommand<>),
            typeof(ISaveCommand<,>)
        };

        var modules = assembly.DefinedTypes
            .Where(type => type is { IsInterface: false, IsAbstract: false }
                && type.GetInterfaces().Any(interfaceType =>
                    IsDatabaseInterfaces(interfaceType, databaseInterfaces)));

        foreach (var module in modules)
        {
            var interfaceType = module.GetInterfaces().First(interfaceType =>
                IsDatabaseInterfaces(interfaceType, databaseInterfaces));

            services.AddScoped(interfaceType, module);
        }

        return services;
    }

    public static bool IsDatabaseInterfaces(Type interfaceType, Type[] databaseInterfaces) =>
        interfaceType.IsGenericType
        && databaseInterfaces.Any(databaseInterface =>
            databaseInterface.IsAssignableFrom(interfaceType.GetGenericTypeDefinition()));
}