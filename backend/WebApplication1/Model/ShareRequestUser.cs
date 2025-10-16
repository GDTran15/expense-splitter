using WebApplication1.Enums;


namespace WebApplication1.Model
{
    public class ShareRequestUser
    {
        public int ShareRequestId {  get; set; }

        public ShareRequest ShareRequest { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }

        public bool Accepted { get; set; }

        public Status RequestStatus { get; set; }
    }
}
