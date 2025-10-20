using WebApplication1.DTO.Payment;
using WebApplication1.Model;

namespace WebApplication1.IRepositories
{
    public interface IPaymentRepository
    {
        Task AddPayment(Payment paymment);
        Task<Payment> GetPaymentById(int paymentId);

        Task<bool> AllPaymentStatusIsDone(int expenseId);

        Task<List<PaymentsResponseDTO>> GetPaymentList(int userId);

        Task UpdatePayement(Payment paymment);
        
        
    }
}
