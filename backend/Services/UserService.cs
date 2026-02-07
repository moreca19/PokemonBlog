using PokemonBlog.Dto;
using PokemonBlog.Data;
using PokemonBlog.Interfaces;
using PokemonBlog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Npgsql.TypeMapping;

namespace PokemonBlog.Services
{
    public class UserService : IUserService
    {
        private readonly PokemonContext _context;
        private readonly IPasswordInterface _password;
        public UserService(PokemonContext context, IPasswordInterface password) 
        {

            _context = context;
            _password = password;
        }

        public async Task NewUser(UserDto user) 
        {
            var UserExist = await GetByEmail(user.Email);
            if (UserExist != null) 
            {
                throw new Exception("User with that email already exists");
            }
            
            DateTime UserCreated = DateTime.UtcNow;
            DateTime UserModified = DateTime.UtcNow;

            var NewUser = new User
            {
                Name = user.Name,
                Password = _password.Hash(user.Password), 
                UserName = user.UserName,
                Email = user.Email,
                DateOfBirth = user.DateOfBirth,
                CreatedDate = UserCreated,
                UpdatedDate = UserModified
            };

            _context.Users.Add(NewUser);
            await _context.SaveChangesAsync();
        }

        public async Task<User?> GetByEmail(string  email) 
        {

            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);        
        }

        public async Task<User> CheckLogin(UserSignIn userSignIn)
        {
            User? user = await GetByEmail(userSignIn.Email);
            if (user == null)
            {
                throw new Exception("The user was not found!");
            }

            bool verified = _password.Verify(userSignIn.Password, user.Password);

            if (!verified)
            {
                throw new Exception("The password is incorrect");

            }
            return user;
        }


    }
}
