using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VetClinicLibrary.Appointmentt;
using VetClinicLibrary.Appointmentt.AppointmentStatuss;

namespace SmileyMeow.ViewModels;

public class AppointmentsViewModel
{
    public Appointment Appointment { get; set; }
    public List<AppointmentStatus> AppointmentStatusList { get; set; }
    
}
