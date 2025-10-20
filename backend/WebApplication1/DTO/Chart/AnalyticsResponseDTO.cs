namespace WebApplication1.DTO.Chart
{
    public class AnalyticsResponseDTO
    {
        public double PendingAmount { get; set; }
        public double DoneAmount { get; set; }

        public int PendingCount { get; set; }
        public int DoneCount { get; set; }
    }
}