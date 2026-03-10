namespace PokemonBlog.Exceptions;

/// <summary>
/// Base for exceptions that map to a specific HTTP status code (4xx).
/// Handled by global exception middleware so they are not returned as 500.
/// </summary>
public abstract class ApiException : Exception
{
    public int StatusCode { get; }

    protected ApiException(string message, int statusCode)
        : base(message)
    {
        StatusCode = statusCode;
    }
}
