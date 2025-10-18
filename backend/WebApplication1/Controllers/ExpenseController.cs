using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DTO.User;
using WebApplication1.Model;
using WebApplication1.Service;

namespace WebApplication1.Controllers
{
    [Route("/expense")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private readonly ExpenseService _expenseService;

        public ExpenseController(ExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        ////create
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ExpenseRequestDTO requestDTO)
        {
            await _expenseService.CreateNewExpense(requestDTO);

            return Ok("Expense created successfully");
        }

        [HttpGet]
        public async Task<IActionResult> GetExpense([FromQuery] int userId)
        {
           var expenses =  await _expenseService.GetPendingExpense(userId);
            return Ok(expenses);
        }

        ////add a get one
        //here

        //delete
        [HttpPost("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _expenseService.DeleteExpense(id);
            return Ok(new { deleted });
        }
    }
}