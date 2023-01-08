using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmileyMeow.Data;
using VetClinicLibrary.Pett.PetGenderr;
using VetClinicLibrary.Pett.Speciee;
using VetClinicLibrary.User;

namespace SmileyMeow.Controllers.Admin;

public class ARoleeController : Controller
{
    private readonly ILogger<ARoleeController> _logger;
    private readonly SmileyMeowDbContext _context;

    public ARoleeController(ILogger<ARoleeController> logger, SmileyMeowDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        List<Rolee> rolees = await _context.Rolees.OrderByDescending(a => a.RoleeId).ToListAsync();
        return View(rolees);
    }


    public async Task<IActionResult> CRUD(int id)
    {
        Rolee rolee = await FindRolee(id);
        
        return View(rolee);
    }

    public IActionResult Create()
    {
        Rolee rolee  = new();

        return View("CRUD",rolee);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("RName")] Rolee rolee)
    {
        if (ModelState.IsValid)
        {
            _context.Add(rolee);
            await Save();
            return RedirectToAction("", "ARolee");
        }

        return View("CRUD",rolee);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> PostDelete(int id)
    {
        Rolee rolee  = await FindRolee(id);
        _context.Remove(rolee);
        await Save();
        
        return RedirectToAction("", "ARolee");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(int id, [Bind("RName")] Rolee rolee )
    {

        if (ModelState.IsValid)
        {
            rolee.RoleeId = id;
            _context.Update(rolee);
            await Save();
            return RedirectToAction("", "ARolee");
        }
        return View("CRUD", rolee);
    }

    //-----------------------------------------------------------------------------------------//
    private async Task<Rolee> FindRolee(int id)
    {
        return await _context.Rolees.FirstOrDefaultAsync(a => a.RoleeId == id);
    }

    private async Task Save()
    {
        await _context.SaveChangesAsync();
    }
}
