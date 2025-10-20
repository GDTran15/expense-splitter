using Microsoft.EntityFrameworkCore;
using WebApplication1.IRepositories;
using WebApplication1.Model;
using WebApplication1.Enums;
using WebApplication1.DTO.User;
using WebApplication1.DTO.Expense;

namespace WebApplication1.Repositories
{
    public class AnalyticsRepository : IAnalyticsRepository
    {
        #region Constructor and DI
        private readonly AppDbContext _context;

        public AnalyticsRepository(AppDbContext context)
        {
            _context = context;
        }
        #endregion

        public async Task<List<Expense>> GetExpensesForUserSince(int userId, DateOnly since)
        {
            var list = await _context.Expenses.AsNoTracking()
                                              .Where(e => e.UserId == userId && e.ExpenseDate >= since)
                                              .ToListAsync();
            return list;
        }
    }
}