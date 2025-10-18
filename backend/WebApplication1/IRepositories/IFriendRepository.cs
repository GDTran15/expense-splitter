using WebApplication1.Model;
using WebApplication1.DTO.Friend;

namespace WebApplication1.IRepositories
{
    public interface IFriendRepository
    {
        Task<User?> GetUserByUserIdAsync(int userId);
        Task<User?> GetUserByUsernameAsync(string username);

        Task<bool> IsFriendsAsync(int userId, int friendId);
        
        Task<bool> UserExistsAsync(int userId);

        Task AddFriendPairAsync(int aId, int bId);
        Task RemoveFriendPairAsync(int aId, int bId);

        //Task<List> GetAllFriendsAsync(int userId);

    }
}
