using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using WebApplication1.IRepositories;
using WebApplication1.Model;
using WebApplication1.Enums;
using WebApplication1.DTO.User;
using WebApplication1.DTO.Expense;

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

        public async Task<Expense> FindExpenseThroughShareId(int shareId)
        {
            var expense = await (from ex in _context.Expenses
                                 join sh in _context.ShareRequests on ex.ExpenseId equals sh.ExpenseId
                                 where sh.ShareRequestId == shareId
                                 select ex
                                 ).FirstOrDefaultAsync();
            return expense;
        }

        public async Task<Expense?> GetByIdAsync(int id)
        {
            var foundId = await _context.Expenses.AsNoTracking().FirstOrDefaultAsync(e => e.ExpenseId == id); 
            return foundId;
        }

        public async Task<List<Expense>> GetByUserIdAsync(int userId)
        {
            var expenseList = await _context.Expenses
                              .Where(x => x.UserId == userId && x.ExpenseStatus == Status.Pending)                             
                              .ToListAsync();
            return expenseList;
        }

        public async Task<List<ExpenseReponseForOwner>> GetExpenseForOwner(int userId)
        {
            var expenses = await (from expense in _context.Expenses
                                  join shareRequest in _context.ShareRequests on expense.ExpenseId equals shareRequest.ExpenseId
                                  where expense.ExpenseStatus == Status.Pending && (expense.UserId == userId)
                                  select new ExpenseReponseForOwner
                                  {
                                      ExpenseId = expense.ExpenseId,
                                      ShareId = shareRequest.ShareRequestId,
                                      Status = expense.ExpenseStatus,
                                      ExpenseDate = expense.ExpenseDate,
                                      ExpenseAmount = expense.ExpenseAmount,
                                      ExpenseName  = expense.ExpenseName,

                                  }).ToListAsync();
            return expenses;
        }

        public async Task<List<ExpenseReceiveByOtherResponseDTO>> GetExpensesFromShareUserThatNotDone(int userId)
        {
            var expenses = await (from expense in _context.Expenses
                                  join shareRequest in _context.ShareRequests on expense.ExpenseId equals shareRequest.ExpenseId
                                  join shareRequestUser in _context.ShareRequestUsers on shareRequest.ShareRequestId equals shareRequestUser.ShareRequestId
                                  join user in _context.Users on expense.UserId equals user.UserId
                                  where  shareRequestUser.RequestStatus == Status.Pending && (shareRequestUser.UserId == userId )
                                  select new ExpenseReceiveByOtherResponseDTO
                                  {
                                      ExpenseId = expense.ExpenseId,
                                      ExpenseAmount = expense.ExpenseAmount,
                                      ExpenseDate = expense.ExpenseDate,
                                      UserId = expense.UserId,
                                      OwnerName = user.Username,
                                      ShareRequestId = shareRequestUser.ShareRequestId,
                                      AmountToPay = shareRequestUser.AmountToPay,
                                      ExpenseName = expense.ExpenseName,
                                      RequestAccept = shareRequestUser.Accepted
                                  }).ToListAsync();

            return expenses;
        }

      

        public async Task UpdateExpenseAsync(Expense expense)
        {
             _context.Expenses.Update(expense);
            await _context.SaveChangesAsync();
        }
    }
}