using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VetClinicLibrary.Person.Prounounn;

public class Pronoun : IPronoun
{
    public int ProunounId { get; set; }
    [Required(ErrorMessage = "{0} can't be empty"),Display(Name = "Pronoun"), StringLength(20 ,MinimumLength = 7 , ErrorMessage = "{0} must be between {2} - {1}")]
    public string PName { get; set; }
    public List<Doctor> Doctors { get; set; }
    public List<PetParent> PetParents { get; set; }
}
