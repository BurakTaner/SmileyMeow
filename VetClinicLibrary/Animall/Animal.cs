using VetClinicLibrary.Pett.Breedd;
using VetClinicLibrary.Pett.Speciee;

namespace VetClinicLibrary.Animall;

public class Animal : IAnimal
{
    // for general information about animals
    public int AnimalId { get; set; }
    public string Name { get; set; }
    public int SpecieId { get; set; }
    public Specie Specie { get; set; }
    public int BreedId { get; set; }
    public Breed Breed { get; set; }
}
