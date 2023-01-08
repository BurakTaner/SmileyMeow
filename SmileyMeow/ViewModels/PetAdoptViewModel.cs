using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VetClinicLibrary.Pett;
using VetClinicLibrary.Pett.Adopt;
using VetClinicLibrary.Pett.Breedd;
using VetClinicLibrary.Pett.PetGenderr;
using VetClinicLibrary.Pett.Speciee;

namespace SmileyMeow.ViewModels;

public class PetAdoptViewModel
{
    public Pet Pet { get; set; }
    public List<PetGender> PetGenderList { get; set; }
    public List<Specie> SpecieList { get; set; }
    public List<Breed> BreedList { get; set; }
    public AdoptInfo AdoptInfo { get; set; }
}
