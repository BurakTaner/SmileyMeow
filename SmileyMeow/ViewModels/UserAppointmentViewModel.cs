using SmileyMeow.DTOs;
using VetClinicLibrary.Appointmentt;
using VetClinicLibrary.Appointmentt.PatientInformationn;
using VetClinicLibrary.Appointmentt.StatusLevell;
using VetClinicLibrary.Person;
using VetClinicLibrary.Pett;

namespace SmileyMeow.ViewModels;

public class UserAppointmentViewModel 
{
    public Appointment Appointment { get; set; }
    public List<Pet> AlreadyAddedPets { get; set; }
    public List<Doctor> DoctorList { get; set; }
    public PatientInformation PatientInformation { get; set; }
    public List<StatusLevel> StatusLevelList { get; set; }
    public SelectedFormInputUserDTO SelectedFormInputUserDTO { get; set; }
    
}

