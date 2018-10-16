using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkCli
{
  public class Character
  {
    public int Id { get; set; }

    public string Name { get; set; }

    public List<CharacterAppearance> Appearances { get; set; }
  }
}
