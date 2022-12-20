using System;

namespace VetClinicLibrary.Appointmentt.StatusLevell;

public interface IAppointment
{
    int PetnPersonId { get; set; }
    int DoctorId { get; set; }
    DateTime TimeCreated { get; set; }
    DateTime AppointmentDate { get; set; }
}
