using System;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace DatabaseCore.Registration;

public static class ServiceRegistrar
{
    public static IServiceCollection AddDatabaseCore(this IServiceCollection services, params Assembly[] assemblies)
    {
        var databaseInterfaces = new[]
        {
            typeof(IGetQuery<>),
            typeof(IGetQuery<,>),
            typeof(ISaveCommand<>),
            typeof(ISaveCommand<,>)
        };

        var modules = assemblies
            .SelectMany(assembly => assembly.DefinedTypes)
            .Where(type => type is { IsInterface: false, IsAbstract: false }
                && type.GetInterfaces().Any(interfaceType =>
                    IsDatabaseInterfaces(interfaceType, databaseInterfaces)));

        foreach (var module in modules)
        {
            var interfaceType = module.GetInterfaces().FirstOrDefault(interfaceType =>
                !IsDatabaseInterfaces(interfaceType, databaseInterfaces));

            if (interfaceType is null)
            {
                var wrongType = module.GetInterfaces().FirstOrDefault(interfaceType =>
                IsDatabaseInterfaces(interfaceType, databaseInterfaces));

                throw new Exception($"Could not find another services type other then {wrongType.Name} with service {module.Name}");
            }

            services.AddScoped(interfaceType, module);
        }

        return services;
    }

    public static bool IsDatabaseInterfaces(Type interfaceType, Type[] databaseInterfaces) =>
        interfaceType.IsGenericType
        && databaseInterfaces.Any(databaseInterface =>
            databaseInterface.IsAssignableFrom(interfaceType.GetGenericTypeDefinition()));
}