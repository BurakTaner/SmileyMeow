using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmileyMeow.Data;
using SmileyMeow.ViewModels;
using VetClinicLibrary.Pett.PetGenderr;
using VetClinicLibrary.Pett.Speciee;
using VetClinicLibrary.User;

namespace SmileyMeow.Controllers.Admin;

public class ARoleeController : ABaseController
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
    public async Task<IActionResult> RoleesOfUsers() {
        List<Userr> userrs = await _context.Userrs
        .Include(a => a.Rolee)
        .ToListAsync();
        
        return View(userrs);
    }

    public async Task<IActionResult> ChangeRolee(int id) {
        UserRoleeChangeViewModel userRoleeChangeViewModel = new();
        userRoleeChangeViewModel.Userr = await _context.Userrs.FirstOrDefaultAsync(a => a.UserrId == id);
        if (userRoleeChangeViewModel.Userr is null)
        {
            return NotFound();
        }
        userRoleeChangeViewModel.RoleeList = await _context.Rolees.ToListAsync();
        return View(userRoleeChangeViewModel);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ChangeRolee(int id, int roleeId ) {
        if(ModelState.IsValid) {
            Userr userr = await _context.Userrs.FirstOrDefaultAsync(a => a.UserrId == id);
            userr.RoleeId = roleeId;
            _context.Update(userr);
            await Save();
            return RedirectToAction("RoleesOfUsers","ARolee");
        }
        return View();
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
