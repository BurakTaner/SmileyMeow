using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VetClinicLibrary.Person;
using VetClinicLibrary.Pett;

namespace VetClinicLibrary.PetnPersonn;

public class PetnPerson
{
    public int PetnPersonId { get; set; }
    public int PetParentId { get; set; }
    public PetParent PetParent { get; set; }
    public int AnimalId { get; set; }
    public Pet Pet { get; set; }
}
