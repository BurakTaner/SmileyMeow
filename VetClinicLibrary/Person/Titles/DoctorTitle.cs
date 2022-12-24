using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VetClinicLibrary.Person.Titles;

public class DoctorTitle : IDoctorTitle
{
    public int DoctorTitleId { get; set; }
    public string TFullForm { get; set; }
    public string TShortForm { get; set; }
    public List<Doctor> Doctors { get; set; }
}
