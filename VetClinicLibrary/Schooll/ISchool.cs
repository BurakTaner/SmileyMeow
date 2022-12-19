using VetClinicLibrary.SchoolTypee;

namespace VetClinicLibrary.Schooll;

public interface ISchool
{
    int SchoolId { get; set; }
    string Name { get; set; }
    int SchoolTypeId { get; set; }
    SchoolType SchoolType { get; set; }
}
