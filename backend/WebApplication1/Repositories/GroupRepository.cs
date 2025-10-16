
using Microsoft.EntityFrameworkCore;
using WebApplication1.DTO.Group;
using WebApplication1.IRepositories;
using WebApplication1.Model;
using Group = WebApplication1.Model.Group;

namespace WebApplication1.Repositories
{
    public class GroupRepository : IGroupRepository
    {

        private readonly AppDbContext _context;

        public GroupRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task CreateGroup(Group  group)
        {
            await _context.Groups.AddAsync(group);
            await _context.SaveChangesAsync();
        }

       
    }
}
