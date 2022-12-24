using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VetClinicLibrary.Schooll;

namespace VetClinicLibrary.Person;

public interface IDoctor : IPerson
{
    int DoctorId { get; set; }
    int DoctorTitleId { get; set; }
}
