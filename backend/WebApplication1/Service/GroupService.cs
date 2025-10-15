

using WebApplication1.DTO.Group;
using WebApplication1.IRepositories;
using WebApplication1.Model;

namespace WebApplication1.Service
{
    public class GroupService
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IGroupMemberRepository _groupMemberRepository;
        private readonly IUserRepository _userRepository;


        public GroupService(IGroupRepository groupRepository,IGroupMemberRepository groupMemberRepository, IUserRepository userRepository)
        {
           
             _groupRepository = groupRepository;
            _groupMemberRepository = groupMemberRepository;
            _userRepository = userRepository;
        }

        public async Task CreateANewGroup(AddGroupRequestDTO addGroupRequestDTO)
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

        public async Task<List<GetAllGroupDTO>> GetAllGroupOfUser(int userId)
        {
           
            var groupList =  await _groupMemberRepository.GetAllGroupByMemberId(userId);
            return groupList;
        }

        public  async Task<List<GroupMemberResponseDTO>> GetGroupMember(int groupId)
        {
           var groupMember = await _groupMemberRepository.GetGroupMemberByGroupId(groupId);
            return groupMember;
        }

        public async Task AddMemberIntoGroup(int groupId, string username)
        {
            var user = await _userRepository.GetUserByUsername(username);
            if (user == null)
            {
                throw new InvalidOperationException("Username does not exist");
            }
            var memberExist = await _groupMemberRepository.IsMemberExistInGroup(user.UserId,groupId);
            if (memberExist)
            {
                throw new InvalidOperationException("Member already exist in this group");
            }
            var groupMember = new GroupMember
            {
                MemberId = user.UserId,
                GroupId = groupId,
            };
            await _groupMemberRepository.AddMemberAsync(groupMember);
        }
    }
}
