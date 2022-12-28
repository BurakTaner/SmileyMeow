using System;
using VetClinicLibrary.Appointmentt.AppointmentStatuss;
using VetClinicLibrary.Person;
using VetClinicLibrary.PetnPersonn;

namespace VetClinicLibrary.Appointmentt.StatusLevell;

public interface IAppointment
{
    int PetnPersonId { get; set; }
    PetnPerson PetnPerson { get; set; }
    int DoctorId { get; set; }
    Doctor Doctor { get; set; }
    DateTime TimeCreated { get; set; }
    DateTime AppointmentDate { get; set; }
    int AppointmentStatussId { get; set;  }
    AppointmentStatus AppointmentStatus { get; set;}
    int DoctorPreferenceId { get; set; }
    Doctor DoctorPreference { get; set; }
}
