using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VetClinicLibrary.Pett.PetGenderr;

public class PetGender
{
    public int PetGenderId { get; set; }
    [Required(ErrorMessage = "{0} can't be empty"), Display(Name = "Pet Gender"), StringLength(15, MinimumLength = 6, ErrorMessage = "{0} must be between {2} - {1}")]
    public string GName { get; set; }
    public List<Pet> Pet { get; set; }
}
