using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VetClinicLibrary.Appointmentt.AppointmentStatuss;

public class AppointmentStatus : IAppointmentStatus
{
    public int AppointmentStatussId { get; set; }
    public string Status { get; set; }
    public List<Appointment> Appointments { get; set; }
}
