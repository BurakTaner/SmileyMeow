using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VetClinicLibrary.Schooll;
using VetClinicLibrary.SchoolTypee;

namespace SmileyMeow.ViewModels;

public class SchoolViewModel
{
    public School School { get; set; }
    public List<SchoolType> SchoolTypeList { get; set; }
}
