using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VetClinicLibrary.NotUserParentandPet;

public class NotUserParentnPet
{
    public int NotUserParenPetId { get; set; }
    public int NotUserParentId { get; set; }
    public int AnimalId { get; set; }
    public NotUserParent NotUserParent { get; set; }
    public NotUserParentsPet NotUserParentsPet { get; set; }
}
