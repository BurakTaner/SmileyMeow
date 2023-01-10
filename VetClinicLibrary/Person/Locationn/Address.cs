using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VetClinicLibrary.NotUserParentandPet;

namespace VetClinicLibrary.Person.Locationn;

public class Address : IAddress
{
    public int AddressId { get; set; }
    [Range(1,999,ErrorMessage = "Out of range")]
    public int? DistrictId { get; set; }
    public District District { get; set; }
    public string AddressDetails { get; set; }
    public PetParent PetParent { get; set; }
    public NotUserParent NotUserParent { get; set; }
}
