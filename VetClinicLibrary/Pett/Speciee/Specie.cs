using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace VetClinicLibrary.Pett.Speciee;

public class Specie
{
    public int SpecieId { get; set; }
    public string SName { get; set; }
    public List<Pet> Pet { get; set; }
}
