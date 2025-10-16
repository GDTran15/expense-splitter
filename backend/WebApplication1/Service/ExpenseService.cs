using System.Threading.Tasks;
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

        //internal async Task CreateNewExpense(ExpenseRequestDTO requestDTO)
        //{
        //    //var expenseExist = await expenseRepository.IsExistBy //not in irepository can add later

        //    var newExpense = new ExpenseService
        //    {
        //        ExpenseAmount = requestDTO.ExpenseAmount,
        //        ExpenseDate = requestDTO.ExpenseDate == default ? DateTimeOffset.UtcNow : requestDTO.ExpenseDate,
        //        UserId = requestDTO.UserId,
        //        //add image later 
        //    };

        //    var saved = await _expenseRepository.CreateExpenseAsync(newExpense);

        //    return new ExpenseResponseDTO
        //    {
        //        ExpenseId = saved.ExpenseId,
        //        ExpenseAmount = saved.ExpenseAmount,
        //        ExpenseDate = saved.ExpenseDate,
        //        UserId = saved.UserId
        //    };
        //}

        internal async Task<ExpenseResponseDTO> GetExpenseById(int id)
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

        internal Task<bool> DeleteExpense(int id) => _expenseRepository.DeleteAsync(id);

    }
}