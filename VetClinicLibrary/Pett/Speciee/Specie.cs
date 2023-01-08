using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace VetClinicLibrary.Pett.Speciee;

public class Specie
{
    public int SpecieId { get; set; }
    [Required(ErrorMessage = "{0} can't be empty"), Display(Name = "Specie"), StringLength(35, MinimumLength = 10, ErrorMessage = "{0} must be between {2} - {1}")]
    public string SName { get; set; }
    public List<Pet> Pet { get; set; }
}
