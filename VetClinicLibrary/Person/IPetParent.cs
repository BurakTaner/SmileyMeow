using System.Collections.Generic;
using VetClinicLibrary.Person;
using VetClinicLibrary.Person.HumanGenderr;
using VetClinicLibrary.PetnPersonn;
using VetClinicLibrary.User;

namespace VetClinicLibrary.Person;

public interface IPetParent : IPerson
{
    int PetParentId { get; set; }
    int HumanGenderId { get; set; }

    public int UserId { get; set; }
    public Userr Userr { get; set; }

    int BalanceId { get; set; }
    Balance Balance { get; set; }
    List<PetnPerson> PetnPersonn { get; set; }    
}
