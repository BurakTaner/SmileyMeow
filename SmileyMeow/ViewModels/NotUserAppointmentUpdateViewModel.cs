using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VetClinicLibrary.Appointmentt.AppointmentStatuss;
using VetClinicLibrary.NotUserParentandPet;

namespace SmileyMeow.ViewModels;

public class NotUserAppointmentUpdateViewModel
{
    public NotUserAppointment NotUserAppointment { get; set; }
    public List<AppointmentStatus> AppointmentStatusList { get; set; }
}
