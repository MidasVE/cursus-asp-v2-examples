using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Csharp_Validation.Models
{
  public class KittenCreateViewModel
  {
    public List<SelectListItem> OtherKittens { get; set; }
    public string SelectedMother {get;set;}
    public Kitten Kitten { get; set; }
  }

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
    [DateInThePastValidator]
    public DateTime DateOfBirth { get; set; }

    [Display(Name = "Mannelijk")]
    public bool IsMale { get; set; }

    public Kitten Mother { get; set; }
  }
}