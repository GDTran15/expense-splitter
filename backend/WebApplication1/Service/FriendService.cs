using System.Threading.Tasks;
using System;
using System.Linq;
using WebApplication1.DTO.Friend;
using WebApplication1.IRepositories;
using WebApplication1.Model;
using WebApplication1.Enums;

namespace WebApplication1.Service
{
    public class FriendService
    {

        private readonly IFriendRepository _friendRepository;

        public FriendService(IFriendRepository friendRepository)
        {
            _friendRepository = friendRepository;
        }

        public async Task<FriendResponseDTO> AddFriend(int userId, AddFriendRequestDTO requestDTO)
        {
            if (requestDTO == null || string.IsNullOrWhiteSpace(requestDTO.Username))
            {
                throw new InvalidOperationException("Usename is required.");
            }

            var target = await _friendRepository.GetUserByUsernameAsync(requestDTO.Username);
            if (target == null)
            {
                throw new InvalidOperationException("User not found.");
            }

            if (target.UserId == userId)
            {
                throw new InvalidOperationException("Can't add yourself.");
            }

            var already = await _friendRepository.IsFriendsAsync(userId, target.UserId);
            if (already)
            {
                throw new InvalidOperationException("Already friends.");
            }

            await _friendRepository.AddFriendPairAsync(userId, target.UserId);

            return new FriendResponseDTO
            {
                FriendId = target.UserId,
                FriendUsername = target.Username
            };
        }

        public async Task<bool> RemoveFriend(int userId, int friendId)
        {
            if (userId == friendId)
            {
                throw new InvalidOperationException("Invalid.");
            }

            var exists = await _friendRepository.IsFriendsAsync(userId, friendId);
            if (!exists)
            {
                throw new InvalidOperationException("Friend doesn't exist.");
                return false;
            }

            await _friendRepository.RemoveFriendPairAsync(userId, friendId);
            return true;
        }

        public async Task<List<GetFriendListDTO>> GetFriendsByUser(int userId)
        {
            var list = await _friendRepository.GetAllFriendsAsync(userId);
            return list;
        }
    }
}