using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VetClinicLibrary.Person;
using VetClinicLibrary.NotUserParentandPet;

namespace VetClinicLibrary.NotUserParentandPet;

public interface INotUserParent : IBasePerson
{
    public int NotUserParentId { get; set; }
    string Email { get; set; }
    List<NotUserParentnPet> NotUsersParentsPets { get; set; }
}
