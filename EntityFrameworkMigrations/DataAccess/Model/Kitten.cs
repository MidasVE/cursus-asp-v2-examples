using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkMigrations.DataAccess.Model
{
  [Table("Meow")]
  public class Cat
  {
    [Key]
    public int Id { get; set; }

    [StringLength(200)]
    public string Name { get; set; }

    public DateTime DateOfBirth { get; set; }

    [Required]
    public Cat Parent { get; set; }

    public bool IsMale { get; set; }

    [Required]
    public Person Slave { get; set; }

    [NotMapped]
    public bool IsKitten => DateOfBirth.AddYears(1) > DateTime.Now;
  }
}