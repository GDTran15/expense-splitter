using WebApplication1.Model;

namespace WebApplication1.IRepositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAll();
        Task<User?> GetByUsernameAndPassWord(string username, string password);
        Task CreateUserAsync(User user);
        
        Task<User?> GetUserByUsername(string username); 
    
        Task<bool> IsExistByUsernameOrEmailAsync(string username,string email);
    }
}
