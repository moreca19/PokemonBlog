using Microsoft.AspNetCore.Http;

namespace PokemonBlog.Exceptions;

/// <summary>Maps to HTTP 400 Bad Request (e.g. invalid or empty input).</summary>
public class ValidationException : ApiException
{
    public ValidationException(string message)
        : base(message, StatusCodes.Status400BadRequest)
    {
    }
}
