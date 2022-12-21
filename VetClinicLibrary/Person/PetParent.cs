using System;
using VetClinicLibrary.User;

namespace VetClinicLibrary.Person;

public class PetParent : IPetParent
{
    public int PetParentId { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public DateTime DOB { get; set; }
    public string PhoneNumber { get; set; }
    public int UserId { get; set; }
    public Userr Userr { get; set; }
    public int BalanceId { get; set; }
    public Balance Balance { get; set; }
    // public string DistrictId { get ; set ; }
    // public District District { get ; set ; }
}
