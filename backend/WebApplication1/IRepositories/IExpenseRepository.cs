using WebApplication1.Model;

namespace WebApplication1.IRepositories
{
    public interface IExpenseRepository
    {
        Task CreateExpenseAsync(Expense expense);

        Task<Expense?> GetByIdAsync(int id);

        Task<bool> DeleteAsync(int id);

        Task<List<Expense>> GetExpensesThatHaveNotBeenDone(int userId);
    }
}