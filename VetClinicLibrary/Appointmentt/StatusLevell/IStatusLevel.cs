using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VetClinicLibrary.Appointmentt.StatusLevell;

public interface IStatusLevel
{
    int StatusLevelId { get; set; }
    string Name { get; set; }
}
