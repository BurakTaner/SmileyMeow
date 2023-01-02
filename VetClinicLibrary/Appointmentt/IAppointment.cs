using System;
using VetClinicLibrary.Appointmentt.AppointmentStatuss;
using VetClinicLibrary.Appointmentt.PatientInformationn;
using VetClinicLibrary.Person;
using VetClinicLibrary.PetnPersonn;

namespace VetClinicLibrary.Appointmentt.StatusLevell;

public interface IAppointment
{
    public int AppointmentId { get; set; }
    int PetnPersonId { get; set; }
    PetnPerson PetnPerson { get; set; }
    int DoctorId { get; set; }
    Doctor Doctor { get; set; }
    DateTime TimeCreated { get; set; }
    DateTime AppointmentDate { get; set; }
    int AppointmentStatussId { get; set;  }
    AppointmentStatus AppointmentStatus { get; set;}
    int PatientInformationId { get; set; }
    PatientInformation PatientInformation { get; set; }
}
