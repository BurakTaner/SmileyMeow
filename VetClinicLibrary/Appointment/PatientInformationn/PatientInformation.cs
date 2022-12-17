using VetClinicLibrary.Appointment.StatusLevell;

namespace VetClinicLibrary.Appointment.PatientInformationn;

public class PatientInformation
{
    public int PatientInformationId { get; set; }
    public int EatingStatusId { get; set; }
    public StatusLevel EatingStatus { get; set; }
    public int PeeingStatusId { get; set; }
    public StatusLevel PeeingStatus { get; set; }
    public int EnergyStatusId { get; set; }
    public StatusLevel EnergyStatus { get; set; }
    public string Description { get; set; }

}
