using WebApplication1.Model;

namespace WebApplication1.IRepositories
{
    public interface IGroupMemberRepository
    {
        Task<List<GroupMember>> GetGroupMemberByMemberId(int memberId);  

        Task AddMemberAsync(GroupMember groupMember);
     }
}
