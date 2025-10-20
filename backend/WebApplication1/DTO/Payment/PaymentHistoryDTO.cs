namespace WebApplication1.DTO.Payment
{
    public class PaymentHistoryDTO
    {
        public int PaymentId { get; set; }

        public string SenderName {  get; set; }

        public string ReceiverName { get; set; }

        public double Amount { get; set; }

        public DateOnly Date {  get; set; }


    }
}
