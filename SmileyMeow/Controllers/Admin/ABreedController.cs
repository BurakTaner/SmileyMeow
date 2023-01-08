using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmileyMeow.Data;
using VetClinicLibrary.Person.HumanGenderr;
using VetClinicLibrary.Pett.Breedd;

namespace SmileyMeow.Controllers.Admin;

public class ABreedController : ABaseController
{
    private readonly ILogger<ABreedController> _logger;
    private readonly SmileyMeowDbContext _context;

    public ABreedController(ILogger<ABreedController> logger, SmileyMeowDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        List<Breed> breeds = await _context.Breeds.OrderByDescending(a => a.BreedId).ToListAsync();
        return View(breeds);
    }


    public async Task<IActionResult> CRUD(int id)
    {
        Breed breed = await FindBreed(id);
        
        return View(breed);
    }

    public IActionResult Create()
    {
        Breed breed = new();

        return View("CRUD",breed);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("BName")] Breed breed)
    {
        if (ModelState.IsValid)
        {
            _context.Add(breed);
            await Save();
            return RedirectToAction("", "ABreed");
        }

        return View("CRUD",breed);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> PostDelete(int id)
    {
        Breed breed = await FindBreed(id);
        _context.Remove(breed);
        await Save();
        
        return RedirectToAction("", "ABreed");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(int id, [Bind("BName")] Breed breed)
    {

        if (ModelState.IsValid)
        {
            breed.BreedId = id;
            _context.Update(breed);
            await Save();
            return RedirectToAction("", "ABreed");
        }
        return View("CRUD", breed);
    }

    //-----------------------------------------------------------------------------------------//
    private async Task<Breed> FindBreed(int id)
    {
        return await _context.Breeds.FirstOrDefaultAsync(a => a.BreedId == id);
    }

    private async Task Save()
    {
        await _context.SaveChangesAsync();
    }
}
