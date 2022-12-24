using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VetClinicLibrary.Person.Titles;

public interface IDoctorTitle
{
    int DoctorTitleId { get; set; }
    string TFullForm { get; set; }
    string TShortForm { get; set; }
    List<Doctor> Doctors { get; set; }
}
