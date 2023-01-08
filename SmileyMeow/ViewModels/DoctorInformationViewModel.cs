using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VetClinicLibrary.Person;
using VetClinicLibrary.Person.DoctorInformationn;

namespace SmileyMeow.ViewModels;

public class DoctorInformationViewModel
{
    public DoctorInformation DoctorInformation { get; set; }
    public List<Doctor> DoctorList { get; set; }
}
