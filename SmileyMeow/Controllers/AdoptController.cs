using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmileyMeow.Data;
using SmileyMeow.DTOs;
using SmileyMeow.Helpers;
using SmileyMeow.ViewModels;
using VetClinicLibrary.AdoptionPet;
using VetClinicLibrary.Pett;

namespace SmileyMeow.Controllers;
public class AdoptController : BasyController
{
    private readonly ILogger<AdoptController> _logger;
    private readonly SmileyMeowDbContext _context;

    public AdoptController(ILogger<AdoptController> logger, SmileyMeowDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> List()
    {
        List<Pet> adoptablePets = await _context.Pets.Where(pet => pet.IsAdoptable == true).ToListAsync();

        return View(adoptablePets);
    }
    
    public async Task<IActionResult> Info(int Id) {
        PetAdoptInfoViewModel petAdoptInfoViewModel = new();

        petAdoptInfoViewModel.AdoptablePet = await _context.Pets.Include(p => p.Breed)
        .Include(p => p.PetGender)
        .Include(p => p.Specie)
        .FirstOrDefaultAsync(pet => pet.AnimalId == Id);

        petAdoptInfoViewModel.AdoptablePetInfo = await _context.AdoptInfos
        .FirstOrDefaultAsync(adoptInfo => adoptInfo.AdoptInfoId == petAdoptInfoViewModel.AdoptablePet.AdoptInfoId);

        petAdoptInfoViewModel.PetAge = AgeCalculator.CalculateAge(petAdoptInfoViewModel.AdoptablePet.DOB);
        
        return View(petAdoptInfoViewModel);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AdoptPet(int id, [Bind("AdoptionText")] AdoptionTextDTO  adoptionTextDTO) {
        if (ModelState.IsValid)
        {

        Pet pet = _context.Pets.FirstOrDefault(a => a.AnimalId == id);
        
        if (pet is null)
        {
            return NotFound();
        }
        AdoptionJoinTable adoptionJoinTableTest = _context.AdoptionJoinTables.FirstOrDefault(a => a.PetParent.UserId == ReturnLoggedUserId() && a.AnimalId == id);
        if (adoptionJoinTableTest is null)
        {
            
        AdoptionJoinTable adoptionJoinTable = new();
        adoptionJoinTable.AnimalId = id;
        adoptionJoinTable.PetParentId = _context.PetParents.Where(a => a.UserId == ReturnLoggedUserId()).Select(a => a.PetParentId).FirstOrDefault();
        adoptionJoinTable.PetParentRequestText = adoptionTextDTO.AdoptionText;
        _context.AdoptionJoinTables.Add(adoptionJoinTable);
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            if (e is DbUpdateException)
            {
                return View("CreateAProfileInformation");
            }
            else {
                return View("UnderMaintenance");
            }
        }
        return View("AdoptApplyResult");
        }
        
        if (adoptionJoinTableTest is not null)
        {
        ModelState.AddModelError("","You already apply to this pet for adoption");
        PetAdoptInfoViewModel alreadyAppliedViewModel = new();

        alreadyAppliedViewModel.AdoptablePet = await _context.Pets.Include(p => p.Breed)
        .Include(p => p.PetGender)
        .Include(p => p.Specie)
        .FirstOrDefaultAsync(pet => pet.AnimalId == id);

        alreadyAppliedViewModel.AdoptablePetInfo = await _context.AdoptInfos
        .FirstOrDefaultAsync(adoptInfo => adoptInfo.AdoptInfoId == alreadyAppliedViewModel.AdoptablePet.AdoptInfoId);

        alreadyAppliedViewModel.PetAge = AgeCalculator.CalculateAge(alreadyAppliedViewModel.AdoptablePet.DOB);

        return View("Info",alreadyAppliedViewModel);
        }

        PetAdoptInfoViewModel petAdoptInfoViewModel = new();
        }
        PetAdoptInfoViewModel petAdoptInfoViewModelAgain = new();
        petAdoptInfoViewModelAgain.AdoptablePet = await _context.Pets.Include(p => p.Breed)
        .Include(p => p.PetGender)
        .Include(p => p.Specie)
        .FirstOrDefaultAsync(pet => pet.AnimalId == id);

        petAdoptInfoViewModelAgain.AdoptablePetInfo = await _context.AdoptInfos
        .FirstOrDefaultAsync(adoptInfo => adoptInfo.AdoptInfoId == petAdoptInfoViewModelAgain.AdoptablePet.AdoptInfoId);
        petAdoptInfoViewModelAgain.AdoptionText = adoptionTextDTO.AdoptionText;
        petAdoptInfoViewModelAgain.PetAge = AgeCalculator.CalculateAge(petAdoptInfoViewModelAgain.AdoptablePet.DOB);
        return View("Info",petAdoptInfoViewModelAgain);
        
    }

    public IActionResult AdoptApplyResult() {
        return View();
    }

//     [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
//     public IActionResult Error()
//     {
//         return View("Error!");
//     }
// }
}
