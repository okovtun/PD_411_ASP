using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Academy.Models
{
	public class Group
	{
		[Key]
		public int group_id { get; set; }
		public string group_name { get; set; }

		[Required]
		[ForeignKey(nameof(Direction))]
		[MinLength(1)]
		public byte direction { get; set; }
		public byte learning_days { get; set; }
		public TimeOnly start_time { get; set; }
		//Navigation properties
		//https://learn.microsoft.com/en-us/ef/core/modeling/relationships/mapping-attributes
		[Required]
		public Direction? Direction { get; set; }
	}
}
