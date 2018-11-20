using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkMigrations.DataAccess.Model
{
  [Table("Persons")]
  public class Person
  {
    [Key]
    public int Id { get; set; }
    
    public decimal Wage { get; set; }
    
    [StringLength(500)]
    public string Name { get; set; }
  }
}