using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VetClinicLibrary.User;

public class Rolee : IRolee
{
    public int RoleeId { get ; set ; }
    [Required(ErrorMessage = "{0} can't be empty"), Display(Name = "Rolee"), StringLength(15, MinimumLength = 4, ErrorMessage = "{0} must be between {2} - {1}")]
    public string RName { get ; set ; }
}
