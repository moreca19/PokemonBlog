using Microsoft.Identity.Client;
using PokemonBlog.Models;

namespace PokemonBlog.Dto
{
    public class UserDto
    {

        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string DateOfBirth { get; set; }

    }

    public class UserSignIn
    {
        public string Password { get; set; }
        public string Email { get; set; }
       

    }

    public class UpdateUserName
    {
        public string Email { get; set; }
        public string NewUserName { get; set; }
    }

    public class UpdatePassword
    {
        public string Email { get; set; }
        public string NewPassword { get; set; }
    }
}
