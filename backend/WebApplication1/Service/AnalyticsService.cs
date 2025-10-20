using System;
using System.Threading.Tasks;
using WebApplication1.DTO.Chart;
using WebApplication1.IRepositories;
using WebApplication1.Enums;
using WebApplication1.Model;

namespace WebApplication1.Service
{
    public class AnalyticsService
    {
        private readonly IAnalyticsRepository _analyticsRepository;

        public AnalyticsService(IAnalyticsRepository analyticsRepository)
        {
            _analyticsRepository = analyticsRepository;
        }

        public async Task<AnalyticsResponseDTO> GetAnalyticsSummary(int userId, int days = 30)
        {
            var since = DateOnly.FromDateTime(DateTime.Now.AddDays(-days));

            var expenses = await _analyticsRepository.GetExpensesForUserSince(userId, since);


            double pendingAmount = 0;
            double doneAmount = 0;
            int pendingCount = 0;
            int doneCount = 0;

            foreach (var e in expenses)
            {
                if (e.ExpenseStatus == Status.Pending)
                {
                    pendingAmount += e.ExpenseAmount;
                    pendingCount += 1;
                } else if (e.ExpenseStatus == Status.Done)
                {
                    doneAmount += e.ExpenseAmount;
                    doneCount += 1;
                }
            }

            var analytics = new AnalyticsResponseDTO()
            {
                PendingAmount = pendingAmount,
                DoneAmount = doneAmount,
                PendingCount = pendingCount,
                DoneCount = doneCount
            };

            return analytics;
        }
    }
}