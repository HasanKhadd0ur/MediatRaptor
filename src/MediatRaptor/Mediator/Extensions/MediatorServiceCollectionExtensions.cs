using MediatRaptor.Mediator.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MediatRaptor.Mediator.Core
{
    public static class MediatorServiceCollectionExtensions
    {
        /// <summary>
        /// Registers the Mediator and scans the provided assemblies for handlers.
        /// </summary>
        public static IServiceCollection AddMediatRaptor(this IServiceCollection services, params Assembly[] assembliesToScan)
        {
            // Register service factory used by the Mediator
            services.AddSingleton<ServiceFactory>(sp => sp.GetService);


            // Register Mediator
            services.AddSingleton<IMediator, Mediator>();


            // Register all request handlers and notification handlers discovered in assemblies
            var types = assembliesToScan.SelectMany(a => a.DefinedTypes).Where(t => !t.IsAbstract && !t.IsInterface).ToList();


            foreach (var type in types)
            {
                foreach (var iface in type.ImplementedInterfaces)
                {
                    if (!iface.IsGenericType) continue;
                    var genDef = iface.GetGenericTypeDefinition();
                    if (genDef == typeof(IRequestHandler<,>) || genDef == typeof(IRequestHandler<>))
                    {
                        services.AddTransient(iface, type.AsType());
                    }
                    else if (genDef == typeof(INotificationHandler<>))
                    {
                        services.AddTransient(iface, type.AsType());
                    }
                }
            }


            return services;
        }
    }
}
