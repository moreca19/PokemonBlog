using PokemonBlog.Models;
using PokemonBlog.Dto;

namespace PokemonBlog.Interfaces
{
    public interface IPasswordInterface
    {
        public string Hash(string password);
        
        bool Verify (string password, string passwordHash);
    }
}
