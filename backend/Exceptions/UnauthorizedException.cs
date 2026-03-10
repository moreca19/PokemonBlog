using Microsoft.AspNetCore.Http;

namespace PokemonBlog.Exceptions;

/// <summary>Maps to HTTP 401 Unauthorized (e.g. wrong credentials).</summary>
public class UnauthorizedException : ApiException
{
    public UnauthorizedException(string message)
        : base(message, StatusCodes.Status401Unauthorized)
    {
    }
}
