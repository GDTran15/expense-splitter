using System.ComponentModel;
using WebApplication1.DTO.ShareRequest;
using WebApplication1.Model;

namespace WebApplication1.IRepositories
{
    public interface IShareRequestUserRepository
    {
        Task AddShareRequestUser(ShareRequestUser shareRequestUser);

        Task<ShareRequestUser> GetShareRequestUser(int shareRequestId, int userId);
        Task UpdateShareRequestUser(ShareRequestUser shareRequestUser);
  
        Task<bool> CheckIfEveryRequestHaveBeenReply(int  shareRequestId);

        Task<int> NumberOfPeopleInSharerequest(int shareRequestId);
        Task<List<ShareRequestUserStatusDTOResponse>> GetShareRequestUserAcceptStatus(int shareRequestId);
    }
}
