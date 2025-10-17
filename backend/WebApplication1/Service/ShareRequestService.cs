using WebApplication1.DTO.ShareRequest;
using WebApplication1.IRepositories;
using WebApplication1.Model;

namespace WebApplication1.Service
{
    public class ShareRequestService
    {
        private IShareRequestRepository _shareRequestRepository;
        private IShareRequestUserRepository _shareRequestUserRepository;

        public ShareRequestService(IShareRequestRepository shareRequestRepository, IShareRequestUserRepository shareRequestUserRepository)
        {
            _shareRequestRepository = shareRequestRepository;
            _shareRequestUserRepository = shareRequestUserRepository;
        }

        public async Task AddShareRequest(AddShareRequestDTO addShareRequestDTO)
        {
           ShareRequest shareRequest = new ShareRequest
           {
               ExpenseId = addShareRequestDTO.ExpenseId,
               UserId  = addShareRequestDTO.OwnerId,
               CreateBy = DateOnly.FromDateTime(DateTime.Now)
           };
           await _shareRequestRepository.AddShareRequest(shareRequest);

            var shareUserList = addShareRequestDTO.ShareUserIdList.ToList();

            foreach (var userId in shareUserList)
            {
                ShareRequestUser shareRequestUser = new ShareRequestUser
                {
                    ShareRequestId = shareRequest.ShareRequestId,
                    UserId = userId,
                    Accepted = false,
                    RequestStatus = Enums.Status.Pending
                };
            }

        }

        public async Task UpdateUserResponseForShareRequest(ShareRequestReplyDTORequest shareRequestReplyDTORequest, int shareRequestId)
        {
            var shareRequestUser =await _shareRequestUserRepository.GetShareRequestUser(shareRequestId, shareRequestReplyDTORequest.UserId);
            shareRequestUser.Accepted = shareRequestReplyDTORequest.IsAccepted;
            shareRequestUser.RequestStatus = Enums.Status.Done;
            await _shareRequestUserRepository.UpdateShareRequestUser( shareRequestUser );
            
            var isAllUserHaveResponseShareRequest = await _shareRequestUserRepository.CheckIfEveryRequestHaveBeenReply(shareRequestId);
            if (isAllUserHaveResponseShareRequest)
            {

            }
                
       }
    }
}
