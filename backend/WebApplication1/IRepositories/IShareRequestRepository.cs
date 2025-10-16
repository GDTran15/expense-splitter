using WebApplication1.Model;

namespace WebApplication1.IRepositories
{
    public interface IShareRequestRepository
    {
        Task AddShareRequest(ShareRequest shareRequest);


    }
}
