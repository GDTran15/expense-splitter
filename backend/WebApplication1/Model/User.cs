namespace WebApplication1.Model
{
    public class User
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public List<Friend> FriendList { get; set; }
        public List<GroupMember> GroupList { get; set; }

        public List<Expense> ExpenseList { get; set; }
    }
}
