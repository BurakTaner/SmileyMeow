using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmileyMeow.Data;
using SmileyMeow.Helpers;
using SmileyMeow.ViewModels;
using VetClinicLibrary.Pett;

namespace SmileyMeow.Controllers;
public class AdoptController : Controller
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

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View("Error!");
    }
}
