using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTO.User
{
	public class ExpenseRequestDTO
	{
		[Required]
		public double ExpenseAmount {  get; set; }
		
		public DateTimeOffset ExpenseDate { get; set; }
		public int UserId { get; set; }

		//add image later
	}
}