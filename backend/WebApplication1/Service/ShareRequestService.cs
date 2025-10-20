using WebApplication1.DTO.ShareRequest;
using WebApplication1.IRepositories;
using WebApplication1.Model;

namespace WebApplication1.Service
{
    public class ShareRequestService
    {
        private IShareRequestRepository _shareRequestRepository;
        private IShareRequestUserRepository _shareRequestUserRepository;
        private IExpenseRepository _expenseRepository;
        private IPaymentRepository _paymentRepository;


        public ShareRequestService(IShareRequestRepository shareRequestRepository, IShareRequestUserRepository shareRequestUserRepository, IPaymentRepository paymentRepository)
        {
            _shareRequestRepository = shareRequestRepository;
            _shareRequestUserRepository = shareRequestUserRepository;
            _paymentRepository = paymentRepository;
        }



        public async Task UpdateUserResponseForShareRequest(UpdateShareRequestUserDTO updateShareRequestUserDTO, int shareRequestId)
        {
            var shareRequestUser = await _shareRequestUserRepository.GetShareRequestUser(shareRequestId, updateShareRequestUserDTO.UserId);
            if (shareRequestUser == null)
            {
                throw new Exception("Share request user not found.");
            }
            shareRequestUser.Accepted = updateShareRequestUserDTO.IsAccepted;
            shareRequestUser.RequestStatus = Enums.Status.Done;
            await _shareRequestUserRepository.UpdateShareRequestUser(shareRequestUser);



            if (shareRequestUser.Accepted == true)
            {
                Payment payment = new Payment()
                {
                    ExpenseId = updateShareRequestUserDTO.ExpenseId,
                    SenderUserId = updateShareRequestUserDTO.UserId,
                    ReceiverUserId = updateShareRequestUserDTO.ExpenseOwnerId,
                    Amount = updateShareRequestUserDTO.AmountToPay,
                    PaidAt = DateOnly.FromDateTime(DateTime.Now),
                    PaymentStatus = Enums.Status.Pending
                };
                await _paymentRepository.AddPayment(payment);
            }
        }

        public async Task<List<ShareRequestUserStatusDTOResponse>> GetShareRequestUserStatus(int shareRequestId)
        {
            return await _shareRequestUserRepository.GetShareRequestUserAcceptStatus(shareRequestId);
        }
    }
}