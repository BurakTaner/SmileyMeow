using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VetClinicLibrary.Pett.PetGenderr;

public class PetGender
{
    public int PetGenderId { get; set; }
    public string GName { get; set; }
    public List<Pet> Pet { get; set; }
}
