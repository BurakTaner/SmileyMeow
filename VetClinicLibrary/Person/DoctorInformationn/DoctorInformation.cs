using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VetClinicLibrary.Person.DoctorInformationn;

public class DoctorInformation : IDoctorInformation
{
    public int DoctorId { get; set; }
    public string DoctorInformationText { get; set; }
    public Doctor Doctor { get; set; }
}
