using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmileyMeow.Data;
using SmileyMeow.ViewModels;
using VetClinicLibrary.Person;
using VetClinicLibrary.Schooll;

namespace SmileyMeow.Controllers;
public class DoctorsController : Controller
{
    private readonly ILogger<DoctorsController> _logger;
    private readonly SmileyMeowDbContext _context;

    public DoctorsController(ILogger<DoctorsController> logger, SmileyMeowDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> List()
    {
        List<Doctor> doctorsList = await _context.Doctors
        .Include(d => d.HumanGender)
        .Include(d => d.School)
        .ThenInclude(s => s.SchoolType)
        .Include(d => d.DoctorTitle)
        .ToListAsync();
        
        return View(doctorsList);
    }

    public async Task<IActionResult> Info(int id) {
        DoctorInfoViewModel selectedDoctor = new();

        selectedDoctor.SelectedDoctor = await _context.Doctors
        .Include(g => g.HumanGender)
        .Include(t => t.DoctorTitle)
        .Include(p => p.Pronoun)
        .FirstOrDefaultAsync(d => d.DoctorId == id);
        
        selectedDoctor.SelectedDoctorInfo = await _context.DoctorInformations.FirstOrDefaultAsync(a => a.DoctorId == id);        
        
        return View(selectedDoctor);
    }
}
