using Ef7BulkOperations.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ef7BulkOperations;

public class ApplicationDbContext : DbContext
{
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
	{

	}

	public DbSet<Product> Products { get; set; }
	public DbSet<Category> Categories { get; set; }
}
