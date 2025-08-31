namespace MediatRaptor.Mediator.Abstractions
{
    // <summary>
    /// Represents a void type for requests that do not return a value.
    /// </summary>
    public readonly struct Unit : IEquatable<Unit>
    {
        public static readonly Unit Value = new Unit();

        public bool Equals(Unit other) => true;
        public override bool Equals(object? obj) => obj is Unit;
        public override int GetHashCode() => 0;
        public override string ToString() => "()";
    }
}
