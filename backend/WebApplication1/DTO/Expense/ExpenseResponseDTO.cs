namespace WebApplication1.DTO.Expense
{
    public class ExpenseResponseDTO
    {
        public int ExpenseId { get; set; }
        public double ExpenseAmount { get; set; }
        public DateOnly ExpenseDate { get; set; }
        public int UserId { get; set; }

        public string OwnerName { get; set; }
        public string ExpenseName { get; set; }

        public bool RequestAccept {  get; set; }
        //do image later
    }
}
