namespace WebApplication1.DTO.ShareRequest
{
    public class AddShareRequestDTO
    {
        public int ExpenseId { get; set; }
        
        public int OwnerId { get; set; }

        public List<int> ShareUserIdList { get; set; }
    }
}
