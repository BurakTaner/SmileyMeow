using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VetClinicLibrary.Person.Locationn;

public class District : IDistrict
{
    public int DistrictId { get; set; }
    public string DName { get; set; }
    public int CityId { get; set; }
    public City City { get; set; }
}
