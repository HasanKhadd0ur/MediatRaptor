using MediatRaptor.Mediator.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace MediatRaptor.Mediator.Core
{
    public static class PipelineExtensions
    {
        /// <summary>
        /// Register an open-generic pipeline behavior implementation (e.g. ValidationBehavior&lt;,&gt;)
        /// as IPipelineBehavior&lt;,&gt;.
        /// </summary>
        public static IServiceCollection AddPipelineBehavior(this IServiceCollection services, Type openGenericBehaviorType)
        {
            if (openGenericBehaviorType == null) throw new ArgumentNullException(nameof(openGenericBehaviorType));


            // ensure openGenericBehaviorType implements IPipelineBehavior<,>
            var iface = openGenericBehaviorType.GetInterfaces();


            services.AddTransient(typeof(IPipelineBehavior<,>), openGenericBehaviorType);
            return services;
        }


        /// <summary>
        /// Generic overload
        /// </summary>
        public static IServiceCollection AddPipelineBehavior<TBehavior>(this IServiceCollection services)
        where TBehavior : class
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(TBehavior));
            return services;
        }
    }
}
