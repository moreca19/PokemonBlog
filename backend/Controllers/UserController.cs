using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokemonBlog.Interfaces;
using PokemonBlog.Dto;
using PokemonBlog.Models;
using PokemonBlog.Data;

namespace PokemonBlog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService) 
        {
            _userService = userService;
        }

        [HttpPost("NewUser")]
        public IActionResult AddStudy([FromBody] UserDto dto)
        {
            _userService.NewUser(dto);
            return Ok();
        }
    }
}
