using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VetClinicLibrary.Appointmentt.AppointmentStatuss;

namespace SmileyMeow.DTOs;

public class AppointmentUpdateDTO
{
    [Display(Name = "Appoinment Status"), Required(ErrorMessage = "{0} is empty"), Range(6,10, ErrorMessage = "You have choseen an invalid {0}")]
    public int AppointmentStatusId { get; set; }
    public AppointmentStatus AppointmentStatus { get; set; }
}
