using VetClinicLibrary.SchoolTypee;

namespace VetClinicLibrary.Schooll;

public interface ISchool
{
    int SchoolId { get; set; }
    string SName { get; set; }
    int SchoolTypeId { get; set; }
    SchoolType SchoolType { get; set; }
}
