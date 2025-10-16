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
    }
}
