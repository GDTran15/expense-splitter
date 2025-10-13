using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DTO.User;
using WebApplication1.Model;
using WebApplication1.Service;

namespace WebApplication1.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;


        public UserController(UserService userService)
        {
            _userService = userService;
        }

      

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterRequestDTO requestDTO)// [fromRoute] when in path
        {
            await _userService.CreateNewUser(requestDTO);

            return Ok("User succesfully created");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTORequest loginDTO)
        {
            var res = await _userService.login(loginDTO);
            return Ok(res);
        }

    }
}
