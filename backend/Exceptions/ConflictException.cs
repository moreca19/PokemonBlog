using Microsoft.AspNetCore.Http;

namespace PokemonBlog.Exceptions;

/// <summary>Maps to HTTP 409 Conflict (e.g. duplicate resource).</summary>
public class ConflictException : ApiException
{
    public ConflictException(string message)
        : base(message, StatusCodes.Status409Conflict)
    {
    }
}
