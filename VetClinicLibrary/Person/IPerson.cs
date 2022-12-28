using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VetClinicLibrary.Person;
using VetClinicLibrary.Person.HumanGenderr;
using VetClinicLibrary.Person.Locationn;
using VetClinicLibrary.Person.Prounounn;
using VetClinicLibrary.User;
namespace VetClinicLibrary.Person;

public interface IPerson
{
    string FirstName { get; set; }
    string MiddleName { get; set; }
    string LastName { get; set; }
    DateTime DOB { get; set; }
    int HumanGenderId { get; set; }
    HumanGender HumanGender { get; set; }
    public int AddressId { get; set; }
    public Address Address { get; set; }
    string PhoneNumber { get; set; }
    int PronounId { get; set; }
    Pronoun Pronoun { get; set; }

}
