namespace WebApplication1.Model
{
    public class ShareRequest
    {
        public int ShareRequestId { get; set; }

        public int ExpenseId { get; set; }

        public Expense Expense { get; set; }

        public int UserId { get; set; }

        public User ShareOwner { get; set; }

        public List<ShareRequestUser> ListSharerequestUser { get; set; }
    }
}
