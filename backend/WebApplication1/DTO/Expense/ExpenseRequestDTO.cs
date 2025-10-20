 using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTO.User
{
	public class ExpenseRequestDTO
	{
		[Required]
		public double ExpenseAmount {  get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public string ExpenseName { get; set; }

        [Required]
        public string ShareOption { get; set; }

        [Required]
        public int FriendOrGroupId { get; set; }

        //add image later
    }
}