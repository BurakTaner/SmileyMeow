using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VetClinicLibrary.NotUserParentandPet;
using System.ComponentModel.DataAnnotations;

namespace VetClinicLibrary.Person.HumanGenderr;

public class HumanGender : IHumanGender
{
    public int HumanGenderId { get; set; }
    [Required(ErrorMessage = "{0} can't be empty"),Display(Name = "Gender"), StringLength(15 ,MinimumLength = 4 , ErrorMessage = "{0} must be between {2} - {1}")]
    public string GName { get; set; }
    public List<PetParent> PetParent { get; set; }
}
