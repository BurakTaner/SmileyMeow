using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VetClinicLibrary.Schooll;
using VetClinicLibrary.SchoolTypee;

namespace VetClinicLibrary.Schooll;

public class School : ISchool
{
    public int SchoolId { get ; set ; }
    public string Name { get ; set ; }
    public int SchoolTypeId { get ; set ; }
    public SchoolType SchoolType { get ; set ; }
}
