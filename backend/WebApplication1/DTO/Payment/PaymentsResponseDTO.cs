using WebApplication1.Enums;

namespace WebApplication1.DTO.Payment
{
    public class PaymentsResponseDTO
    {
        public int PaymentId { get; set; }

        public string ExpenseName { get; set; }

        public string SenderUsername { get; set; }
       
        public string ReceiverUsername { get; set; }
        public double Amount { get; set; }
      
    }
}
