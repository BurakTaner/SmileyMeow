using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VetClinicLibrary.Person.Prounounn;

public class Pronoun : IPronoun
{
    public int ProunounId { get; set; }
    public string PName { get; set; }
    public Doctor Doctor { get; set; }
    public PetParent PetParent { get; set; }
}
