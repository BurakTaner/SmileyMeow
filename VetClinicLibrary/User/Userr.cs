using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VetClinicLibrary.Person;

namespace VetClinicLibrary.User;

public class Userr : IUserr
{
    public int UserrId { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    
    [Compare("Password")]
    public string PasswordRepeat { get; set; }
    public int RoleeId { get ; set ; }
    public Rolee Rolee { get ; set ; }

    public List<PetParent> PetParent { get; set; }
    public List<Doctor> Doctor { get; set; }
}
