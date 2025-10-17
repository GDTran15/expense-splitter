using Microsoft.EntityFrameworkCore;
using WebApplication1.IRepositories;
using WebApplication1.Model;

namespace WebApplication1.Repositories
{
    public class ShareRequestUserRepository : IShareRequestUserRepository
    {
        private readonly AppDbContext _appDbContext;

        public ShareRequestUserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddShareRequestUser(ShareRequestUser shareRequestUser)
        {
            await _appDbContext.ShareRequestUsers.AddAsync(shareRequestUser);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<bool> CheckIfEveryRequestHaveBeenReply(int shareRequestId)
        {
            var result = await _appDbContext.ShareRequestUsers
                .Where(e => e.ShareRequestId == shareRequestId)
                .AllAsync(e => e.RequestStatus == Enums.Status.Done);

            return result;
        }

        public async Task<ShareRequestUser> GetShareRequestUser(int shareRequestId, int userId)
        {
            var shareRequestUser = await _appDbContext.ShareRequestUsers.Where(e => e.ShareRequestId == shareRequestId && e.UserId == userId).FirstOrDefaultAsync();
            return shareRequestUser;
           
        }

        public async Task UpdateShareRequestUser(ShareRequestUser shareRequestUser)
        {
            await _appDbContext.ShareRequestUsers.AddAsync(shareRequestUser);
            await _appDbContext.SaveChangesAsync();
        }


    }
}
