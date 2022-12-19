using VetClinicLibrary.Person;
using VetClinicLibrary.User;

namespace VetClinicLibrary.Person;

public interface IPetParent : IPerson
{
    int PetParentId { get; set; }
}
