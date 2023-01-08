using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmileyMeow.Data;
using VetClinicLibrary.Person.HumanGenderr;
using VetClinicLibrary.Person.Titles;
using VetClinicLibrary.Pett.Breedd;

namespace SmileyMeow.Controllers.Admin;

public class ADoctorTitleController : Controller
{
    private readonly ILogger<ADoctorTitleController> _logger;
    private readonly SmileyMeowDbContext _context;

    public ADoctorTitleController(ILogger<ADoctorTitleController> logger, SmileyMeowDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        List<DoctorTitle> doctorTitles = await _context.DoctorTitles.OrderByDescending(a => a.DoctorTitleId).ToListAsync();
        return View(doctorTitles);
    }


    public async Task<IActionResult> CRUD(int id)
    {
        DoctorTitle doctorTitle = await FindDoctortitle(id);
        
        return View(doctorTitle);
    }

    public IActionResult Create()
    {
        DoctorTitle doctorTitle = new();

        return View("CRUD",doctorTitle);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("TFullForm","TShortForm")] DoctorTitle doctorTitle)
    {
        doctorTitle.TShortForm = doctorTitle.TShortForm.ToUpper();
        if (ModelState.IsValid)
        {
            _context.Add(doctorTitle);
            await Save();
            return RedirectToAction("", "ADoctorTitle");
        }

        return View("CRUD",doctorTitle);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> PostDelete(int id)
    {
        DoctorTitle doctorTitle= await FindDoctortitle(id);
        _context.Remove(doctorTitle);
        await Save();
        
        return RedirectToAction("", "ADoctorTitle");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(int id, [Bind("TFullForm","TShortForm")] DoctorTitle doctorTitle)
    {

        if (ModelState.IsValid)
        {
            doctorTitle.DoctorTitleId = id;
            _context.Update(doctorTitle);
            await Save();
            return RedirectToAction("", "ADoctorTitle");
        }
        return View("CRUD", doctorTitle);
    }

    //-----------------------------------------------------------------------------------------//
    private async Task<DoctorTitle> FindDoctortitle(int id)
    {
        return await _context.DoctorTitles.FirstOrDefaultAsync(a => a.DoctorTitleId == id);
    }

    private async Task Save()
    {
        await _context.SaveChangesAsync();
    }
}
