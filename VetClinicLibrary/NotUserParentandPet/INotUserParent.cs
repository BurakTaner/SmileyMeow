using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VetClinicLibrary.Person;
using VetClinicLibrary.NotUserParentandPet;
using VetClinicLibrary.Person.Locationn;

namespace VetClinicLibrary.NotUserParentandPet;

public interface INotUserParent : IBasePerson
{
    public int NotUserParentId { get; set; }
    string Email { get; set; }
    List<NotUserParentnPet> NotUsersParentsPets { get; set; }
    public int AddressId { get; set; }
    public Address Address { get; set; }
}
