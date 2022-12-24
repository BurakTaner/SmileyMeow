using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VetClinicLibrary.Person.DoctorInfoo;

public class DoctorInfo : IDoctorInfo
{
    public int DoctorId { get; set; }
    public string DoctorInformation { get; set; }
    public Doctor Doctor { get; set; }
}
