using WebApplication1.Enums;

namespace WebApplication1.DTO.ShareRequest
{
    public class ShareRequestUserStatusDTOResponse
    {
        public string Username { get; set; }

        public int UserId { get; set; }

        public bool? IsAccepted { get; set; }


    }
}
