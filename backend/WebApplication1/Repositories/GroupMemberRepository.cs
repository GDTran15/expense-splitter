using Microsoft.EntityFrameworkCore;
using WebApplication1.DTO.Group;
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

        public async Task<List<GetAllGroupDTO>> GetAllGroupByMemberId(int userId)
        {
            var groupList =  await (from groupMember in _context.GroupMembers
                             join _group in _context.Groups on groupMember.GroupId equals _group.GroupId
                             where groupMember.MemberId == userId
                             select new GetAllGroupDTO
                             {
                                 GroupId = groupMember.GroupId,
                                 GroupName = _group.GroupName,
                             }
                            ).ToListAsync();
            return groupList;
        }

        public async Task<List<GroupMemberResponseDTO>> GetGroupMemberByGroupId(int groupId)
        {
            var groupMembers = await (from groupMember in _context.GroupMembers
                                      join user in _context.Users on groupMember.MemberId equals user.UserId
                                      where groupMember.GroupId == groupId
                                      select new GroupMemberResponseDTO
                                      {
                                          UserId = groupMember.MemberId,
                                          Username = user.Username
                                      }
                                      ).ToListAsync();
            return groupMembers;
        }

        public async Task<bool> IsMemberExistInGroup(int userId, int groupId)
        {
            var exist = await _context.GroupMembers.Where(e => e.GroupId == groupId && e.MemberId == userId).FirstOrDefaultAsync();
            if (exist == null)
            {
                return false;
            }
            return true;
        }
    }
}
