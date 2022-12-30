using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VetClinicLibrary.NotUserParentandPet;

namespace VetClinicLibrary.Person.Locationn;

public interface IAddress
{
    int AddressId { get; set; }
    int DistrictId { get; set; }
    District District { get; set; }
    string AddressDetails { get; set; }
    public PetParent PetParent { get; set; }
    public NotUserParent NotUserParent { get; set; }
}
