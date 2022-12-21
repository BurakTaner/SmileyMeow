using VetClinicLibrary.Person;
using VetClinicLibrary.Person.HumanGenderr;
using VetClinicLibrary.User;

namespace VetClinicLibrary.Person;

public interface IPetParent : IPerson
{
    int PetParentId { get; set; }
    int HumanGenderId { get; set; }
    HumanGender HumanGender { get; set; }
}
