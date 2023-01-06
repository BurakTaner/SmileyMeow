using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmileyMeow.DTOs;
using VetClinicLibrary.Person.Locationn;

namespace SmileyMeow.ViewModels;

public class DistrictViewModel
{
    public District District { get; set; }
    public List<City> CityList { get; set; }
}
