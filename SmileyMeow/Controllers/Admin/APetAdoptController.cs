using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmileyMeow.Data;
using SmileyMeow.ViewModels;
using VetClinicLibrary.Person.HumanGenderr;
using VetClinicLibrary.Pett;
using VetClinicLibrary.Pett.Adopt;
using VetClinicLibrary.Pett.Breedd;

namespace SmileyMeow.Controllers.Admin;

public class APetAdoptController : ABaseController
{
    private readonly ILogger<APetAdoptController> _logger;
    private readonly SmileyMeowDbContext _context;

    public APetAdoptController(ILogger<APetAdoptController> logger, SmileyMeowDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        List<Pet> pets = await _context.Pets
        .Include(a => a.Breed)
        .Include(a => a.Specie)
        .Include(a => a.PetGender)
        .Include(a => a.AdoptionInfo)
        .Where(a => a.IsAdoptable == true)
        .OrderByDescending(a => a.BreedId).ToListAsync();

        return View(pets);
    }


    public async Task<IActionResult> CRUD(int id)
    {
        PetAdoptViewModel petAdoptViewModel = await ReturnPetAdoptViewModel(id);
        return View(petAdoptViewModel);
    }


    public async Task<IActionResult> Create()
    {
        PetAdoptViewModel petAdoptViewModel = new();
        petAdoptViewModel.Pet = new();
        await AddPetPropList(petAdoptViewModel);
        petAdoptViewModel.AdoptInfo = new();
        return View("CRUD", petAdoptViewModel);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Name", "DOB", "PetGenderId", "SpecieId", "BreedId")] Pet pet,
    [Bind("AdoptText")] AdoptInfo adoptInfo)
    {
        if (ModelState.IsValid)
        {
            pet.AdoptionInfo = adoptInfo;
            _context.AdoptInfos.Add(adoptInfo);
            _context.Pets.Add(pet);
            await Save();
            return RedirectToAction("", "APetAdopt");
        }
        PetAdoptViewModel petAdoptViewModel = await ReturnViewModelAgain(pet, adoptInfo);
        return View("CRUD", petAdoptViewModel);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> PostDelete(int id)
    {
        Pet pet = _context.Pets.FirstOrDefault(a => a.AnimalId == id);
        _context.Remove(pet);
        await Save();
        return RedirectToAction("", "APetAdopt");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(int id, [Bind("Name", "DOB", "PetGenderId", "SpecieId", "BreedId")] Pet pet,
    [Bind("AdoptText")] AdoptInfo adoptInfo)
    {

        if (ModelState.IsValid)
        {
            pet.AnimalId = id;
            pet.AdoptionInfo = adoptInfo;
            pet.IsAdoptable = true;
            _context.Pets.Update(pet);
            await Save();
            return RedirectToAction("", "APetAdopt");
        }


        PetAdoptViewModel petAdoptViewModel = await ReturnViewModelAgain(pet, adoptInfo);
        return View("CRUD", petAdoptViewModel);
    }

    //-----------------------------------------------------------------------------------------//



    private async Task<PetAdoptViewModel> ReturnViewModelAgain(Pet pet, AdoptInfo adoptInfo)
    {
        PetAdoptViewModel petAdoptViewModel = new();
        petAdoptViewModel.Pet = pet;
        await AddPetPropList(petAdoptViewModel);
        petAdoptViewModel.AdoptInfo = adoptInfo;
        return petAdoptViewModel;
    }
    private async Task<PetAdoptViewModel> ReturnPetAdoptViewModel(int id)
    {
        PetAdoptViewModel petAdoptViewModel = new();
        petAdoptViewModel.Pet = await FindAdoptablePet(id);
        await AddPetPropList(petAdoptViewModel);
        petAdoptViewModel.AdoptInfo = await _context.AdoptInfos.
        FirstOrDefaultAsync(a => a.Pet.AnimalId == petAdoptViewModel.Pet.AnimalId);
        return petAdoptViewModel;
    }

    private async Task AddPetPropList(PetAdoptViewModel petAdoptViewModel)
    {
        petAdoptViewModel.BreedList = await _context.Breeds.ToListAsync();
        petAdoptViewModel.SpecieList = await _context.Species.ToListAsync();
        petAdoptViewModel.PetGenderList = await _context.PetGenders.ToListAsync();
    }

    private async Task<Pet> FindAdoptablePet(int id)
    {
        return await _context.Pets
        .Include(a => a.AdoptionInfo).Include(a => a.PetGender)
        .Include(a => a.Breed)
        .Include(a => a.Specie)
        .FirstOrDefaultAsync(a => a.AnimalId == id);
    }

    private async Task Save()
    {
        await _context.SaveChangesAsync();
    }
}
