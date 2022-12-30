using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VetClinicLibrary.NotUserParentandPet;

namespace VetClinicLibrary.Appointmentt.AppointmentStatuss;

public interface IAppointmentStatus
{
    int AppointmentStatussId { get; set; }
    string Status { get; set; }
    List<Appointment> Appointments { get; set; }
    List<NotUserAppointment> NotUserAppointment { get; set; }
}
