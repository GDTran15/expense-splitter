using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DTO.Friend;
using WebApplication1.Model;
using WebApplication1.Service;

namespace WebApplication1.Controllers
{
    [Route("/friend")]
    [ApiController]
    public class FriendController : ControllerBase
    {
        private readonly FriendService _friendService;

        public FriendController(FriendService friendService)
        {
            _friendService = friendService;
        }

        //add friend
        [HttpPost]
        public async Task<IActionResult> AddFriend([FromQuery] int userID, [FromBody] AddFriendRequestDTO requestDTO)
        {
            await _friendService.AddFriend(userID, requestDTO);

            return Ok("Friend added successfully.");
        }

        //remove friend
        [HttpPost("delete")]
        public async Task<IActionResult> RemoveFriend([FromQuery] int userId, [FromQuery] int friendId)
        {
            var removed = await _friendService.RemoveFriend(userId, friendId);

            return Ok(new  { removed });
        }

        [HttpGet]
        public async Task<IActionResult> GetByUser([FromQuery] int userId)
        {
            var friendsList = await _friendService.GetFriendsByUser(userId);
             
            return Ok(friendsList);
        }

    }
}