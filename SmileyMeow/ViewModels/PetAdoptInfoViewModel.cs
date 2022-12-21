using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VetClinicLibrary.Pett;
using VetClinicLibrary.Pett.Adopt;

namespace SmileyMeow.ViewModels;

public class PetAdoptInfoViewModel
{
    public Pet AdoptablePet { get; set; }
    public AdoptInfo AdoptablePetInfo { get; set; }
    public int PetAge { get; set; }
}
