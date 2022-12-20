using VetClinicLibrary.Animall;
using VetClinicLibrary.Person;

namespace VetVetClinicLibrary.Pett;

public interface IPet : IAnimal
{
    public int PetGenderId { get; set; }
    DateTime DOB { get; set; }
    List<PetParent> PetParents { get; set; }

}
