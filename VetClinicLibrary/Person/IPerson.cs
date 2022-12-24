using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VetClinicLibrary.Person;
using VetClinicLibrary.Person.HumanGenderr;
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
    // after locations
    // string DistrictId { get; set; }
    // District District { get; set; }a
    string PhoneNumber { get; set; }
    int UserId { get; set; }
    Userr Userr { get; set; }
    int BalanceId { get; set; }
    Balance Balance { get; set; }

    int PronounId { get; set; }
    Pronoun Pronoun { get; set; }

}
