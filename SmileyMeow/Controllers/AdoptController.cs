using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmileyMeow.Data;
using VetClinicLibrary.Pett;
using VetClinicLibrary.Pett.Adopt;
using VetVetClinicLibrary.Pett;

namespace SmileyMeow.Controllers;

[Route("[controller]")]
public class AdoptController : Controller
{
    private readonly ILogger<AdoptController> _logger;
    private readonly SmileyMeowDbContext _context;

    public AdoptController(ILogger<AdoptController> logger, SmileyMeowDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        List<Pet> adoptablePets = await _context.Pets.Where(pet => pet.IsAdoptable == true).ToListAsync();
        
        return View(adoptablePets);
    }

    // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    // public IActionResult Error()
    // {
    //     return View("Error!");
    // }
}
