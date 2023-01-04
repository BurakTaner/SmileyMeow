using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VetClinicLibrary.Person;
using VetClinicLibrary.User;

namespace SmileyMeow.ViewModels;

public class RegisterViewModel
{
    
    public int UserrId { get; set; }
    [Display(Name = "Email"),Required(ErrorMessage = "{0} must be filled"), StringLength(60, MinimumLength = 6, ErrorMessage = "{0} needs to be between {1} - {2}")]
    public string Emaill { get; set; }
    [Display(Name = "Password"), Required(ErrorMessage = "{0} must be filled"), StringLength(30, MinimumLength = 6, ErrorMessage = "{0} needs to be between {1} - {2}")]
    public string Passwordd { get; set; }
    [Display(Name = "ConfirmPassword"),Compare("Passwordd", ErrorMessage = "Password and {0} needs to be same"), DataType(DataType.Password) ]
    public string ConfirmPasswordd { get; set; }
    [Display(Name = "Role"), Required(ErrorMessage = "{0} must be filled"), Range(5,7, ErrorMessage = "Out of range")]
    public int RoleeId { get ; set ; } = 5;
    public Rolee Rolee { get ; set ; }
    public List<PetParent> PetParent { get; set; }
    public List<Doctor> Doctor { get; set; }
}
