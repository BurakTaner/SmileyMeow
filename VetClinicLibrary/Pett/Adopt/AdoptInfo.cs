using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VetClinicLibrary.Pett;

namespace VetClinicLibrary.Pett.Adopt;

public class AdoptInfo : IAdoptInfo
{
    // Primary Key
    public int AdoptInfoId { get; set; }
    public Pet Pet { get; set; }
    [Required(ErrorMessage = "{0} can't be empty"), Display(Name = "AdoptText"), StringLength(9999, MinimumLength = 10, ErrorMessage = "{0} must be between {2} - {1}")]
    public string AdoptText { get; set; }
}
