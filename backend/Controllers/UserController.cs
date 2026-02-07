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
        public async Task<IActionResult> NewUser([FromBody] UserDto dto)
        {
           await _userService.NewUser(dto);
           return Ok();
        }
        [HttpPost("CheckLogin")]
        public async Task<IActionResult> CheckLogin([FromBody] UserSignIn userSignIn)
        {
            await _userService.CheckLogin(userSignIn) ;
            return Ok();
        }
    }
}
