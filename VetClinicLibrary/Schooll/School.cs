using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VetClinicLibrary.Schooll;
using VetClinicLibrary.SchoolTypee;

namespace VetClinicLibrary.Schooll;

public class School : ISchool
{
    public int SchoolId { get ; set ; }
    [Required(ErrorMessage = "{0} can't be empty"),Display(Name = "School"), StringLength(60 ,MinimumLength = 14 , ErrorMessage = "{0} must be between {2} - {1}")]
    public string SName { get ; set ; }
    [Required(ErrorMessage = "{0} can't be empty"),Display(Name = "School Type"), Range(1,99, ErrorMessage = "Choseen an invalid {0}, please select a valid one")]
    public int SchoolTypeId { get ; set ; }
    public SchoolType SchoolType { get ; set ; }
}
