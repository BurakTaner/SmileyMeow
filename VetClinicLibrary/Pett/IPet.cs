using System;
using System.Collections.Generic;
using VetClinicLibrary.Animall;
using VetClinicLibrary.Appointmentt.PatientInformationn;
using VetClinicLibrary.Person;
using VetClinicLibrary.Pett.Adopt;

namespace VetVetClinicLibrary.Pett;

public interface IPet : IAnimal, IAdoptable, IHasPatientInformation
{
    public int PetGenderId { get; set; }
    DateTime DOB { get; set; }
    List<PetParent> PetParents { get; set; }

}
