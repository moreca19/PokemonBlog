using PokemonBlog.Models;
using PokemonBlog.Dto;

namespace PokemonBlog.Interfaces
{
    public interface IUserService
    {

        void NewUser(UserDto userDto);

    }
}
