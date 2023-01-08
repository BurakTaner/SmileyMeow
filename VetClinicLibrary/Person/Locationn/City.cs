using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VetClinicLibrary.Person.Locationn;

public class City : ICity
{
    public int CityId { get; set; }
    [Required(ErrorMessage = "{0} can't be empty"),Display(Name = "City"), StringLength(15 ,MinimumLength = 4 , ErrorMessage = "{0} must be between {2} - {1}")]
    public string CName { get; set; }
    public List<District> Districts { get; set; }
}
