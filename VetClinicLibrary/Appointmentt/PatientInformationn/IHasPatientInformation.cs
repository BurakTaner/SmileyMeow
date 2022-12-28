using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VetClinicLibrary.Appointmentt.PatientInformationn;

public interface IHasPatientInformation
{
    int PatientInformationId { get; set; }
    PatientInformation PatientInformation { get; set;}
}
