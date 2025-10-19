using WebApplication1.DTO.Expense;
using WebApplication1.Model;

namespace WebApplication1.IRepositories
{
    public interface IExpenseRepository
    {
        Task CreateExpenseAsync(Expense expense);

        Task<Expense?> GetByIdAsync(int id);

        Task<bool> DeleteAsync(int id);


        Task<List<ExpenseResponseDTO>> GetExpensesThatHaveNotBeenDone(int userId);

        Task<List<Expense>> GetByUserIdAsync(int userId);

    }
}