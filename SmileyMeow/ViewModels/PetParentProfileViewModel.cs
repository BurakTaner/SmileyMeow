using SmileyMeow.DTOs;
using VetClinicLibrary.Person;
using VetClinicLibrary.Person.HumanGenderr;
using VetClinicLibrary.Person.Locationn;
using VetClinicLibrary.Person.Prounounn;
using VetClinicLibrary.Pett;

namespace SmileyMeow.ViewModels;

public class PetParentProfileViewModel
{
    public PetParent PetParent { get; set; }
    public List<Pet> PetsOfSelectedParent { get; set; }
    public List<HumanGender> HumanGenders { get; set; }
    public List<Pronoun> Pronouns { get; set; }
    public List<City> CityList { get; set; }
    public List<District> DistrictList { get; set; }
    public SelectedFormProfileDTO selectedFormProfileDTO { get; set; }
}
