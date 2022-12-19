using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VetClinicLibrary.SchoolTypee;

public interface ISchoolType
{
    int SchoolTypeId { get; set; }
    string Name { get; set; }
}
