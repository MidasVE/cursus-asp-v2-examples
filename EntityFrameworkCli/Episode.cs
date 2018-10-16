using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkCli
{
  public class Episode
  {
    public int Id { get; set; }

    public string EpisodeNumber { get; set; }

    public List<CharacterAppearance> Appearances { get; set; }

    public Series Show { get; internal set; }
  }
}
