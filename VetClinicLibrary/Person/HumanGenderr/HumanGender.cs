using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VetClinicLibrary.NotUserParentandPet;

namespace VetClinicLibrary.Person.HumanGenderr;

public class HumanGender : IHumanGender
{
    public int HumanGenderId { get; set; }
    public string GName { get; set; }
    public List<PetParent> PetParent { get; set; }
}
