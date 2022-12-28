using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VetClinicLibrary.Animall;
using VetClinicLibrary.Appointmentt.PatientInformationn;
using VetClinicLibrary.Pett.Breedd;
using VetClinicLibrary.Pett.PetGenderr;
using VetClinicLibrary.Pett.Speciee;

namespace VetClinicLibrary.NotUserParentandPet;

public interface INotUserParentsPet : IAnimal
{
    public DateTime DOB { get; set; }
    public int PetGenderId { get; set; }
    public PetGender PetGender { get; set; }
    public int PatientInformationId { get; set; }
    public PatientInformation PatientInformation { get; set; }
}
