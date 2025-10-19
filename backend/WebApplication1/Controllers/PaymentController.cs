using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using WebApplication1.Service;

namespace WebApplication1.Controllers
{
    [Route("/payment")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly PaymentService paymentService;
        

        public PaymentController(PaymentService paymentService)
        { 
            this.paymentService = paymentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPaymentListByUserId(int userId)
        { 
             var payments = await paymentService.GetPaymentListByUserId(userId);
            return Ok(payments);

        }

        [HttpPut("/payment/{paymentId}")]
        public async Task<IActionResult> PaymentUpdate([FromRoute] int paymentId)
        {
            await paymentService.PaymentProcess(paymentId);
            return Ok("Payment success");
        }
    }
}
