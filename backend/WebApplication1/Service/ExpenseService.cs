using System.Threading.Tasks;
using System;
using System.Linq;
using WebApplication1.DTO.User;
using WebApplication1.IRepositories;
using WebApplication1.Model;

namespace WebApplication1.Service
{
    public class ExpenseService
    {
        private readonly IExpenseRepository _expenseRepository;

        public ExpenseService(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        public async Task CreateNewExpense(ExpenseRequestDTO requestDTO)
        {
            //var expenseExist = await expenseRepository.IsExistBy //not in irepository can add later

            var newExpense = new Expense
            {
                ExpenseAmount = requestDTO.ExpenseAmount,
                ExpenseDate = requestDTO.ExpenseDate == default ? DateTimeOffset.UtcNow : requestDTO.ExpenseDate,
                UserId = requestDTO.UserId,
                //add image later 
            };

            await _expenseRepository.CreateExpenseAsync(newExpense);
     
        }

        public async Task<ExpenseResponseDTO> GetExpenseById(int id)
        {
            var expense = await _expenseRepository.GetByIdAsync(id);
            if (expense == null)
            {
                throw new InvalidOperationException("Wrong id");
            }

            return new ExpenseResponseDTO
            {
                ExpenseId = expense.ExpenseId,
                ExpenseAmount = expense.ExpenseAmount,
                ExpenseDate = expense.ExpenseDate,
                UserId = expense.UserId
            };
        }

        public async Task<List<ExpenseResponseDTO>> GetExpensesByUser(int userId)
        {
            var expenses = await _expenseRepository.GetByUserIdAsync(userId);

            return expenses.Select(e => new ExpenseResponseDTO
            {
                ExpenseId = e.ExpenseId,
                ExpenseAmount = e.ExpenseAmount,
                ExpenseDate = e.ExpenseDate,
                UserId = e.UserId
            }).ToList();
        }

        public async Task<bool> DeleteExpense(int id) => await _expenseRepository.DeleteAsync(id);

    }
}