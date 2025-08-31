namespace MediatRaptor.Mediator.Abstractions
{
    /// <summary>
    /// Represents the result of handling a request, wrapping either a value or an error.
    /// </summary>
    /// <typeparam name="T">The type of the response value.</typeparam>
    public sealed class Response<T>
    {
        /// <summary>
        /// Indicates whether the request was successful.
        /// </summary>
        public bool IsSuccess { get; }

        /// <summary>
        /// The response value if the request was successful.
        /// </summary>
        public T? Value { get; }

        /// <summary>
        /// The error message if the request failed.
        /// </summary>
        public string? Error { get; }

        private Response(bool isSuccess, T? value, string? error)
        {
            IsSuccess = isSuccess;
            Value = value;
            Error = error;
        }

        /// <summary>
        /// Creates a successful response with the given value.
        /// </summary>
        public static Response<T> Success(T value) =>
            new Response<T>(true, value, null);

        /// <summary>
        /// Creates a failed response with the given error message.
        /// </summary>
        public static Response<T> Failure(string error) =>
            new Response<T>(false, default, error);

        /// <summary>
        /// Implicitly converts a value into a successful response.
        /// </summary>
        public static implicit operator Response<T>(T value) => Success(value);

        public override string ToString() =>
            IsSuccess ? $"Success: {Value}" : $"Failure: {Error}";
    }
}
