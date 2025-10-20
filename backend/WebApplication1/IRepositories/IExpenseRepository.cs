using WebApplication1.DTO.Expense;
using WebApplication1.Model;

namespace WebApplication1.IRepositories
{
    public interface IExpenseRepository
    {
        Task CreateExpenseAsync(Expense expense);

        Task<Expense?> GetByIdAsync(int id);

        Task<bool> DeleteAsync(int id);


        Task<List<ExpenseReceiveByOtherResponseDTO>> GetExpensesFromShareUserThatNotDone(int userId);
        Task<List<ExpenseReponseForOwner>> GetExpenseForOwner(int userId);

        Task<List<Expense>> GetByUserIdAsync(int userId);

        Task UpdateExpenseAsync(Expense expense);
        Task<Expense> FindExpenseThroughShareId(int shareId);
    }
}