using System.ComponentModel.DataAnnotations;

namespace GBC_Bids_Group_6.Models
{
	public class Condition
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "Please select a condition description")]
		public string Name { get; set; }
	}
}
