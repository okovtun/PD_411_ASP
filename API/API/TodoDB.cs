using Microsoft.EntityFrameworkCore;

namespace API
{
	public class TodoDB:DbContext
	{
		public TodoDB(DbContextOptions<TodoDB> options):base(options)
		{
		}

		public DbSet<TODO> Tasklist => Set<TODO>();
	}
}
