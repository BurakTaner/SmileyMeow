using System.ComponentModel.DataAnnotations;

namespace VetClinicLibrary.SchoolTypee;

public class SchoolType : ISchoolType
{
    public int SchoolTypeId { get; set; }
    [Required(ErrorMessage = "{0} can't be empty"),Display(Name = "School Type"), StringLength(10 ,MinimumLength = 6 , ErrorMessage = "{0} must be between {2} - {1}")]
    public string STName { get; set; }
}
