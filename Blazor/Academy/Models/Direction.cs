using Academy.Models.ValidationAttributes;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Academy.Models
{
	[Index(nameof(direction_name), IsUnique = true)]
	public class Direction
	{
		[Key]
		public byte direction_id { get; set; }
		[Required]
		[UniqueDirectionName(ErrorMessage = "Error: такое направление уже существует")]
		public string direction_name { get; set; }
		
		//Navigation properties:
		public List<Group> Groups { get; set; } = new List<Group>();
	}
}
