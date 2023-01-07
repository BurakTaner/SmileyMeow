using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VetClinicLibrary.Pett.Breedd;

public class Breed
{
    public int BreedId { get; set; }
    [Required(ErrorMessage = "{0} can't be empty"), Display(Name = "Breed"), StringLength(25, MinimumLength = 5, ErrorMessage = "{0} must be between {2} - {1}")]
    public string BName { get; set; }
    public List<Pet> Pet { get; set; }
}
