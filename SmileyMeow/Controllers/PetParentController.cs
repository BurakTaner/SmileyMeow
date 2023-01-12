using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmileyMeow.Data;
using SmileyMeow.DTOs;
using SmileyMeow.ViewModels;
using VetClinicLibrary.Appointmentt;
using VetClinicLibrary.Person;
using VetClinicLibrary.Person.Locationn;
using VetClinicLibrary.Pett;
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
        
        selectedParentsProfile.PetParent = await AddSelectedParentToViewModel(selectedParentsProfile);

        await AddSelectedParentsPetsToViewModel(selectedParentsProfile);
        await AddGenderAndPronounsToViewModel(selectedParentsProfile);
        selectedParentsProfile.CityList = (selectedParentsProfile.PetParent.Address is null || selectedParentsProfile.PetParent.Address.DistrictId is null ? null : await _context.Cities.ToListAsync());
        selectedParentsProfile.DistrictList = (selectedParentsProfile.PetParent.Address is null || selectedParentsProfile.PetParent.Address.DistrictId is null ? null : await _context.Districts
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
            await Save();
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


    public async Task<IActionResult> AppointmentList()
    {
        List<Appointment> allAppointmentsForLoggedUser = await ReturnAllAppointmentsForUser();
        return View(allAppointmentsForLoggedUser);
    }

    public IActionResult ListParentsPets() {
        int parentId =   _context.PetParents.Where(a => a.UserId == ReturnLoggedUserId()).Select(a => a.PetParentId).FirstOrDefault();
        List<int> parentsPetsId =  _context.PetsnPersons.Where(a => a.PetParentId == parentId).Select(a => a.AnimalId).ToList();
        List<Pet> parentsPets = new();
        foreach (int animalId in parentsPetsId)
        {
            parentsPets.Add(_context.Pets.Include(a => a.PetGender).Include(a => a.Breed).Include(a => a.Specie).FirstOrDefault(a => a.AnimalId == animalId));
        }
        return View(parentsPets);
    }
    public async Task<IActionResult> CancelAppointment(int id) {
        Appointment appointment = await _context.Appointments.FirstOrDefaultAsync(a => a.AppointmentId == id);
        _context.Remove(appointment);
        await Save();
        List<Appointment> allAppointmentsForLoggedUser = await ReturnAllAppointmentsForUser();
        return View("AppointmentList",allAppointmentsForLoggedUser);
                
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeletePet(int id) {
        Pet pet = _context.Pets.FirstOrDefault(a => a.AnimalId == id);
        _context.Remove(pet);
        await _context.SaveChangesAsync();
        return RedirectToAction("ListParentsPets","PetParent");
    }

    // End of the views//
    //--------------------------------------------------------------------------------//
    // Private methods for views//


    private async Task<List<Appointment>> ReturnAllAppointmentsForUser()
    {
        int loggedUserPetParentId = await _context.PetParents.Where(a => a.UserId == ReturnLoggedUserId()).Select(a => a.UserId).FirstOrDefaultAsync();
        List<Appointment> allAppointmentsForLoggedUser = await _context.Appointments.Where(a => a.PetnPersonId == loggedUserPetParentId).Include(a => a.PetnPerson.Pet).Include(a => a.Doctor).ThenInclude(a => a.DoctorTitle).Include(a => a.AppointmentStatus).ToListAsync();
        return allAppointmentsForLoggedUser;
    }


    private async Task<Userr> ReturnLoggedParentUserAccount(int loggedUser)
    {
        return await _context.Userrs.FirstOrDefaultAsync(a => a.UserrId == loggedUser);
    }

    private async Task AddGenderAndPronounsToViewModel(PetParentProfileViewModel selectedParentsProfile)
    {
        selectedParentsProfile.HumanGenders = await _context.HumanGenders.ToListAsync();
        selectedParentsProfile.Pronouns = await _context.Pronouns.ToListAsync();
    }
  
    private async Task<PetParent> AddSelectedParentToViewModel(PetParentProfileViewModel selectedParentsProfile)
    {
        PetParent petParent = await _context.PetParents
        .Include(a => a.Address)
        .Include(a => a.Address.District)
        .Include(a => a.Balance)
        .Include(a => a.HumanGender)
        .Include(a => a.Pronoun)
        .Include(a => a.Userr)
        .FirstOrDefaultAsync(a => a.UserId == ReturnLoggedUserId());
        if (petParent is null)
        {
            PetParent parent = new();
            parent.Userr = await _context.Userrs.FirstOrDefaultAsync(a => a.UserrId == ReturnLoggedUserId());
            return parent;
        }
        return petParent;
    }

    private async Task AddSelectedParentsPetsToViewModel(PetParentProfileViewModel selectedParentsProfile)
    {
        if(selectedParentsProfile.PetParent.PetParentId != 0) {
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
        selectedParentsProfile.PetsOfSelectedParent = null;
    }


    private async Task Save()
    {
        await _context.SaveChangesAsync();
    }
}
