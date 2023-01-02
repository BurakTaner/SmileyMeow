using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VetClinicLibrary.Person.Locationn;

namespace VetClinicLibrary.Person;

public interface IBasePerson
{
    string FirstName { get; set; }
    string MiddleName { get; set; }
    string LastName { get; set; }
    string PhoneNumber { get; set; }
}
