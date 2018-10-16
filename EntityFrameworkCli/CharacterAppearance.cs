using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkCli
{
  public class CharacterAppearance
  {
    public int Id { get; set; }
    public Character Character { get; set; }
    public Episode Episode { get; set; }
  }
}
