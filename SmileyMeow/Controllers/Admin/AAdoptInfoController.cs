using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmileyMeow.Data;
using SmileyMeow.ViewModels;
using VetClinicLibrary.Pett;
using VetClinicLibrary.Pett.Adopt;
using VetClinicLibrary.Pett.PetGenderr;

namespace SmileyMeow.Controllers.Admin;

public class AAdoptInfoController : ABaseController
{
    private readonly ILogger<AAdoptInfoController> _logger;
    private readonly SmileyMeowDbContext _context;

    public AAdoptInfoController(ILogger<AAdoptInfoController> logger, SmileyMeowDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        List<AdoptInfo> adoptInfos = await _context.AdoptInfos.Include(a => a.Pet).ToListAsync();
        return View(adoptInfos);
    }


    public async Task<IActionResult> CRUD(int id)
    {
        AdoptInfo adoptInfo = await FindPetAdoptInfo(id);
        
        return View(adoptInfo);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> PostDelete(int id)
    {
        AdoptInfo adoptInfo = await FindPetAdoptInfo(id);
        _context.Remove(adoptInfo);
        await Save();
        
        return RedirectToAction("", "AAdoptInfo");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(int id, [Bind("AdoptText")] AdoptInfo adoptInfo)
    {
        if (ModelState.IsValid)
        {
            adoptInfo.AdoptInfoId = id;
            _context.Update(adoptInfo);
            await Save();
            return RedirectToAction("", "AAdoptInfo");
        }
        
        return View("CRUD", adoptInfo);
    }

    //-----------------------------------------------------------------------------------------//
    private async Task<AdoptInfo> FindPetAdoptInfo(int id)
    {
        return await _context.AdoptInfos.Include(a => a.Pet).FirstOrDefaultAsync(a => a.AdoptInfoId == id);
    }

    private async Task Save()
    {
        await _context.SaveChangesAsync();
    }
}
