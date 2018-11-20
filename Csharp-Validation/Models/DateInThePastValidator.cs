using System;
using System.ComponentModel.DataAnnotations;

namespace Csharp_Validation.Models
{
  public class DateInThePastValidator : ValidationAttribute
  {
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
      var kitten = (Kitten)validationContext.ObjectInstance;

      if (kitten.DateOfBirth > DateTime.Now)
      {
        return new ValidationResult("Geboortedatum mag niet in de toekomst liggen.");
      }

      return ValidationResult.Success;
    }
  }
}