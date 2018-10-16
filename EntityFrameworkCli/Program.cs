using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCli
{
  class Program
  {
    static void Main(string[] args)
    {
      var optionsBuilder = new DbContextOptionsBuilder<SeriesDataContext>();
      optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());

      using (var context = new SeriesDataContext(optionsBuilder.Options))
      {
        var southpark = new Series { Name = "Southpark" };
        context.Add(southpark);
        Console.WriteLine($"001 - {southpark.Name} - ({southpark.Id})");

        var episode1 = new Episode() { EpisodeNumber = "s01e01", Show = southpark };
        context.Add(episode1);
        Console.WriteLine($"002 - {episode1.EpisodeNumber} - ({episode1.Id})");

        Console.WriteLine($"003 - {southpark.Episodes[0].EpisodeNumber} ({southpark.Episodes[0].Equals(episode1)})");

        var cartman = new Character() { Name = "Cartman" };
        var chef = new Character() { Name = "chef" };

        context.AddRange(cartman, chef);
        episode1.Appearances = new List<CharacterAppearance>();
        episode1.Appearances.Add(new CharacterAppearance { Character = cartman });
        episode1.Appearances.Add(new CharacterAppearance { Character = chef });

        Console.WriteLine($"004 - {cartman.Appearances}");
        context.SaveChanges();
        Console.WriteLine($"005 - {cartman.Appearances}");
      }

      using (var newContext = new SeriesDataContext(optionsBuilder.Options))
      {
        var retrievedCartman = newContext.Characters.Single(x => x.Id == 1);
        Console.WriteLine($"006 - {retrievedCartman.Name} - {retrievedCartman.Appearances}");

        retrievedCartman = newContext.Characters.Include(x => x.Appearances).Single(x => x.Id == 1);
        Console.WriteLine($"007 - {retrievedCartman.Name} - {retrievedCartman.Appearances.Count}");
        newContext.SaveChanges();
      }
    }
  }
}
