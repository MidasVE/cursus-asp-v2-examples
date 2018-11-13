using System;
using System.ComponentModel.DataAnnotations;

namespace Csharp_Validation.Models
{

  public class Kitten
  {
    public int Id { get; set; }

    [StringLength(60, MinimumLength = 3)]
    [Required]
    public string Name { get; set; }

    [Display(Name = "Aaibaarheidsfactor")]
    [Range(1, 10, ErrorMessage = "Ofwel te leuk ofwel niet leuk genoeg; kies een nummer tussen 1 en 10")]
    [Required]
    public int NiceScale { get; set; }

    [Display(Name = "Geboortedatum")]
    [DataType(DataType.Date)]
    [Required]
    public DateTime DateOfBirth { get; set; }
  }
}