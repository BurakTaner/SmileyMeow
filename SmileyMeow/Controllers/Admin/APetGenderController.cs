using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmileyMeow.Data;
using VetClinicLibrary.Person.HumanGenderr;
using VetClinicLibrary.Pett.Breedd;
using VetClinicLibrary.Pett.PetGenderr;

namespace SmileyMeow.Controllers.Admin;

public class APetGenderController : Controller
{
    private readonly ILogger<APetGenderController> _logger;
    private readonly SmileyMeowDbContext _context;

    public APetGenderController(ILogger<APetGenderController> logger, SmileyMeowDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        List<PetGender> petGenders = await _context.PetGenders.OrderByDescending(a => a.PetGenderId).ToListAsync();
        return View(petGenders);
    }


    public async Task<IActionResult> CRUD(int id)
    {
        PetGender petGender = await FindPetGender(id);
        
        return View(petGender);
    }

    public IActionResult Create()
    {
        PetGender petGender = new();

        return View("CRUD",petGender);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("GName")] PetGender petGender)
    {
        if (ModelState.IsValid)
        {
            _context.Add(petGender);
            await Save();
            return RedirectToAction("", "APetGender");
        }

        return View("CRUD",petGender);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> PostDelete(int id)
    {
        PetGender petGender = await FindPetGender(id);
        _context.Remove(petGender);
        await Save();
        
        return RedirectToAction("", "APetGender");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(int id, [Bind("GName")] PetGender petGender)
    {

        if (ModelState.IsValid)
        {
            petGender.PetGenderId = id;
            _context.Update(petGender);
            await Save();
            return RedirectToAction("", "APetGender");
        }
        return View("CRUD", petGender);
    }

    //-----------------------------------------------------------------------------------------//
    private async Task<PetGender> FindPetGender(int id)
    {
        return await _context.PetGenders.FirstOrDefaultAsync(a => a.PetGenderId == id);
    }

    private async Task Save()
    {
        await _context.SaveChangesAsync();
    }
}
