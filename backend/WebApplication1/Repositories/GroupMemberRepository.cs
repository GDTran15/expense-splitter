using Microsoft.EntityFrameworkCore;
using WebApplication1.IRepositories;
using WebApplication1.Model;

namespace WebApplication1.Repositories
{
    public class GroupMemberRepository : IGroupMemberRepository
    {
        private readonly AppDbContext _context;

        public GroupMemberRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddMemberAsync(GroupMember groupMember)
        {
            await _context.GroupMembers.AddAsync(groupMember);
            await _context.SaveChangesAsync();
        }

        public async Task<List<GroupMember>> GetGroupMemberByMemberId(int memberId)
        {
            var listOfGroupMember = await _context.GroupMembers.Where(e => e.MemberId == memberId).ToListAsync();
            return listOfGroupMember;
        }

       
    }
}
