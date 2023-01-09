using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VetClinicLibrary.Person.Titles;

public class DoctorTitle : IDoctorTitle
{
    public int DoctorTitleId { get; set; }
    [Required(ErrorMessage = "{0} can't be empty"), Display(Name = "TFullForm"), StringLength(35, MinimumLength = 10, ErrorMessage = "{0} must be between {2} - {1}")]
    public string TFullForm { get; set; }
    [Required(ErrorMessage = "{0} can't be empty"), Display(Name = "TShortForm"), StringLength(5, MinimumLength = 2, ErrorMessage = "{0} must be between {2} - {1}")]
    public string TShortForm { get; set; }
    public List<Doctor> Doctors { get; set; }
}
