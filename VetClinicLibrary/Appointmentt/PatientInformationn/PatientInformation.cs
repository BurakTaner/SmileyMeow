using System.Collections.Generic;
using VetClinicLibrary.Appointmentt.StatusLevell;
using VetClinicLibrary.NotUserParentandPet;
using VetClinicLibrary.Pett;

namespace VetClinicLibrary.Appointmentt.PatientInformationn;

public class PatientInformation
{
    public int PatientInformationId { get; set; }
    public int EatingStatusId { get; set; }
    public StatusLevel EatingStatus { get; set; }
    public int PeeingStatusId { get; set; }
    public StatusLevel PeeingStatus { get; set; }
    public int EnergyStatusId { get; set; }
    public StatusLevel EnergyStatus { get; set; }
    public string InformationAboutPatient { get; set; }
    public string IlnesssesInThePast { get; set; }
    public NotUserAppointment NotUserAppointment { get; set; }
    public Appointment Appointment { get; set; }
    
}
