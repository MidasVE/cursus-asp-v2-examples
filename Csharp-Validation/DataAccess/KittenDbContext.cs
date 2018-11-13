using Csharp_Validation.Models;
using Microsoft.EntityFrameworkCore;

namespace Csharp_Validation.DataContext
{
  public class KittenDbContext : DbContext
  {
    public KittenDbContext(DbContextOptions<KittenDbContext> options) : base(options)
    {

    }

    public DbSet<Kitten> Kittens { get; set; }
  }
}