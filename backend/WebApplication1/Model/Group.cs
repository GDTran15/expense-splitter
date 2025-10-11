namespace WebApplication1.Model
{
    public class Group
    {
        public int GroupId { get; set; }

        public string GroupName { get; set; }

        public DateTimeOffset CreatedDate { get; set; }

        public List<GroupMember> MemberList { get; set; }

    }
}
