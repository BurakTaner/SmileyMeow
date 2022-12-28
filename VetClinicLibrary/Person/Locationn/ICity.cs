using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VetClinicLibrary.Person.Locationn;

public interface ICity
{
    int CityId { get; set; }
    string CName { get; set; }
    List<District> Districts { get; set; }
}
