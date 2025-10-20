namespace WebApplication1.DTO.Expense
{
    public class ExpenseReceiveByOtherResponseDTO
    {
        public int ExpenseId { get; set; }
        public double ExpenseAmount { get; set; }
        public DateOnly ExpenseDate { get; set; }
        public int UserId { get; set; }

        public string OwnerName { get; set; }
        public string ExpenseName { get; set; }
        public int ShareRequestId { get; set; }

        public double AmountToPay { get; set; }
        public bool? RequestAccept {  get; set; }
        
    }
}
