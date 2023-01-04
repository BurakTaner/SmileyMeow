using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VetClinicLibrary.Appointmentt.PatientInformationn;
using VetClinicLibrary.Pett.Breedd;
using VetClinicLibrary.Pett.PetGenderr;
using VetClinicLibrary.Pett.Speciee;

namespace VetClinicLibrary.NotUserParentandPet;

public class NotUserParentsPet : INotUserParentsPet
{
    public int AnimalId { get; set; }
    public string Name { get; set; }
    public DateTime DOB { get; set; }
    public int PetGenderId { get; set; }
    public PetGender PetGender { get; set; }
    public int SpecieId { get; set; }
    public Specie Specie { get; set; }
    public int BreedId { get; set; }
    public Breed Breed { get; set; }
}
