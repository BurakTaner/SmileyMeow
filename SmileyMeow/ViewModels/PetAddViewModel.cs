using VetClinicLibrary.Pett;
using VetClinicLibrary.Pett.Breedd;
using VetClinicLibrary.Pett.PetGenderr;
using VetClinicLibrary.Pett.Speciee;

namespace SmileyMeow.ViewModels;

public class PetAddViewModel
{
    public Pet Pet { get; set; }
    public List<PetGender> PetGenderList { get; set; }
    public List<Breed> BreedList { get; set; }
    public List<Specie> SpecieList { get; set; }
}
