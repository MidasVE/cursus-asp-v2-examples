using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkCli
{
  public class Series
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Episode> Episodes { get; set; }
  }
}
