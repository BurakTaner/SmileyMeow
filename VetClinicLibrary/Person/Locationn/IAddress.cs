using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VetClinicLibrary.Person.Locationn;

public interface IAddress
{
    int AddressId { get; set; }
    int DistrictId { get; set; }
    District District { get; set; }
    string AddressDetails { get; set; }
}
