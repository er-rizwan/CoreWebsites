using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreWeb.Models
{
	public class Student
	{
        [Key]
        public int Id { get; set; }
        [Column("StudentName"),DataType("varchar(100)")]
        public string Name { get; set; }
		[Column("StudentGender"), DataType("varchar(10)")]
		public string Gender { get; set; }
		[Column("StudentAge"), DataType("int")]
		public int Age { get; set; }
		public int Standard { get; set; }
	}
}
