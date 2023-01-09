using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VetClinicLibrary.Person;
using VetClinicLibrary.Pett;

namespace VetClinicLibrary.AdoptionPet
{
    public class AdoptionJoinTable
    {
        public int AdoptJoinTableId { get; set; }
        public int AnimalId { get; set; }
        public int PetParentId { get; set; }
        public string PetParentRequestText { get; set; }
        public bool IsConfirmed { get; set; }
        public Pet Pet { get; set; }
        public PetParent PetParent { get; set; }
    }
}