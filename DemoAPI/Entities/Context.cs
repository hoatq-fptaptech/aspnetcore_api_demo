using System;
using Microsoft.EntityFrameworkCore;
namespace DemoAPI.Entities
{
	public class Context : DbContext
	{
		public Context(DbContextOptions options):base(options)
		{
		}

		public DbSet<Student> Students { get; set; }
	}
}

