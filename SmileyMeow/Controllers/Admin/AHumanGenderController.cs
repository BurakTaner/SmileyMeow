using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SmileyMeow.Data;
using VetClinicLibrary.Person.HumanGenderr;

namespace SmileyMeow.Controllers.Admin;

public class AHumanGenderController : Controller
{
    private readonly ILogger<AHumanGenderController> _logger;
    private readonly SmileyMeowDbContext _context;

    public AHumanGenderController(ILogger<AHumanGenderController> logger, SmileyMeowDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        List<HumanGender> humanGenders = await _context.HumanGenders.OrderByDescending(a => a.HumanGenderId).ToListAsync();
        return View(humanGenders);
    }
    public IActionResult Create() {
        HumanGender humanGender = new();
        return View(humanGender);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("GName")] HumanGender humanGender) {
        if(ModelState.IsValid) {
        _context.Add(humanGender);
        await Save();
        return RedirectToAction("","AHumanGender");
        }
        
        return View(humanGender);
    }
    public async Task<IActionResult> Info(int id)
    {
        HumanGender humanGender = await FindHumanGender(id);
        return View(humanGender);
    }

    public async Task<IActionResult> Delete(int id) {
        HumanGender humanGender = await FindHumanGender(id);
        return View(humanGender);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> PostDelete(int id)
    {
        HumanGender deleteHumanGender = await FindHumanGender(id);
        _context.Remove(deleteHumanGender);
        await Save();
        return RedirectToAction("", "AHumanGender");
    }

    public async Task<IActionResult> Update(int id) {
        HumanGender humanGender = await FindHumanGender(id);
        
        return View(humanGender);
        
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(int id,[Bind("GName")] HumanGender humanGender) {
        
        if(ModelState.IsValid) {
            humanGender.HumanGenderId = id;
            _context.Update(humanGender);
            await Save();
            return RedirectToAction("","AHumanGender");
        }

        return View(humanGender);
    }

    //-----------------------------------------------------------------------------------------//
    private async Task<HumanGender> FindHumanGender(int id)
    {
        return await _context.HumanGenders.FirstOrDefaultAsync(a => a.HumanGenderId == id);
    }

    private async Task Save()
    {
        await _context.SaveChangesAsync();
    }
}
