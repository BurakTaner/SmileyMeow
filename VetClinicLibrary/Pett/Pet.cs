using VetClinicLibrary.Pett.Adopt;
using VetClinicLibrary.Appointment.PatientInformationn;
using VetClinicLibrary.Pett.Breedd;
using VetClinicLibrary.Pett.Gender;
using VetClinicLibrary.Pett.Speciee;
using VetVetClinicLibrary.Pett;

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
    // after create petparent
    // List<PetParent> PetParent { get; set; }
    public PatientInformation Patientİnformation { get; set; }
    public AdoptInfo AdoptionInfo { get; set; }
}
