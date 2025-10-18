using System;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DTO.Expense;
using WebApplication1.DTO.ShareRequest;
using WebApplication1.DTO.User;
using WebApplication1.Enums;
using WebApplication1.IRepositories;
using WebApplication1.Model;

namespace WebApplication1.Service
{
    public class ExpenseService
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly IShareRequestRepository _shareRequestRepository;
        private readonly IShareRequestUserRepository _shareRequestUserRepository;


        public ExpenseService(IExpenseRepository expenseRepository, IShareRequestRepository shareRequestRepository, IShareRequestUserRepository shareRequestUserRepository)
        {
            _shareRequestRepository = shareRequestRepository;
            _shareRequestUserRepository = shareRequestUserRepository;
            _expenseRepository = expenseRepository;
        }

        public async Task CreateNewExpense(ExpenseRequestDTO requestDTO)
        {
            //var expenseExist = await expenseRepository.IsExistBy //not in irepository can add later

            var newExpense = new Expense
            {
                ExpenseName = requestDTO.ExpenseName,
                ExpenseAmount = requestDTO.ExpenseAmount,
                ExpenseDate =  DateOnly.FromDateTime(DateTime.Now),
                UserId = requestDTO.UserId,
                ExpenseStatus = Status.Pending
                //add image later 
            };
              await _expenseRepository.CreateExpenseAsync(newExpense);
            var shareRequest = new ShareRequest
            {
                ExpenseId = newExpense.ExpenseId,
                UserId = requestDTO.UserId,
                CreateBy = DateOnly.FromDateTime(DateTime.Now)
            };
            await _shareRequestRepository.AddShareRequest(shareRequest);

            var shareUserList = requestDTO.ShareUserIdList;

            foreach (var userId in shareUserList)
            {
                ShareRequestUser shareRequestUser = new ShareRequestUser
                {
                    ShareRequestId = shareRequest.ShareRequestId,
                    UserId = userId,
                    Accepted = false,
                    RequestStatus = Enums.Status.Pending
                    
                };
                await _shareRequestUserRepository.AddShareRequestUser(shareRequestUser);
            }

        }

   

        public async Task<List<ExpenseResponseDTO>> GetExpensesByUserId(int userId)
        {
            var expenses = await _expenseRepository.GetByUserIdAsync(userId);

            return expenses.Select(e => new ExpenseResponseDTO
            {
                ExpenseId = e.ExpenseId,
                ExpenseName = e.ExpenseName,
                ExpenseAmount = e.ExpenseAmount,
                ExpenseDate = e.ExpenseDate,
                UserId = e.UserId
            }).ToList();
        }

        public async Task<bool> DeleteExpense(int id) => await _expenseRepository.DeleteAsync(id);

       public async Task<List<ExpenseResponseDTO>> GetPendingExpense(int userId)
        {
            return await _expenseRepository.GetExpensesThatHaveNotBeenDone(userId);
        }

    }
}