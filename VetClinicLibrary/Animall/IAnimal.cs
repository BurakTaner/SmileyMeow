using VetClinicLibrary.Pett.Breedd;
using VetClinicLibrary.Pett.Speciee;

namespace VetClinicLibrary.Animall;

public interface IAnimal
{
    public int AnimalId { get; set; }
    public string Name { get; set; }
    public int SpecieId { get; set; }
    public int BreedId { get; set; }
    public Specie Specie { get; set; }
    public Breed Breed { get; set; }

}
