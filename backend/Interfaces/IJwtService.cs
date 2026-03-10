using PokemonBlog.Models;

namespace PokemonBlog.Interfaces;

public interface IJwtService
{
    string GenerateToken(User user);
}
