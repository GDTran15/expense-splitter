//using WebApplication1.DTO.ShareRequest;
//using WebApplication1.IRepositories;
//using WebApplication1.Model;

<<<<<<< HEAD
namespace WebApplication1.Service
{
    public class ShareRequestService
    {
        private IShareRequestRepository _shareRequestRepository;
        private IShareRequestUserRepository _shareRequestUserRepository;
        private IExpenseRepository _expenseRepository;
        private IPaymentRepository _paymentRepository;


        public ShareRequestService(IShareRequestRepository shareRequestRepository, IShareRequestUserRepository shareRequestUserRepository,IPaymentRepository paymentRepository )
        {
            _shareRequestRepository = shareRequestRepository;
            _shareRequestUserRepository = shareRequestUserRepository;
            _paymentRepository = paymentRepository;
        }

      

        public async Task UpdateUserResponseForShareRequest(UpdateShareRequestUserDTO updateShareRequestUserDTO, int shareRequestId)
        {
            var shareRequestUser =await _shareRequestUserRepository.GetShareRequestUser(shareRequestId, updateShareRequestUserDTO.UserId);
            if (shareRequestUser == null)
            {
                throw new Exception("Share request user not found.");
            }
            shareRequestUser.Accepted = updateShareRequestUserDTO.IsAccepted;
            shareRequestUser.RequestStatus = Enums.Status.Done;
            await _shareRequestUserRepository.UpdateShareRequestUser( shareRequestUser );



            if(shareRequestUser.Accepted == true)
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
                await _paymentRepository.AddPayment( payment );
            }
            
            //var isAllUserHaveResponseShareRequest = await _shareRequestUserRepository.CheckIfEveryRequestHaveBeenReply(shareRequestId);
            //if (isAllUserHaveResponseShareRequest)
            //{
           
            //}
=======
//namespace WebApplication1.Service
//{
//    public class ShareRequestService
//    {
//        private IShareRequestRepository _shareRequestRepository;
//        private IShareRequestUserRepository _shareRequestUserRepository;

//        public ShareRequestService(IShareRequestRepository shareRequestRepository, IShareRequestUserRepository shareRequestUserRepository)
//        {
//            _shareRequestRepository = shareRequestRepository;
//            _shareRequestUserRepository = shareRequestUserRepository;
//        }

//        public async Task AddShareRequest(AddShareRequestDTO addShareRequestDTO)
//        {
//           ShareRequest shareRequest = new ShareRequest
//           {
//               ExpenseId = addShareRequestDTO.ExpenseId,
//               UserId  = addShareRequestDTO.OwnerId,
//               CreateBy = DateOnly.FromDateTime(DateTime.Now)
//           };
//           await _shareRequestRepository.AddShareRequest(shareRequest);

//            var shareUserList = addShareRequestDTO.ShareUserIdList.ToList();

//            foreach (var userId in shareUserList)
//            {
//                ShareRequestUser shareRequestUser = new ShareRequestUser
//                {
//                    ShareRequestId = shareRequest.ShareRequestId,
//                    UserId = userId,
//                    Accepted = false,
//                    RequestStatus = Enums.Status.Pending
//                };
//            }

//        }

//        public async Task UpdateUserResponseForShareRequest(ShareRequestReplyDTORequest shareRequestReplyDTORequest, int shareRequestId)
//        {
//            var shareRequestUser =await _shareRequestUserRepository.GetShareRequestUser(shareRequestId, shareRequestReplyDTORequest.UserId);
//            shareRequestUser.Accepted = shareRequestReplyDTORequest.IsAccepted;
//            shareRequestUser.RequestStatus = Enums.Status.Done;
//            await _shareRequestUserRepository.UpdateShareRequestUser( shareRequestUser );
            
//            var isAllUserHaveResponseShareRequest = await _shareRequestUserRepository.CheckIfEveryRequestHaveBeenReply(shareRequestId);
//            if (isAllUserHaveResponseShareRequest)
//            {

//            }
>>>>>>> a2ae379a183e281a088a27d9b8c23a21d74a149d
                
//       }
//    }
//}
