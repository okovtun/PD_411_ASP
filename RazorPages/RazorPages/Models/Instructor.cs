using System.ComponentModel.DataAnnotations;

namespace RazorPages.Models
{
	public class Instructor
	{
		public int ID { get; set; }

		[Required]
		[StringLength(50)]
		[RegularExpression(@"^[A-ZА-Я]+[a-zа-я]*$",ErrorMessage = "Строка содержит недопустимые символы")]
		[Display(Name = "Фамилия")]
		public string LastName { get; set; }

		[Required]
		[StringLength(50)]
		[RegularExpression(@"^[A-ZА-Я]+[a-zа-я]*$",ErrorMessage = "Строка содержит недопустимые символы")]
		[Display(Name = "Имя")]
		public string FirstName { get; set; }

		[DataType(DataType.Date)]
		[Display(Name = "Дата трудоустройства")]
		public DateTime HireDate { get; set; }

		[Display(Name = "Инстуктор")]
		public string FullName
		{
			get => $"{LastName} {FirstName}";
		}

		//Navigation properties:
		public ICollection<Course> Courses { get; set; }
		public OfficeAssignment OfficeAssignment { get; set; }
	}
}
//TODO: https://learn.microsoft.com/en-us/aspnet/core/data/ef-rp/read-related-data?view=aspnetcore-10.0&tabs=visual-studio#:~:text=Update%20Pages/Instructors/Index.cshtml.cs%20with%20the%20following%20code%3A