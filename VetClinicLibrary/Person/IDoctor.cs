using VetClinicLibrary.Person.DoctorInformationn;
using VetClinicLibrary.User;

namespace VetClinicLibrary.Person;

public interface IDoctor : IPerson
{
    int DoctorId { get; set; }
    int DoctorTitleId { get; set; }
    int HumanGenderId { get; set; }

    public int UserId { get; set; }
    public Userr Userr { get; set; }
    public DoctorInformation DoctorInformation { get; set; }
    int BalanceId { get; set; }
    Balance Balance { get; set; }
}
