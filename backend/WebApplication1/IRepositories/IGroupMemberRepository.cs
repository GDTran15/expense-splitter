using WebApplication1.DTO.Group;
using WebApplication1.Model;

namespace WebApplication1.IRepositories
{
    public interface IGroupMemberRepository
    {
        Task<List<GroupMember>> GetGroupMemberByMemberId(int memberId);  

        Task AddMemberAsync(GroupMember groupMember);

        Task<List<GetAllGroupDTO>> GetAllGroupByMemberId(int userId);

        Task<List<GroupMemberResponseDTO>> GetGroupMemberByGroupId(int groupId);

        Task<bool> IsMemberExistInGroup(int userId, int groupId);
        
    }
}
