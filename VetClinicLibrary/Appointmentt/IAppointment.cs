using System;
using VetClinicLibrary.Appointmentt.AppointmentStatuss;

namespace VetClinicLibrary.Appointmentt.StatusLevell;

public interface IAppointment
{
    int PetnPersonId { get; set; }
    int DoctorId { get; set; }
    DateTime TimeCreated { get; set; }
    DateTime AppointmentDate { get; set; }
    int AppointmentStatussId { get; set;  }
    AppointmentStatus AppointmentStatus { get; set;}
    
}
