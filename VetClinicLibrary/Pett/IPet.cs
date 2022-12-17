using VetClinicLibrary.Animall;

namespace VetVetClinicLibrary.Pett;

public interface IPet : IAnimal
{
    public int PetGenderId { get; set; }
    DateTime DOB { get; set; }

}
