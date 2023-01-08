using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VetClinicLibrary.User;

namespace SmileyMeow.ViewModels;

public class UserRoleeChangeViewModel
{
    public Userr Userr { get; set; }
    public List<Rolee> RoleeList { get; set; }
}
