using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DTO.Chart;
using WebApplication1.Model;
using WebApplication1.Service;

namespace WebApplication1.Controllers
{
    [Route("/analytics")]
    [ApiController]

    public class AnalyticsController : ControllerBase
    {
        private readonly AnalyticsService _analyticsService;

        public AnalyticsController(AnalyticsService analyticsService)
        {
            _analyticsService = analyticsService;
        }

        [HttpGet("summary")]
        public async Task<IActionResult> GetSummary([FromQuery] int userId, [FromQuery] int days = 30)
        {
            var result = await _analyticsService.GetAnalyticsSummary(userId, days);
            return Ok(result);
        }

    }

}