using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VetClinicLibrary.Person.Locationn;

public class City : ICity
{
    public int CityId { get; set; }
    public string CName { get; set; }
    public List<District> Districts { get; set; }
}
