using WebApplication1.DTO.Payment;
using WebApplication1.IRepositories;
using WebApplication1.Model;

namespace WebApplication1.Service
{
    public class PaymentService

    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IUserRepository _userRepository;
        private readonly IExpenseRepository _expenseRepository;

        public PaymentService(IPaymentRepository paymentRepository, IUserRepository userRepository, IExpenseRepository expenseRepository)
        {
            _paymentRepository = paymentRepository;
            _userRepository = userRepository;
            _expenseRepository = expenseRepository;
        }

        public async Task<List<PaymentsResponseDTO>> GetPaymentListByUserId(int userId)
        {
            return await _paymentRepository.GetPaymentList(userId);
        }

        public async Task<Payment> FindPaymentById(int paymentId)
        {
            return await _paymentRepository.GetPaymentById(paymentId);
        }

        public async Task PaymentProcess(int paymentId)
        {
            Payment payment = await _paymentRepository.GetPaymentById(paymentId);
            payment.PaymentStatus = Enums.Status.Done;
            User sender = await _userRepository.GetUserByUserId(payment.SenderUserId);
            User receiver = await _userRepository.GetUserByUserId(payment.ReceiverUserId);
            sender.AmountSpend -= payment.Amount;
            receiver.AmountEarn += payment.Amount;

            await _paymentRepository.UpdatePayement(payment);

            if (await _paymentRepository.AllPaymentStatusIsDone(payment.ExpenseId))
            {
                Expense expense = await _expenseRepository.GetByIdAsync(payment.ExpenseId);
                expense.ExpenseStatus = Enums.Status.Done;
            }



        }
    }
}
