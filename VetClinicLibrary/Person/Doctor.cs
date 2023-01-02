using System;
using VetClinicLibrary.Person.DoctorInformationn;
using VetClinicLibrary.Person.HumanGenderr;
using VetClinicLibrary.Person.Locationn;
using VetClinicLibrary.Person.Prounounn;
using VetClinicLibrary.Person.Titles;
using VetClinicLibrary.Schooll;
using VetClinicLibrary.User;

namespace VetClinicLibrary.Person;

public class Doctor : IDoctor
{
    public int DoctorId { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public DateTime? DOB { get; set; }
    public int? HumanGenderId { get; set; }
    public HumanGender HumanGender { get; set; }
    public string PhoneNumber { get; set; }
    public int UserId { get; set; }
    public Userr Userr { get; set ; }
    public int? BalanceId { get ; set ; }
    public Balance Balance { get; set; }
    public School School { get; set; }
    public int? DoctorTitleId { get; set; }
    public DoctorTitle DoctorTitle { get; set; }
    public DoctorInformation DoctorInformation { get; set; }
    public int? PronounId { get; set; }
    public Pronoun Pronoun { get; set; }
    public int? AddressId { get; set; }
    public Address Address { get; set; }
}
