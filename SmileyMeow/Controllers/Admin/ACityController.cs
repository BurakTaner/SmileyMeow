using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SmileyMeow.Data;
using VetClinicLibrary.Person.Locationn;

namespace SmileyMeow.Controllers.Admin;

public class ACityController : ABaseController
{
    private readonly ILogger<ACityController> _logger;
    private readonly SmileyMeowDbContext _context;
    public ACityController(ILogger<ACityController> logger, SmileyMeowDbContext context)
    {
        _logger = logger;
        _context = context;
    }


    public async Task<IActionResult> Index()
    {
        List<City> cityList = await _context.Cities.OrderByDescending(a => a.CityId).ToListAsync();
        return View(cityList);
    }

    public IActionResult Create()
    {
        City city = new();
        return View(city);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("CName")] City city)
    {
        if (ModelState.IsValid)
        {
            _context.Add(city);
            await Save();
            return RedirectToAction("", "ACity"); 
        }
        return View();
    }

    public async Task<IActionResult> Info(int id)
    {
        City city = await FindCity(id);
        return View(city);
    }

    public async Task<IActionResult> Delete(int id) {
        City city = await FindCity(id);
        return View(city);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> PostDelete(int id)
    {
        City deleteCity = await FindCity(id);
        _context.Remove(deleteCity);
        await Save();
        return RedirectToAction("", "ACity");
    }

    public async Task<IActionResult> Update(int id) {
        City city = await FindCity(id);
        
        return View(city);
        
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(int id,[Bind("CName")] City city) {
        
        if(ModelState.IsValid) {
            city.CityId = id;
            _context.Update(city);
            await Save();
            return RedirectToAction("","ACity");
        }

        return View(city);
    }

    //----------------------------------------------------------------------//
    private async Task Save()
    {
        await _context.SaveChangesAsync();
    }

    private async Task<City> FindCity(int id)
    {
        return await _context.Cities.FirstOrDefaultAsync(a => a.CityId == id);
    }
}
