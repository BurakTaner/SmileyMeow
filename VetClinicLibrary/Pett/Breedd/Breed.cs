using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VetClinicLibrary.Pett.Breedd;

public class Breed
{
    public int BreedId { get; set; }
    public string BName { get; set; }
    public List<Pet> Pet { get; set; }
}
