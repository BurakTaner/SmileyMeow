using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VetClinicLibrary.Pett;

namespace SmileyMeow.DTOs;

public class SelectedFormInputUserDTO
{
    public int SelectedPet { get; set; }
    public Pet Pet { get; set; }
}
