using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Model;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetUser")]
        public async Task<IActionResult> GetUser()
        {
            var result = await _context.Users.Select(x => new User
            {
                UserId = x.UserId,
                Name = x.Name,
                Username = x.Username,
                Email = x.Email,
                Password = x.Password,
                Phone = x.Phone,

            }).ToListAsync();

            return Ok(result);
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();  
            return Ok(user);
        }


    }
}
