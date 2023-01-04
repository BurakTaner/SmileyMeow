using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmileyMeow.Data;
using VetClinicLibrary.User;

namespace SmileyMeow.Controllers;

public class HomeController : BasyController
{
    private readonly ILogger<HomeController> _logger;
    private readonly SmileyMeowDbContext _context;

    public HomeController(ILogger<HomeController> logger, SmileyMeowDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
    public async Task<IActionResult> ProfileSwitcher()
    {
        int loggedUser = ReturnLoggedUserId();
        List<Rolee> allRoles = await _context.Rolees.ToListAsync();
        string loggedUserRole = await _context.Userrs.Where(a => a.UserrId == loggedUser).Select(a => a.Rolee.RName).FirstOrDefaultAsync();
        
        if (loggedUserRole is not null){
            return RedirectToAction("Profile",$"{loggedUserRole}");
        }
        else {
            return RedirectToAction("UnderMaintenance","");
        }
        
    }
}
