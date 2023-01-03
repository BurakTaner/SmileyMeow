using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VetClinicLibrary.NotUserParentandPet;

namespace VetClinicLibrary.Person.HumanGenderr;

public interface IHumanGender
{
    int HumanGenderId { get; set; }
    string GName { get; set; }
    List<PetParent> PetParent { get; set; }
}
