//using Microsoft.AspNetCore.Mvc;
//using WebApplication1.DTO.ShareRequest;
//using WebApplication1.Service;

//namespace WebApplication1.Controllers
//{
//    [Route("/share-request")]
//    [ApiController]
//    public class ShareRequestController : ControllerBase
//    {
//        private readonly ShareRequestService _shareRequestService;

//        public ShareRequestController(ShareRequestService shareRequestService)
//        {
//            _shareRequestService = shareRequestService;
//        }

<<<<<<< HEAD
        //[HttpPost]
        //public async Task<IActionResult> CreateAddRequest(AddShareRequestDTO addShareRequestDTO)
        //{
        //    await _shareRequestService.AddShareRequest(addShareRequestDTO);
        //    return Ok();
        //}

        //[HttpPost("share-request/{shareRequestId}")]
        //public async Task<IActionResult> ReplyForThShareRequest([FromBody]ShareRequestReplyDTORequest shareRequestReplyDTORequest, [FromRoute] int shareRequestId)
        //{
        //    await _shareRequestService.UpdateUserResponseForShareRequest(shareRequestReplyDTORequest, shareRequestId);
        //    return Ok();
        //}

        [HttpPut ("/share-request/{shareRequestId}")]
        public async Task<IActionResult> UpdateAccept(UpdateShareRequestUserDTO updateShareRequestUserDTO,[FromRoute] int shareRequestId)
        {
            await _shareRequestService.UpdateUserResponseForShareRequest(updateShareRequestUserDTO, shareRequestId);
            return Ok();
        }
    }
}
=======
//        [HttpPost]
//        public async Task<IActionResult> CreateAddRequest(AddShareRequestDTO addShareRequestDTO)
//        {
//            await _shareRequestService.AddShareRequest(addShareRequestDTO);
//            return Ok();
//        }

//        [HttpPost("share-request/{shareRequestId}")]
//        public async Task<IActionResult> ReplyForThShareRequest([FromBody]ShareRequestReplyDTORequest shareRequestReplyDTORequest, [FromRoute] int shareRequestId)
//        {
//            await _shareRequestService.UpdateUserResponseForShareRequest(shareRequestReplyDTORequest, shareRequestId);
//            return Ok();
//        }
//    }
//}
>>>>>>> a2ae379a183e281a088a27d9b8c23a21d74a149d
