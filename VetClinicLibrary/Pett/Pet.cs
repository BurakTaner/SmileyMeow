using VetClinicLibrary.Pett.Adopt;
using VetClinicLibrary.Pett.Breedd;
using VetClinicLibrary.Pett.PetGenderr;
using VetClinicLibrary.Pett.Speciee;
using VetVetClinicLibrary.Pett;
using VetClinicLibrary.Person;
using VetClinicLibrary.Appointmentt.PatientInformationn;
using System;
using System.Collections.Generic;
using VetClinicLibrary.PetnPersonn;

namespace VetClinicLibrary.Pett;

public class Pet : IPet
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
    public int? AdoptInfoId { get; set; }
    public bool IsAdoptable { get; set; }
    public AdoptInfo AdoptionInfo { get; set; }
    public List<PetnPerson> PetnPersonn { get; set; }
}
