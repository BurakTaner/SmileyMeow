using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VetClinicLibrary.Appointmentt.StatusLevell;
using VetClinicLibrary.NotUserParentandPet;
using VetClinicLibrary.Pett;

namespace VetClinicLibrary.Appointmentt.PatientInformationn;

public class PatientInformation
{
    public int PatientInformationId { get; set; }
    [Required(ErrorMessage = "{0} can't be empty"),Display(Name = "Eating Status"), Range(1,3 , ErrorMessage = "{0} must be choosen correclty")]
    public int EatingStatusId { get; set; }
    public StatusLevel EatingStatus { get; set; }
    [Required(ErrorMessage = "{0} can't be empty"),Display(Name = "Peeing Status"), Range(1,3 , ErrorMessage = "{0} must be choosen correclty")]
    public int PeeingStatusId { get; set; }
    public StatusLevel PeeingStatus { get; set; }
    [Required(ErrorMessage = "{0} can't be empty"),Display(Name = "Energy Status"), Range(1,3 , ErrorMessage = "{0} must be choosen correclty")]
    public int EnergyStatusId { get; set; }
    public StatusLevel EnergyStatus { get; set; }
    [Required(ErrorMessage = "{0} can't be empty"),Display(Name = "Informaiont About Patient"), StringLength(9999, MinimumLength = 10 , ErrorMessage = "{0} must be between {2} - {1}")]
    public string InformationAboutPatient { get; set; }
    [Required(ErrorMessage = "{0} can't be empty"),Display(Name = "Ilnesses In The Past"), StringLength(9999, MinimumLength = 10 , ErrorMessage = "{0} must be between {2} - {1}")]
    public string IlnesssesInThePast { get; set; }
    public NotUserAppointment NotUserAppointment { get; set; }
    public Appointment Appointment { get; set; }
    
}
