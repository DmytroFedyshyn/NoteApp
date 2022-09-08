using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NoteApp.Models;

namespace NoteApp.Data
{
	public class ApplicationContext : IdentityDbContext<User>
	{
		public ApplicationContext(DbContextOptions<ApplicationContext> dbContext) : base(dbContext)
		{
			//Database.EnsureDeleted();
			Database.EnsureCreated();
		}
		public DbSet<Note> Notes { get; set; }
	}
}
