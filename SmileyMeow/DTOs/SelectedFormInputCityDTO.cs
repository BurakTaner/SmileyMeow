using System.ComponentModel.DataAnnotations;
using VetClinicLibrary.Person.Locationn;

namespace SmileyMeow.DTOs;

public class SelectedFormInputCityDTO
{
    [Display(Name ="City"),Range(1,81, ErrorMessage = ("Choseen an invalid {0}, please select a valid one"))]
    public int? CityId { get; set; }
    public City City { get; set; }
}
