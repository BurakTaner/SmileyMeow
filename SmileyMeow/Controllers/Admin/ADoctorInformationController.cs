using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmileyMeow.Data;
using SmileyMeow.ViewModels;
using VetClinicLibrary.Person.DoctorInformationn;

namespace SmileyMeow.Controllers.Admin;

public class ADoctorInformationController : Controller
{
    private readonly ILogger<ADoctorInformationController> _logger;
    private readonly SmileyMeowDbContext _context;

    public ADoctorInformationController(ILogger<ADoctorInformationController> logger, SmileyMeowDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        List<DoctorInformation> doctorInformations = await _context.DoctorInformations
        .Include(a => a.Doctor)
        .OrderByDescending(a => a.DoctorId)
        .ToListAsync();
        return View(doctorInformations);
    }


    public async Task<IActionResult> CRUD(int id)
    {
        DoctorInformationViewModel doctorInformationViewModel = new();
        doctorInformationViewModel.DoctorInformation = await _context.DoctorInformations
        .Include(a => a.Doctor)
        .FirstOrDefaultAsync(a => a.DoctorId == id);
        await AddDoctorList(doctorInformationViewModel);
        return View(doctorInformationViewModel);
    }

    public async Task<IActionResult> Create()
    {
        DoctorInformationViewModel doctorInformationViewModel = new();
        doctorInformationViewModel.DoctorInformation = new();
        await AddDoctorList(doctorInformationViewModel);

        return View("CRUD", doctorInformationViewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("DoctorInformationText","DoctorId")] DoctorInformation doctorInformation)
    {
        if (ModelState.IsValid)
        {
            _context.Add(doctorInformation);
            await Save();
            return RedirectToAction("", "ADoctorInformation");
        }

        return View("CRUD", doctorInformation);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> PostDelete(int id)
    {
        DoctorInformation doctorInformation = await FindDoctorInformation(id);
        _context.Remove(doctorInformation);
        await Save();

        return RedirectToAction("", "ADoctorInformation");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(int id, [Bind("DoctorInformationText")] DoctorInformation doctorInformation)
    {

        if (ModelState.IsValid)
        {
            doctorInformation.DoctorId = id;
            _context.Update(doctorInformation);
            await Save();
            return RedirectToAction("", "ADoctorInformation");
        }
        DoctorInformationViewModel doctorInformationViewModel = new();
        doctorInformation.DoctorId = id;
        doctorInformationViewModel.DoctorInformation = doctorInformation;
        await AddDoctorList(doctorInformationViewModel);
        return View("CRUD", doctorInformationViewModel);
    }

    //-----------------------------------------------------------------------------------------//
    private async Task<DoctorInformation> FindDoctorInformation(int id)
    {
        return await _context.DoctorInformations.FirstOrDefaultAsync(a => a.DoctorId == id);
    }

    private async Task AddDoctorList(DoctorInformationViewModel doctorInformationViewModel)
    {
        doctorInformationViewModel.DoctorList = await _context.Doctors.Include(a => a.DoctorTitle).ToListAsync();
    }

    private async Task Save()
    {
        await _context.SaveChangesAsync();
    }
}
