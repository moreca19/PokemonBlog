using PokemonBlog.Dto;
using PokemonBlog.Data;
using PokemonBlog.Interfaces;
using PokemonBlog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace PokemonBlog.Services
{
    public class UserService : IUserService
    {
        private readonly PokemonContext _context;
        public UserService(PokemonContext context) 
        {

            _context = context;
        }

        public void NewUser(UserDto user) 
        {
            string name = user.Name;
            string Email = user.Email;
            string Username = user.UserName;
            string DateOfBirth = user.DateOfBirth;
            DateTime UserCreated = DateTime.UtcNow;
            DateTime UserModified = DateTime.UtcNow;

            var NewUser = new User
            {
                Name = name,
                UserName = Username,
                Email = Email,
                DateOfBirth = DateOfBirth,
                CreatedDate = UserCreated,
                UpdatedDate = UserModified
            };

            _context.Users.Add(NewUser);
            _context.SaveChanges();


             

        
        }
    }
}
