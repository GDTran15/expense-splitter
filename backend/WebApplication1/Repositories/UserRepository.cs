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

        public async Task CreateUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
          
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

       
        public async Task<User?> GetByNameAsync(string name)
        {
            var user = await _context.Users.Where(u => u.Name == name).FirstOrDefaultAsync();
            return user;
        }
        public async Task<User?> GetByEmailAsync(string  email)
        {
            var user = await _context.Users.Where(u =>  u.Email == email).FirstOrDefaultAsync();
            return user;
        }

        public async Task<bool> IsExistByUsernameOrEmailAsync(string username, string email)
        {
            var usernameExist = await GetByNameAsync(username);
            var emailExist = await GetByEmailAsync(email);
            return usernameExist != null || emailExist != null;

        }

        public async Task<bool> UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsExistByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<User?> GetByUsernameAndPassWord(string username, string password)
        {
            var user = await _context.Users.Where(u => 
            u.Username == username && u.Password == password).FirstOrDefaultAsync();

            return user;
        }

        public async Task<User?> GetUserByUsername(string username)
        {
            var user = await _context.Users.Where(u =>
                u.Username == username).FirstOrDefaultAsync();

            return user;
        }


    }
}
