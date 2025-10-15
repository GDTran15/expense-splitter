using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using WebApplication1.IRepositories;
using WebApplication1.Model;

namespace WebApplication1.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        #region Constructor and DI
        private readonly AppDbContext _context;

        public ExpenseRepository(AppDbContext context)
        {
            _context = context;
        }
        #endregion

        public async Task CreateExpenseAsync(Expense expense)
        {
            await _context.Expenses.AddAsync(expense);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Expenses.FirstOrDefaultAsync(e => e.ExpenseId == id);
            if (entity != null)
            {
                _context.Expenses.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Expense?> GetByIdAsync(int id)
        {
            //var foundId = await _context.Expenses.Where(e => e.ExpenseId == id).AsNoTracking().FirstOrDefaultAsync();
            var foundId = await _context.Expenses.AsNoTracking().FirstOrDefaultAsync(e => e.ExpenseId == id); 
            return foundId;
        }

    }
}