using SmileyMeow.DTOs;
using VetClinicLibrary.Appointmentt.PatientInformationn;
using VetClinicLibrary.Appointmentt.StatusLevell;
using VetClinicLibrary.NotUserParentandPet;
using VetClinicLibrary.Person;
using VetClinicLibrary.Person.Locationn;
using VetClinicLibrary.Pett.Breedd;
using VetClinicLibrary.Pett.PetGenderr;
using VetClinicLibrary.Pett.Speciee;

namespace SmileyMeow.ViewModels;

public class NotUserAppointmentViewModel
{
    public NotUserParentsPet NotUserParentsPet { get; set; }
    public NotUserParent NotUserParent { get; set; }
    public NotUserAppointment NotUsersAppointment { get; set; }
    public Address Address { get; set; }
    public List<Doctor> DoctorList { get; set; }
    public List<PetGender> PetGenderList { get; set; }
    public List<Specie> SpecieList { get; set; }
    public List<Breed> BreedList { get; set; }
    public List<StatusLevel> StatusLevelList { get; set; }
    public List<City> CityList { get; set; }
    public List<District> DistrictList { get; set; }
    public PatientInformation PatientInformation { get; set; }
    public SelectedFormInputNotUserDTO SelectedFormInputNotUserDTO { get; set; }
}