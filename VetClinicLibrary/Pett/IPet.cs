using System;
using System.Collections.Generic;
using VetClinicLibrary.Animall;
using VetClinicLibrary.Appointmentt.PatientInformationn;
using VetClinicLibrary.Person;
using VetClinicLibrary.PetnPersonn;
using VetClinicLibrary.Pett.Adopt;

namespace VetVetClinicLibrary.Pett;

public interface IPet : IAnimal
{
    public int PetGenderId { get; set; }
    DateTime DOB { get; set; }
    List<PetnPerson> PetnPersonn { get; set; }    
}
