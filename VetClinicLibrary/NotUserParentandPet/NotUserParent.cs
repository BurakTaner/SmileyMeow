using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VetClinicLibrary.Person.Locationn;

namespace VetClinicLibrary.NotUserParentandPet;

public class NotUserParent : INotUserParent
{
    public int NotUserParentId { get; set; }
    [Required(ErrorMessage = "{0} can't be empty"),Display(Name = "Firstname"), StringLength(20 ,MinimumLength = 3 , ErrorMessage = "{0} must be between {2} - {1}")]
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    [Required(ErrorMessage = "{0} can't be empty"),Display(Name = "LAstname"), StringLength(60 ,MinimumLength = 3 , ErrorMessage = "{0} must be between {2} - {1}")]
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    [Required(ErrorMessage = "{0} can't be empty"),Display(Name = "Email"), StringLength(26 ,MinimumLength = 11 , ErrorMessage = "{0} must be between {2} - {1}")]
    public string Email { get; set; }
    public int AddressId { get; set; }
    public Address Address { get; set; }
    public List<NotUserParentnPet> NotUsersParentsPets { get; set; }
}
