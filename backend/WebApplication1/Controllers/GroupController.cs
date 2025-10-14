
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
        public async Task<IActionResult> createGroup([FromBody ]AddGroupRequestDTO  addGroupRequestDTO)
        {
            await _groupService.createANewGroup(addGroupRequestDTO);

            return Ok("Group successfully created");

        }
    

    }
}
