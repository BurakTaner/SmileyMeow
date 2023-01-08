using VetClinicLibrary.Pett.Adopt;
using VetClinicLibrary.Pett.Breedd;
using VetClinicLibrary.Pett.PetGenderr;
using VetClinicLibrary.Pett.Speciee;
using VetVetClinicLibrary.Pett;
using VetClinicLibrary.Person;
using VetClinicLibrary.Appointmentt.PatientInformationn;
using System;
using System.Collections.Generic;
using VetClinicLibrary.PetnPersonn;
using System.ComponentModel.DataAnnotations;

namespace VetClinicLibrary.Pett;

public class Pet : IPet
{
    public int AnimalId { get; set; }
    [Required(ErrorMessage = "{0} can't be empty"), Display(Name = "Name"), StringLength(20, MinimumLength = 5, ErrorMessage = "{0} must be between {2} - {1}")]
    public string Name { get; set; }
    [Required(ErrorMessage = "{0} must be filled."), Display(Name = "Date of birth")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
    [DataType(DataType.Date, ErrorMessage = "Date is not in corect form")]
    public DateTime DOB { get; set; }
    [Display(Name = "Pet Gender"), Range(1, 9, ErrorMessage = ("Choseen an invalid {0}, please select a valid one"))]
    public int PetGenderId { get; set; }
    public PetGender PetGender { get; set; }
    [Display(Name = "Specie"), Range(1, 150, ErrorMessage = ("Choseen an invalid {0}, please select a valid one"))]
    public int SpecieId { get; set; }
    public Specie Specie { get; set; }
    [Display(Name = "Breed"), Range(1, 999999, ErrorMessage = ("Choseen an invalid {0}, please select a valid one"))]
    public int BreedId { get; set; }
    public Breed Breed { get; set; }
    public int? AdoptInfoId { get; set; }
    public bool IsAdoptable { get; set; }
    public AdoptInfo AdoptionInfo { get; set; }
    public List<PetnPerson> PetnPersonn { get; set; }
}
