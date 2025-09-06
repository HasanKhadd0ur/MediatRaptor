namespace MediatRaptor.Mediator.Core
{
    /// <summary>
    /// DI factory used by the Mediator to resolve handlers & behaviors.
    /// Compatible with constructors taking Func<Type, object?> or equivalent.
    /// </summary>
    public delegate object? ServiceFactory(Type serviceType);

    public static class ServiceFactoryExtensions
    {
        public static T? GetInstance<T>(this ServiceFactory factory, params Type[] genericTypes)
        {
            var type = typeof(T);

            if (type.IsGenericTypeDefinition)
            {
                type = type.MakeGenericType(genericTypes);
            }

            return (T?)factory(type);
        }

        public static IEnumerable<T> GetInstances<T>(this ServiceFactory factory, params Type[] genericTypes)
        {
            var type = typeof(T);

            if (type.IsGenericTypeDefinition)
            {
                type = type.MakeGenericType(genericTypes);
            }

            var enumerableType = typeof(IEnumerable<>).MakeGenericType(type);
            return (IEnumerable<T>)(factory(enumerableType) ?? Array.Empty<T>());
        }
    }
}
