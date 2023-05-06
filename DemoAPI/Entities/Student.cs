using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DemoAPI.Entities
{
	[Table("Students")]
	public class Student
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
	}
}

