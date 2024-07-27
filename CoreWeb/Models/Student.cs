using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreWeb.Models
{
	public class Student
	{
        [Key]
		[Required]
        public int Id { get; set; }


        [Column("StudentName"),DataType("varchar(100)")]
        public string Name { get; set; }


		[Column("StudentGender"), DataType("varchar(10)")]
		[Required]
		public string Gender { get; set; }


		[Column("StudentAge"), DataType("int")]	
		[Required]
		public int Age { get; set; }


		[Column("Standard"), DataType("int")]
		[Required]
		public int Standard { get; set; }
	}
}
