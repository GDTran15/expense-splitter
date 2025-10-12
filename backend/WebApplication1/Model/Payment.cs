namespace WebApplication1.Model
{
    public class Payment
    {
        public int PaymentId { get; set; }

        public int ExpenseId { get; set; }

        public Expense Expense { get; set; }

        public int SenderUserId { get; set; }
        public User SenderUser  { get; set; }
        public int ReceiverUserId { get; set; }

        public User ReceiverUser { get; set; }
        public double Amount { get; set; }

        public DateTimeOffset PaidAt { get; set; }
    }
}
