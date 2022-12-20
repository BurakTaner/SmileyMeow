using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VetClinicLibrary.Appointmentt.StatusLevell;

namespace VetClinicLibrary.Appointmentt;

public class Appointment : IAppointment
{
    public int PetnPersonId { get; set; }
    public int DoctorId { get; set; }
    public DateTime TimeCreated { get; set; }
    public DateTime AppointmentDate { get; set; }
}
