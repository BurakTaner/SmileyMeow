using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VetClinicLibrary.Appointmentt.AppointmentStatuss;
using VetClinicLibrary.Appointmentt.StatusLevell;

namespace VetClinicLibrary.Appointmentt;

public class Appointment : IAppointment
{
    public int PetnPersonId { get; set; }
    public int DoctorId { get; set; }
    public DateTime TimeCreated { get; set; } = DateTime.Now;
    public DateTime AppointmentDate { get; set; }
    public int AppointmentStatussId { get; set; }
    public AppointmentStatus AppointmentStatus { get; set; }
}
