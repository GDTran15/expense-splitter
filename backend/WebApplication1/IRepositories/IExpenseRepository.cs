using WebApplication1.Model;

namespace WebApplication1.IRepositories
{
    public interface IExpenseRepository
    {
        Task<Expense>CreateExpenseAsync(Expense expense);

        Task<Expense?> GetByIdAsync(int id);

        Task<bool> DeleteAsync(int id);
    }
}