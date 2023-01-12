using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmileyMeow.DTOs
{
    public class AdoptionTextDTO
    {
        [Required(ErrorMessage = "{0} can't be empty"),Display(Name = "AdoptionText"), StringLength(350 ,MinimumLength = 30 , ErrorMessage = "{0} must be between {2} - {1}")]
        public string AdoptionText { get; set; }
    }
}