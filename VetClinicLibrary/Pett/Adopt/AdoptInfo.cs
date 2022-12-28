using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VetClinicLibrary.Pett;

namespace VetClinicLibrary.Pett.Adopt;

public class AdoptInfo : IAdoptInfo
{
    // Primary Key
    public int AdoptInfoId { get; set; }
    public Pet Pet { get; set; }
    public string AdoptText { get; set; }
}
