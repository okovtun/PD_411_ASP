using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
	public class Student
	{
		public int ID { get; set; }

		[Required(ErrorMessage = "Без фамилии никак...")]
		[StringLength(50,ErrorMessage = "Превышена максимальная длина")]
		[Display(Name = "Фамилия")]
		public string LastName { get; set; }
		
		[Required(ErrorMessage = "Без имени никак...")]
		[StringLength(50,ErrorMessage = "Превышена максимальная длина")]
		[Display(Name = "Имя")]
		public string FirstName { get; set; }
		public DateTime EnrollmentDate { get; set; }

		//Navigation properties:
		public ICollection<Enrollment> Enrollments { get; set; }
	}
}
