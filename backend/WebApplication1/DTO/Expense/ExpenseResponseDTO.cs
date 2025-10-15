namespace WebApplication1.DTO.User
{
    public class ExpenseResponseDTO
    {
        public int ExpenseId { get; set; }
        public double ExpenseAmount { get; set; }
        public DateTimeOffset ExpenseDate { get; set; }
        public int UserId { get; set; }

        //do image later
    }
}
