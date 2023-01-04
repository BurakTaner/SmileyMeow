using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VetClinicLibrary.User;

public interface IUserr
{
    int UserrId { get; set; }
    string Emaill { get; set; }
    string Passwordd { get; set;}
    string ConfirmPasswordd { get; set;}
    int RoleeId { get; set; }
    Rolee Rolee { get; set; }
}
