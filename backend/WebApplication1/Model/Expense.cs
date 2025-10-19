using WebApplication1.Enums;

namespace WebApplication1.Model
{
    public class Expense
    {
        public int ExpenseId { get; set; }

        public string ExpenseName { get; set; }

        public double ExpenseAmount { get; set; }

        public DateOnly ExpenseDate { get; set; }

        public string? ImageData { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public Status ExpenseStatus{ get; set; }

        public List<ShareRequest> ShareRequests { get; set; }

        public List<Payment> Payments { get; set; }
    }
}
