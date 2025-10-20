using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DTO.Payment;
using WebApplication1.IRepositories;
using WebApplication1.Model;

namespace WebApplication1.Repositories
{
    public class PaymentRepository : IPaymentRepository

       
    {
        private readonly AppDbContext appDbContext;

        public PaymentRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task AddPayment(Payment paymment)
        {
            await appDbContext.Payments.AddAsync(paymment);
            await appDbContext.SaveChangesAsync();
        }

        public async Task<bool> AllPaymentStatusIsDone(int expenseId)
        {
            return await appDbContext.Payments.Where(e => e.ExpenseId == expenseId)
                .AllAsync(e => e.PaymentStatus == Enums.Status.Done);
        }

        public async Task<Payment> GetPaymentById(int paymentId)
        {
            return await appDbContext.Payments.Where(e => e.PaymentId == paymentId).FirstOrDefaultAsync();   
        }

       

        public async Task<List<PaymentsResponseDTO>> GetPaymentList(int userId)
        {
            var payments = await (from payment  in appDbContext.Payments
                                  join expense in appDbContext.Expenses on payment.ExpenseId equals expense.ExpenseId
                                  join sender in appDbContext.Users on payment.SenderUserId equals sender.UserId
                                  join receiver in appDbContext.Users on payment.ReceiverUserId equals receiver.UserId
                                  where payment.PaymentStatus == Enums.Status.Pending && payment.SenderUserId == userId
                                  select new PaymentsResponseDTO
                                  {
                                      Amount = payment.Amount,
                                      ReceiverUsername = receiver.Username,
                                      SenderUsername = sender.Username,
                                      ExpenseName = expense.ExpenseName,
                                      PaymentId = payment.PaymentId,
                                  }).ToListAsync(); 
            return payments;
        }

        public async Task UpdatePayement(Payment paymment)
        {
            appDbContext.Update(paymment);
           await appDbContext.SaveChangesAsync();
        }
    }
}
