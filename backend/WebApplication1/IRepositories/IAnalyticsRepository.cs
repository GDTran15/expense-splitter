using WebApplication1.DTO.Chart;
using WebApplication1.Model;

namespace WebApplication1.IRepositories
{
    public interface IAnalyticsRepository
    {
        Task<List<Expense>> GetExpensesForUserSince(int userId, DateOnly since);
    }
}