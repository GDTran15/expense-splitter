using WebApplication1.Model;

namespace WebApplication1.IRepositories
{
    public interface IExpenseRepository
    {
        Task CreateExpenseAsync(Expense expense);

        Task<Expense?> GetByIdAsync(int id);

        Task<bool> DeleteAsync(int id);

<<<<<<< HEAD
        Task<List<Expense>> GetExpensesThatHaveNotBeenDone(int userId);
=======
        Task<List<Expense>> GetByUserIdAsync(int userId);
>>>>>>> de91dd93a19c340527b1aacb59852be6c5c59369
    }
}