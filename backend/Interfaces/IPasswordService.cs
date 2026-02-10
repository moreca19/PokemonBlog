using PokemonBlog.Models;
using PokemonBlog.Dto;

namespace PokemonBlog.Interfaces
{
    public interface IPasswordService
    {
        public string Hash(string password);
        
        bool Verify (string password, string passwordHash);
    }
}
