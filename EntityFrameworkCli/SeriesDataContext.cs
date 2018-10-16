using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCli
{
  public class SeriesDataContext : DbContext
  {
    public SeriesDataContext(DbContextOptions<SeriesDataContext> options) : base(options)
    {
    }
    public DbSet<Character> Characters { get; set; }
    public DbSet<Episode> Episodes { get; set; }
    public DbSet<CharacterAppearance> CharacterAppearances { get; set; }
    public DbSet<Series> Series { get; set; }


  }
}
