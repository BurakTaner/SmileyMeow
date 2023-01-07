using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SmileyMeow.Data;
using SmileyMeow.DTOs;
using SmileyMeow.ViewModels;
using VetClinicLibrary.Person.Locationn;

namespace SmileyMeow.Controllers.Admin;

public class ADistrictController : Controller
{
    private readonly ILogger<ADistrictController> _logger;
    private readonly SmileyMeowDbContext _context;
    public ADistrictController(ILogger<ADistrictController> logger, SmileyMeowDbContext context)
    {
        _logger = logger;
        _context = context;
    }


    public async Task<IActionResult> Index()
    {
        List<District> districtList = await ReturnAllDistrictsFromDb();
        return View(districtList);
    }

    public async Task<IActionResult> Create()
    {
        DistrictViewModel districtViewModel = new();
        districtViewModel.District = new();
        return View(districtViewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("DName", "CityId")] District district)
    {
        if (ModelState.IsValid)
        {
            _context.Add(district);
            await Save();
            return RedirectToAction("", "ADistrict");
        }

        DistrictViewModel districtViewModel = await ReturnDistrictViewModelAgain(district);
        return View(districtViewModel);
    }

    public async Task<IActionResult> Info(int id)
    {
        District district = await _context.Districts.Include(a => a.City).FirstOrDefaultAsync(a => a.DistrictId == id);
        return View(district);
    }

    public async Task<IActionResult> Delete(int id)
    {
        District district = await FindDistrict(id);
        return View(district);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> PostDelete(int id)
    {
        District deleteDistrict = await FindDistrict(id);
        _context.Remove(deleteDistrict);
        await Save();
        return RedirectToAction("", "ADistrict");
    }

    public async Task<IActionResult> Update(int id)
    {
        District district = await FindDistrict(id);
        DistrictViewModel districtViewModel = new();
        districtViewModel.District = district;
        districtViewModel.CityList = await _context.Cities.ToListAsync();
        return View(districtViewModel);

    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(int id, [Bind("DName", "CityId")] District district)
    {

        if (ModelState.IsValid)
        {
            district.DistrictId = id;
            _context.Update(district);
            await Save();
            return RedirectToAction("", "ADistrict");
        }

        return View(district);
    }

    //----------------------------------------------------------------------//
    private async Task Save()
    {
        await _context.SaveChangesAsync();
    }

    private async Task<District> FindDistrict(int id)
    {
        return await _context.Districts.FirstOrDefaultAsync(a => a.DistrictId == id);
    }

    private async Task<DistrictViewModel> ReturnDistrictViewModelAgain(District district)
    {
        DistrictViewModel districtViewModel = new();
        districtViewModel.District.DName = district.DName;
        districtViewModel.CityList = (district.CityId == 0 ? null : await _context.Cities.ToListAsync());
        return districtViewModel;
    }
    private async Task<List<District>> ReturnAllDistrictsFromDb()
    {
        return await _context.Districts
                .Include(a => a.City)
                .OrderByDescending(a => a.DistrictId)
                .ToListAsync();
    }
}
