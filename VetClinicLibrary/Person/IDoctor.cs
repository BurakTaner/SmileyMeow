using VetClinicLibrary.Person.DoctorInformationn;
using VetClinicLibrary.Person.HumanGenderr;
using VetClinicLibrary.User;

namespace VetClinicLibrary.Person;

public interface IDoctor : IPerson
{
    int DoctorId { get; set; }
    int? DoctorTitleId { get; set; }
    public int UserId { get; set; }
    public Userr Userr { get; set; }
    public DoctorInformation DoctorInformation { get; set; }
    int? BalanceId { get; set; }
    Balance Balance { get; set; }
}
