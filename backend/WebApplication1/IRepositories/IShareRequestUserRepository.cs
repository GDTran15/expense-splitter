using System.ComponentModel;
using WebApplication1.Model;

namespace WebApplication1.IRepositories
{
    public interface IShareRequestUserRepository
    {
        Task AddShareRequestUser(ShareRequestUser shareRequestUser);

        Task<ShareRequestUser> GetShareRequestUser(int shareRequestId, int userId);
        Task UpdateShareRequestUser(ShareRequestUser shareRequestUser);
  
        Task<bool> CheckIfEveryRequestHaveBeenReply(int  shareRequestId);
    }
}
