using WebApplication1.IRepositories;
using WebApplication1.Model;

namespace WebApplication1.Repositories
{
    public class ShareRequestRepository : IShareRequestRepository
    {

        private readonly AppDbContext _context;

        public ShareRequestRepository(AppDbContext context)
        {
            _context = context;
        }


        public async Task AddShareRequest(ShareRequest shareRequest)
        {
            await _context.ShareRequests.AddAsync(shareRequest);
            await _context.SaveChangesAsync();
        }
    }
}
