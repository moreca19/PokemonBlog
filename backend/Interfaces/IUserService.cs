using PokemonBlog.Models;
using PokemonBlog.Dto;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace PokemonBlog.Interfaces
{
    public interface IUserService
    {

        Task NewUser(UserDto userDto);
        Task<User?> GetByEmail(string email);
        public Task<User> CheckLogin(UserSignIn userSignIn);

    }
}
