using System.ComponentModel.DataAnnotations;
using VetClinicLibrary.Pett;

namespace VetClinicLibrary.Pett.Adopt;

public class AdoptInfo : IAdoptInfo
{
    // Primary Key
    public int AnimalId { get; set; }
    public List<Pet> Pet { get; set; }
    public string AdoptText { get; set; }
}
