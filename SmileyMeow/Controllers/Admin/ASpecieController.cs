using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmileyMeow.Data;
using VetClinicLibrary.Pett.PetGenderr;
using VetClinicLibrary.Pett.Speciee;

namespace SmileyMeow.Controllers.Admin;

public class ASpecieController : Controller
{
    private readonly ILogger<ASpecieController> _logger;
    private readonly SmileyMeowDbContext _context;

    public ASpecieController(ILogger<ASpecieController> logger, SmileyMeowDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        List<Specie> species = await _context.Species.OrderByDescending(a => a.SpecieId).ToListAsync();
        return View(species);
    }


    public async Task<IActionResult> CRUD(int id)
    {
        Specie specie = await FindSpecie(id);
        
        return View(specie);
    }

    public IActionResult Create()
    {
        Specie specie  = new();

        return View("CRUD",specie);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("SName")] Specie specie)
    {
        if (ModelState.IsValid)
        {
            _context.Add(specie);
            await Save();
            return RedirectToAction("", "ASpecie");
        }

        return View("CRUD",specie);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> PostDelete(int id)
    {
        Specie specie  = await FindSpecie(id);
        _context.Remove(specie);
        await Save();
        
        return RedirectToAction("", "ASpecie");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(int id, [Bind("SName")] Specie specie )
    {

        if (ModelState.IsValid)
        {
            specie.SpecieId = id;
            _context.Update(specie);
            await Save();
            return RedirectToAction("", "ASpecie");
        }
        return View("CRUD", specie);
    }

    //-----------------------------------------------------------------------------------------//
    private async Task<Specie> FindSpecie(int id)
    {
        return await _context.Species.FirstOrDefaultAsync(a => a.SpecieId == id);
    }

    private async Task Save()
    {
        await _context.SaveChangesAsync();
    }
}
