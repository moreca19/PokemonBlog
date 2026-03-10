using Microsoft.AspNetCore.Authorization;
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
        private readonly IJwtService _jwtService;

        public UserController(IUserService userService, IJwtService jwtService)
        {
            _userService = userService;
            _jwtService = jwtService;
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
            var user = await _userService.CheckLogin(userSignIn);
            var token = _jwtService.GenerateToken(user);
            return Ok(new LoginResponseDto
            {
                Token = token,
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName
            });
        }

        [Authorize]
        [HttpPost("UpdateUserName")]
        public async Task<IActionResult> UpdateUserName([FromBody] UpdateUserName updateUserName)
        {
            await _userService.UpdateUserName(updateUserName);
            return Ok();
        }

        [Authorize]
        [HttpPost("UpdateUserPassword")]
        public async Task<IActionResult> UpdateUserPassword([FromBody] UpdatePassword updatePassword)
        {
            await _userService.UpdateUserPassword(updatePassword);
            return Ok();
        }
    }
}
