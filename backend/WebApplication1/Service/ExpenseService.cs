using System;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DTO.Expense;
using WebApplication1.DTO.ShareRequest;
using WebApplication1.DTO.User;
using WebApplication1.Enums;
using WebApplication1.IRepositories;
using WebApplication1.Model;
using WebApplication1.Util;

namespace WebApplication1.Service
{
    public class ExpenseService
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly IShareRequestRepository _shareRequestRepository;
        private readonly IShareRequestUserRepository _shareRequestUserRepository;
        private readonly IGroupMemberRepository _groupMemberRepository;


        public ExpenseService(IExpenseRepository expenseRepository, IShareRequestRepository shareRequestRepository, IShareRequestUserRepository shareRequestUserRepository, IGroupMemberRepository 
            groupMemberRepository)
        {
            _shareRequestRepository = shareRequestRepository;
            _shareRequestUserRepository = shareRequestUserRepository;
            _expenseRepository = expenseRepository;
            _groupMemberRepository = groupMemberRepository;
        }

        public async Task CreateNewExpense(ExpenseRequestDTO requestDTO)
        {
            

            var newExpense = new Expense
            {
                ExpenseName = requestDTO.ExpenseName,
                ExpenseAmount = requestDTO.ExpenseAmount,
                ExpenseDate =  DateOnly.FromDateTime(DateTime.Now),
                UserId = requestDTO.UserId,
                ExpenseStatus = Status.Pending
            };
              await _expenseRepository.CreateExpenseAsync(newExpense);
            var shareRequest = new ShareRequest
            {
                ExpenseId = newExpense.ExpenseId,
                UserId = requestDTO.UserId,
                CreateBy = DateOnly.FromDateTime(DateTime.Now)
            };
            await _shareRequestRepository.AddShareRequest(shareRequest);

            var shareTo = requestDTO.ShareOption;

            if (shareTo == "friend")
            {
                ShareRequestUser shareRequestUser = new ShareRequestUser
                {
                    ShareRequestId = shareRequest.ShareRequestId,
                    UserId = requestDTO.FriendOrGroupId,
                    Accepted = false,
                    AmountToPay = SplittingPayment.SplittingPaymentForFriends(requestDTO.ExpenseAmount),
                    RequestStatus = Status.Pending

                };
                await _shareRequestUserRepository.AddShareRequestUser(shareRequestUser);
            } else
            {
                var groupId = requestDTO.FriendOrGroupId;
                var groupMember = await _groupMemberRepository.GetGroupMemberByGroupId(groupId);
                foreach (var member in groupMember)
                {
                    if(member.UserId == requestDTO.UserId)
                    {
                        continue;
                    }
                    ShareRequestUser shareRequestUser = new()
                    {
                        ShareRequestId = shareRequest.ShareRequestId,
                        UserId = member.UserId,
                        Accepted = null,
                        AmountToPay = SplittingPayment.SplittingPaymentForGroups(requestDTO.ExpenseAmount, groupMember.Count),
                        RequestStatus = Status.Pending,


                    };
                    await _shareRequestUserRepository.AddShareRequestUser(shareRequestUser);
                }
            }

        }

   

        //public async Task<List<ExpenseResponseDTO>> GetExpensesByUserId(int userId)
        //{
        //    var expenses = await _expenseRepository.GetByUserIdAsync(userId);

        //    return expenses.Select(e => new ExpenseResponseDTO
        //    {
        //        ExpenseId = e.ExpenseId,
        //        ExpenseName = e.ExpenseName,
        //        ExpenseAmount = e.ExpenseAmount,
        //        ExpenseDate = e.ExpenseDate,
        //        UserId = e.UserId
        //    }).ToList();
        //}

        public async Task<bool> DeleteExpense(int id) => await _expenseRepository.DeleteAsync(id);

       public async Task<List<ExpenseReceiveByOtherResponseDTO>> GetPendingExpense(int userId)
        {
            return await _expenseRepository.GetExpensesFromShareUserThatNotDone(userId);
        }

        public async Task<List<ExpenseReponseForOwner>> GetExpenseOfOwner(int userId)
        {
            return await _expenseRepository.GetExpenseForOwner(userId);
        }

        public async Task ChangeExpenseStatusToDone(int expenseId)
        {
            var expense = await _expenseRepository.GetByIdAsync(expenseId);
            expense.ExpenseStatus = Status.Done;
            await _expenseRepository.UpdateExpenseAsync(expense);
        }
    }
}