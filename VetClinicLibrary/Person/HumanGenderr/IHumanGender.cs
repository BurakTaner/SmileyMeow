using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VetClinicLibrary.Person.HumanGenderr;

public interface IHumanGender
{
    int HumanGenderId { get; set; }
    string GName { get; set; }
}
