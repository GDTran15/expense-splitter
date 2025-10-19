using WebApplication1.Enums;

namespace WebApplication1.DTO.Expense
{
    public class ExpenseReponseForOwner
    {
        public int ExpenseId { get; set; }
        public double ExpenseAmount { get; set; }
        public DateOnly ExpenseDate { get; set; }

        public string ExpenseName { get; set; }
    
        public Status Status { get; set; }
        public int ShareId { get; set; }

    }
}
