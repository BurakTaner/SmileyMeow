using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmileyMeow.Data;
using SmileyMeow.ViewModels;
using VetClinicLibrary.Person.Locationn;
using VetClinicLibrary.Schooll;

namespace SmileyMeow.Controllers.Admin;

public class ASchoolController : Controller
{
    private readonly ILogger<ASchoolController> _logger;
    private readonly SmileyMeowDbContext _context;
    public ASchoolController(ILogger<ASchoolController> logger, SmileyMeowDbContext context)
    {
        _logger = logger;
        _context = context;
    }


    public async Task<IActionResult> Index()
    {
        List<School> allSchools = await ReturnSchools();

        return View(allSchools);
    }


    public async Task<IActionResult> Create()
    {
        SchoolViewModel schoolViewModel = new();
        schoolViewModel.School = new();
        schoolViewModel.SchoolTypeList = await _context.SchoolTypes.ToListAsync();
        return View(schoolViewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("SName", "SchoolTypeId")] School school)
    {
        if (ModelState.IsValid)
        {
            _context.Add(school);
            await Save();
            return RedirectToAction("", "ASchool");
        }

        SchoolViewModel schoolViewModel = await ReturnSchoolViewModelAgain(school);
        return View(schoolViewModel);
    }

    public async Task<IActionResult> Info(int id)
    {
        School school = await _context.Schools.Include(a => a.SchoolType).FirstOrDefaultAsync(a => a.SchoolId == id);
        return View(school);
    }

    public async Task<IActionResult> Delete(int id)
    {
        School school = await FindSchool(id);
        return View(school);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> PostDelete(int id)
    {
        School school = await FindSchool(id);
        _context.Remove(school);
        await Save();
        return RedirectToAction("", "ASchool");
    }

    public async Task<IActionResult> Update(int id)
    {
        SchoolViewModel schoolViewModel = await CreateSchoolViewModel(id);
        return View(schoolViewModel);

    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(int id, [Bind("SName", "SchoolTypeId")] School school)
    {

        if (ModelState.IsValid)
        {
            school.SchoolId = id;
            _context.Update(school);
            await Save();
            return RedirectToAction("", "ASchool");
        }

        SchoolViewModel schoolViewModel = await ReturnSchoolViewModelAgain(school);
        return View(schoolViewModel);
    }

    //----------------------------------------------------------------------//
    private async Task Save()
    {
        await _context.SaveChangesAsync();
    }

    private async Task<School> FindSchool(int id)
    {
        return await _context.Schools.FirstOrDefaultAsync(a => a.SchoolId == id);
    }

    private async Task<SchoolViewModel> ReturnSchoolViewModelAgain(School school)
    {
        SchoolViewModel schoolViewModel = new();
        schoolViewModel.School = school;
        schoolViewModel.SchoolTypeList = await _context.SchoolTypes.ToListAsync();
        return schoolViewModel;
        
    }


    private async Task<SchoolViewModel> CreateSchoolViewModel(int id)
    {
        School school = await FindSchool(id);
        SchoolViewModel schoolViewModel = new();
        schoolViewModel.School = school;
        schoolViewModel.SchoolTypeList = await _context.SchoolTypes.ToListAsync();
        return schoolViewModel;
    }

    private async Task<List<School>> ReturnSchools()
    {
        return await _context.Schools
                .Include(a => a.SchoolType)
                .OrderByDescending(a => a.SchoolId)
                .ToListAsync();
    }
}
