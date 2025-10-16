
using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Mvc;
using WebApplication1.Service;
using WebApplication1.DTO.Group;

namespace WebApplication1.Controllers
{
    [Route("/group")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly GroupService _groupService;


        public GroupController(GroupService groupService)
        {
            _groupService = groupService;
        }

        [HttpPost] 
        public async Task<IActionResult> createGroup([FromBody]AddGroupRequestDTO  addGroupRequestDTO)
        {
            await _groupService.CreateANewGroup(addGroupRequestDTO);

            return Ok("Group successfully created");

        }

        [HttpGet]
        public async Task<IActionResult> GetGroupList([FromQuery] int userId)
        {
           var groupList = await _groupService.GetAllGroupOfUser(userId);
            return Ok(groupList);
        }

        [HttpGet("/group/{groupId}/members")]
        public async Task<IActionResult> GetGroupMember([FromRoute] int groupId)
        {
            var groupMembers = await _groupService.GetGroupMember(groupId);
            return Ok(groupMembers);
        }


        [HttpPost("/group/{groupId}/members")]
        public async Task<IActionResult> AddMemberIntoGroup([FromRoute] int groupId, [FromQuery] string username)
        {
            await _groupService.AddMemberIntoGroup(groupId, username);

            return Ok($"You have successfully add {username}");
        }

    }
}
