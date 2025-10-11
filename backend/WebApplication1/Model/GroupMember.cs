namespace WebApplication1.Model
{
    public class GroupMember
    {
        public int GroupId { get; set; }

        public int MemberId { get; set; }

        public Group Group { get; set; }

        public User Member { get; set; }
    }
}
