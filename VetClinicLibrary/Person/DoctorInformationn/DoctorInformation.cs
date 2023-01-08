using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VetClinicLibrary.Person.DoctorInformationn;

public class DoctorInformation : IDoctorInformation
{
    public int DoctorId { get; set; }
    [Required(ErrorMessage = "{0} can't be empty"),Display(Name = "Doctor Information"), StringLength(250 ,MinimumLength = 15 , ErrorMessage = "{0} must be between {2} - {1}")]
    public string DoctorInformationText { get; set; }
    public Doctor Doctor { get; set; }
}
