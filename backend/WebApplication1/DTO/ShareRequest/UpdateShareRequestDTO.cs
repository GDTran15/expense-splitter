namespace WebApplication1.DTO.ShareRequest
{
    public class UpdateShareRequestUserDTO
    {
       public int ExpenseId { get; set; } 

        public int ExpenseOwnerId { get; set; }

        
        public int UserId { get; set; }

        public bool IsAccepted { get; set; }

        public double AmountToPay { get; set; }
    }
}
