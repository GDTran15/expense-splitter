using WebApplication1.Model;

namespace WebApplication1.IRepositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAll();
        Task<User?> GetByIdAsync(int id);
        Task CreateUserAsync(User user);
        Task<bool> UpdateAsync(User user);
        Task<bool> DeleteAsync(int id);
    
        Task<bool> IsExistByUsernameOrEmailAsync(string username,string email);
    }
}
