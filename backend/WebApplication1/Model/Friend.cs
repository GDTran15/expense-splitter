namespace WebApplication1.Model
{
    public class Friend
    {
        public int UserId { get; set; }
        public int FriendId { get; set; }

        public User User { get; set; }

        public User UserFriend { get; set; }
    }
}
