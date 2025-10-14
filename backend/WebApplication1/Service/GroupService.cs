

using WebApplication1.IRepositories;
using WebApplication1.Model;

namespace WebApplication1.Service
{
    public class GroupService
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IGroupMemberRepository _groupMemberRepository;


        public GroupService(IGroupRepository groupRepository,IGroupMemberRepository groupMemberRepository)
        {
           
             _groupRepository = groupRepository;
            _groupMemberRepository = groupMemberRepository;
        }

        public async Task createANewGroup(DTO.Group.AddGroupRequestDTO addGroupRequestDTO)
        {
            if (string.IsNullOrWhiteSpace(addGroupRequestDTO.GroupName))
            {
                throw new InvalidOperationException("Group name cannot be blank");
            }
            var group = new Group
            {
                GroupName = addGroupRequestDTO.GroupName,
                CreatedDate = DateTimeOffset.UtcNow
            };
            await _groupRepository.CreateGroup(group);

            var groupMember = new GroupMember
            {
                MemberId = addGroupRequestDTO.UserId,
                GroupId = group.GroupId
            };
            await _groupMemberRepository.AddMemberAsync(groupMember);
        }
    }
}
