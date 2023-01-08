using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmileyMeow.Data;
using SmileyMeow.ViewModels;
using VetClinicLibrary.Person.Locationn;
using VetClinicLibrary.SchoolTypee;

namespace SmileyMeow.Controllers.Admin;

public class ASchoolTypeController : ABaseController
{
    private readonly ILogger<ASchoolTypeController> _logger;
    private readonly SmileyMeowDbContext _context;
    public ASchoolTypeController(ILogger<ASchoolTypeController> logger, SmileyMeowDbContext context)
    {
        _logger = logger;
        _context = context;
    }


    public async Task<IActionResult> Index()
    {
        List<SchoolType> schoolTypeList = await _context.SchoolTypes.OrderByDescending(a => a.SchoolTypeId).ToListAsync();
        return View(schoolTypeList);
    }
    public async Task<IActionResult> Create()
    {
        SchoolType schoolType = new();
        return View(schoolType);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("STName")] SchoolType schoolType)
    {
        if (ModelState.IsValid)
        {
            _context.Add(schoolType);
            await Save();
            return RedirectToAction("", "ASchoolType"); 
        }

        SchoolType returnSchoolType = schoolType;
        return View(returnSchoolType);
    }

    public async Task<IActionResult> Info(int id)
    {
        SchoolType schoolType = await FindSchoolType(id);
        return View(schoolType);
    }

    public async Task<IActionResult> Delete(int id) {
        SchoolType schoolType = await FindSchoolType(id);
        return View(schoolType);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> PostDelete(int id)
    {
        SchoolType deleteSchoolType = await FindSchoolType(id);
        _context.Remove(deleteSchoolType);
        await Save();
        return RedirectToAction("", "ASchoolType");
    }

    public async Task<IActionResult> Update(int id) {
        SchoolType schoolType = await FindSchoolType(id);
        return View(schoolType);
        
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(int id,[Bind("STName")] SchoolType schoolType) {
        
        if(ModelState.IsValid) {
            schoolType.SchoolTypeId= id;
            _context.Update(schoolType);
            await Save();
            return RedirectToAction("","ASchoolType");
        }

        return View(schoolType);
    }

    //----------------------------------------------------------------------//
    private async Task Save()
    {
        await _context.SaveChangesAsync();
    }

    private async Task<SchoolType> FindSchoolType(int id)
    {
        return await _context.SchoolTypes.FirstOrDefaultAsync(a => a.SchoolTypeId == id);
    }
}
