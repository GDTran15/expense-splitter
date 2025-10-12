using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using WebApplication1.IRepositories;
using WebApplication1.Model;

namespace WebApplication1.Repositories
{
    public class UserRepository : IUserRepository
    {
        #region Constructor and DI
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
        #endregion

        public async Task<long> CreateAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user.UserId;
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<User>> GetAll()
        {
            var list = await _context.Users.ToListAsync();
            return list;
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            var user = await _context.Users.Where(u => u.UserId == id).FirstOrDefaultAsync();
            return user;
        }

        public async Task<bool> IsExistByIdAsync(int id)
        {
            var student = await GetByIdAsync(id);
            return student is not null;
        }

        public async Task<bool> UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
