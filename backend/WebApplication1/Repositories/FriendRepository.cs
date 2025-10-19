using Microsoft.EntityFrameworkCore;
using WebApplication1.DTO.Friend;
using WebApplication1.IRepositories;
using WebApplication1.Model;
using Friend = WebApplication1.Model.Friend;

namespace WebApplication1.Repositories
{
    public class FriendRepository : IFriendRepository
    {

        #region Constructor and DI
        private readonly AppDbContext _context;

        public FriendRepository(AppDbContext context)
        {
            _context = context;
        }
        #endregion

        public async Task<User?> GetUserByUserIdAsync(int userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u  => u.UserId == userId);
            return user;
        }

        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
            return user;
        }

        public async Task<bool> IsFriendsAsync(int userId, int friendId)
        {
            var exists = await _context.Friends.AnyAsync(f => f.UserId == userId && f.FriendId == friendId);
            return exists;
        }
        
        public async Task<bool> UserExistsAsync(int userId)
        {
            var exists = await _context.Users.AnyAsync(u => u.UserId == userId);
            return exists;
        }

        public async Task AddFriendPairAsync(int aId, int bId)
        {
            var f1 = new Friend { UserId = aId, FriendId = bId };
            var f2 = new Friend { UserId = bId, FriendId = aId };

            await _context.Friends.AddAsync(f1);
            await _context.Friends.AddAsync(f2);

            await _context.SaveChangesAsync();
        }

        public async Task RemoveFriendPairAsync(int aId, int bId)
        {
            var pair1 = await _context.Friends.FirstOrDefaultAsync(f => f.UserId == aId && f.FriendId == bId);
            var pair2 = await _context.Friends.FirstOrDefaultAsync(f => f.UserId == bId && f.FriendId == aId);

            if (pair1 != null)
            {
                _context.Friends.Remove(pair1);
            }

            if (pair2 != null)
            {
                _context.Friends.Remove(pair2);
            }
            
            await _context.SaveChangesAsync();
        }

        public async Task<List<GetFriendListDTO>> GetAllFriendsAsync(int userId)
        {
            var friends = await _context.Friends
                          .Where(f => f.UserId == userId)
                          .Select(f => new GetFriendListDTO
                          {
                              FriendId = f.UserFriend.UserId,
                              FriendUsername = f.UserFriend.Username,
                              FriendName = f.UserFriend.Name
                          })
                          .ToListAsync();
            //wtffff idk what to do fix later

            return friends;
        }
    }
}