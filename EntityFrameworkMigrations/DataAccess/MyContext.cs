using EntityFrameworkMigrations.DataAccess.Model;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkMigrations.DataAccess
{
  public class MyContext : DbContext
  {
    public MyContext(DbContextOptions<MyContext> options) : base(options)
    {

    }
    
    public DbSet<Cat> Cats { get; set; }
    public DbSet<Person> Personss { get; set; }

  }
}