using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmileyMeow.Data;
using SmileyMeow.DTOs;
using SmileyMeow.ViewModels;
using VetClinicLibrary.Person;
using VetClinicLibrary.Person.Locationn;
using VetClinicLibrary.User;

namespace SmileyMeow.Controllers;

public class PetParentController : BasyController
{
    private readonly ILogger<PetParentController> _logger;
    private readonly SmileyMeowDbContext _context;

    public PetParentController(ILogger<PetParentController> logger, SmileyMeowDbContext context)
    {
        _logger = logger;
        _context = context;
    }
    [Authorize(Roles = "PetParent")]
    public async Task<IActionResult> Profile()
    {
        int loggedUser = ReturnLoggedUserId();

        PetParentProfileViewModel selectedParentsProfile = new();

        await AddSelectedParentToViewModel(selectedParentsProfile);

        await AddSelectedParentsPetsToViewModel(selectedParentsProfile);
        await AddGenderAndPronounsToViewModel(selectedParentsProfile);
        selectedParentsProfile.CityList = (selectedParentsProfile.PetParent.Address is null ? null : await _context.Cities.ToListAsync());
        selectedParentsProfile.DistrictList = (selectedParentsProfile.PetParent.Address is null ? null : await _context.Districts
        .Where(a => a.CityId == selectedParentsProfile.PetParent.Address.District.CityId)
        .ToListAsync());
        selectedParentsProfile.selectedFormProfileDTO = new();
        
        return View(selectedParentsProfile);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Profile([Bind("FirstName", "MiddleName", "LastName", "DOB", "HumanGenderId", "PhoneNumber", "PronounId")] PetParent petParent,
    [Bind("AddressId", "AddressDetails", "DistrictId")] Address address, [Bind("CityId", "Emaill")] SelectedFormProfileDTO selectedFormProfileDTO,
    int pid)
    {
        int loggedUser = ReturnLoggedUserId();
        if (ModelState.IsValid)
        {
            petParent.Address = address;
            _context.Addresses.Update(address);
            petParent.UserId = loggedUser;
            petParent.PetParentId = pid;
            _context.PetParents.Update(petParent);
            Userr loggedParent = await ReturnLoggedParentUserAccount(loggedUser);
            loggedParent.Emaill = selectedFormProfileDTO.Emaill;
            _context.Userrs.Update(loggedParent);
            await _context.SaveChangesAsync();
            return RedirectToAction("Profile", "PetParent");
        }

        PetParentProfileViewModel selectedParentsProfile = new();

        selectedParentsProfile.PetParent = petParent;
        await AddGenderAndPronounsToViewModel(selectedParentsProfile);
        selectedParentsProfile.selectedFormProfileDTO = selectedFormProfileDTO;
        selectedParentsProfile.PetParent.Address = address;
        await AddSelectedParentsPetsToViewModel(selectedParentsProfile);
        return View(selectedParentsProfile);
    }
    // public async Task<IActionResult> Pets() {

    // }
  

    // End of the views//
    //--------------------------------------------------------------------------------//
    // Private methods for views//
  
    private async Task<Userr> ReturnLoggedParentUserAccount(int loggedUser)
    {
        return await _context.Userrs.FirstOrDefaultAsync(a => a.UserrId == loggedUser);
    }

    private async Task AddGenderAndPronounsToViewModel(PetParentProfileViewModel selectedParentsProfile)
    {
        selectedParentsProfile.HumanGenders = await _context.HumanGenders.ToListAsync();
        selectedParentsProfile.Pronouns = await _context.Pronouns.ToListAsync();
    }
  
    private async Task AddSelectedParentToViewModel(PetParentProfileViewModel selectedParentsProfile)
    {
        selectedParentsProfile.PetParent = await _context.PetParents
        .Include(a => a.Address)
        .Include(a => a.Address.District)
        .Include(a => a.Balance)
        .Include(a => a.HumanGender)
        .Include(a => a.Pronoun)
        .Include(a => a.Userr)
        .FirstOrDefaultAsync();
    }

    private async Task AddSelectedParentsPetsToViewModel(PetParentProfileViewModel selectedParentsProfile)
    {
        List<int> selectedParentsPets = await _context.PetsnPersons
        .Where(a => a.PetParentId == selectedParentsProfile.PetParent.PetParentId)
        .Select(a => a.AnimalId).ToListAsync();

        selectedParentsProfile.PetsOfSelectedParent = new();
        foreach (int animalId in selectedParentsPets)
        {
            selectedParentsProfile.PetsOfSelectedParent
            .Add(await _context.Pets
            .FirstOrDefaultAsync(a => a.AnimalId == animalId));
        }
    }
}
