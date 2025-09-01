namespace MediatRaptor.Mediator.Core
{
    internal static class ServiceFactoryExtensions
    {
        public static IEnumerable<object> GetInstances(this ServiceFactory factory, Type sequenceType)
        {
            // sequenceType is expected to be IEnumerable<T>
            var type = sequenceType;
            if (factory == null) yield break;


            var resolved = factory(type);
            if (resolved is IEnumerable<object> en)
            {
                foreach (var x in en)
                    yield return x;
            }
            else if (resolved is System.Collections.IEnumerable ien)
            {
                foreach (var obj in ien)
                    yield return obj!;
            }
            else if (resolved != null)
            {
                yield return resolved;
            }
        }
    }
}
