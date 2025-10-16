using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTO.ShareRequest;
using WebApplication1.Service;

namespace WebApplication1.Controllers
{
    [Route("/share-request")]
    [ApiController]
    public class ShareRequestController : ControllerBase
    {
        private readonly ShareRequestService _shareRequestService;

        public ShareRequestController(ShareRequestService shareRequestService)
        {
            _shareRequestService = shareRequestService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAddRequest(AddShareRequestDTO addShareRequestDTO)
        {
            await _shareRequestService.AddShareRequest(addShareRequestDTO);
            return Ok();
        }
    }
}
