namespace WebApplication1.Model
{
    public class Expense
    {
        public int ExpenseId { get; set; }

        public double ExpenseAmount { get; set; }

        public DateTimeOffset ExpenseDate { get; set; }

        public byte[] ImageData { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public List<ShareRequest> ShareRequests { get; set; }

        public List<Payment> Payments { get; set; }
    }
}
