using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VetClinicLibrary.Person.Locationn;

public interface IDistrict
{
    public int DistrictId { get; set; }
    public string DName { get; set; }
    int CityId { get; set; }
    public City City { get; set; }
    public List<Address> Addresses { get; set; }
}
