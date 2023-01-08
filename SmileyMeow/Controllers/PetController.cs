using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmileyMeow.Data;
using SmileyMeow.ViewModels;
using VetClinicLibrary.Person;
using VetClinicLibrary.PetnPersonn;
using VetClinicLibrary.Pett;

namespace SmileyMeow.Controllers;
public class PetController : BasyController
{
    private readonly ILogger<PetController> _logger;
    private readonly SmileyMeowDbContext _context;

    public PetController(ILogger<PetController> logger, SmileyMeowDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> Add()
    {
        PetAddViewModel petAddViewModel = await CreateEmtpyPetAddViewModel();
        return View(petAddViewModel);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Add([Bind("Name","DOB","PetGenderId","SpecieId","BreedId")] Pet pet)
    {
        if (ModelState.IsValid)
        {
            PetnPerson petnPerson = ReturnJoinTableWithResult(pet);
            _context.PetsnPersons.Add(petnPerson);
            await _context.SaveChangesAsync();
            return RedirectToAction("Profile","PetParent");
        }
        PetAddViewModel petAddViewModel = await ReturnPetAddViewModelAgain(pet);
        return View(petAddViewModel);
    }

    //-----------------------------------------------------------------------------------//
    private async Task<PetAddViewModel> ReturnPetAddViewModelAgain(Pet pet)
    {
        PetAddViewModel petAddViewModel = new();
        petAddViewModel.Pet = pet;
        await AddPetPropsList(petAddViewModel);
        return petAddViewModel;
    }

    private PetnPerson ReturnJoinTableWithResult(Pet pet)
    {
        PetnPerson petnPerson = new();
        int petParentId = _context.PetParents.Where(a => a.UserId == ReturnLoggedUserId()).Select(a => a.PetParentId).FirstOrDefault();
        Pet createPet = pet;
        pet.IsAdoptable = false;
        _context.Pets.Add(pet);
        petnPerson.Pet = pet;
        petnPerson.PetParentId = petParentId;
        return petnPerson;
    }


    private async Task<PetAddViewModel> CreateEmtpyPetAddViewModel()
    {
        PetAddViewModel petAddViewModel = new();
        petAddViewModel.Pet = new();
        await AddPetPropsList(petAddViewModel);
        return petAddViewModel;
    }

    private async Task AddPetPropsList(PetAddViewModel petAddViewModel)
    {
        petAddViewModel.BreedList = await _context.Breeds.ToListAsync();
        petAddViewModel.SpecieList = await _context.Species.ToListAsync();
        petAddViewModel.PetGenderList = await _context.PetGenders.ToListAsync();
    }
}
