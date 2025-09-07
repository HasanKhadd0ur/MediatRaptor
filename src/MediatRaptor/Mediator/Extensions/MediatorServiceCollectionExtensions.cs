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
        public static IServiceCollection AddMediatRaptor(this IServiceCollection services, params Assembly[] assemblies)
        {
            services.AddScoped<IMediator, Mediator>();
            services.AddScoped<ServiceFactory>(sp => t => sp.GetService(t)!);

            // Register all handlers
            foreach (var assembly in assemblies)
            {
                services.Scan(scan => scan
                    .FromAssemblies(assembly)
                    .AddClasses(classes => classes.AssignableTo(typeof(IRequestHandler<,>)))
                    .AsImplementedInterfaces()
                    .WithScopedLifetime());

                services.Scan(scan => scan
                    .FromAssemblies(assembly)
                    .AddClasses(classes => classes.AssignableTo(typeof(INotificationHandler<>)))
                    .AsImplementedInterfaces()
                    .WithScopedLifetime());

                services.Scan(scan => scan
                    .FromAssemblies(assembly)
                    .AddClasses(classes => classes.AssignableTo(typeof(IPipelineBehavior<,>)))
                    .AsImplementedInterfaces()
                    .WithScopedLifetime());
            }

            return services;
        }
    }
}
