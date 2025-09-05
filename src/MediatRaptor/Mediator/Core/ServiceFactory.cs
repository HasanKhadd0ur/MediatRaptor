namespace MediatRaptor.Mediator.Core
{
    /// <summary>
    /// DI factory used by the Mediator to resolve handlers & behaviors.
    /// Compatible with constructors taking Func<Type, object?> or equivalent.
    /// </summary>
    public delegate object? ServiceFactory(Type serviceType);

    public static class ServiceFactoryExtensions
    {
        public static T? GetInstance<T>(this ServiceFactory factory, Type requestType) =>
            (T?)factory(typeof(T).IsGenericType ? typeof(T).GetGenericTypeDefinition().MakeGenericType(requestType) : typeof(T));

        public static IEnumerable<T> GetInstances<T>(this ServiceFactory factory, Type requestType) =>
            (IEnumerable<T>)(factory(typeof(IEnumerable<>).MakeGenericType(typeof(T))) ?? Array.Empty<T>());
    }
}
