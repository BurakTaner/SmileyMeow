using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VetClinicLibrary.User;

public interface IUserr
{
    int UserrId { get; set; }
    string Email { get; set; }
    string Password { get; set;}
    string PasswordRepeat { get; set;}
    int RoleeId { get; set; }
    Rolee Rolee { get; set; }
}
