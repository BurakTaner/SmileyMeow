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
using VetClinicLibrary.Person.Prounounn;

namespace SmileyMeow.Controllers.Admin;

public class APronounController : Controller
{
    private readonly ILogger<APronounController> _logger;
    private readonly SmileyMeowDbContext _context;
    public APronounController(ILogger<APronounController> logger, SmileyMeowDbContext context)
    {
        _logger = logger;
        _context = context;
    }


    public async Task<IActionResult> Index()
    {
        List<Pronoun> pronounList = await _context.Pronouns.OrderByDescending(a => a.ProunounId).ToListAsync();
        return View(pronounList);
    }
    public IActionResult Create()
    {
        Pronoun pronoun = new();
        return View(pronoun);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("PName")] Pronoun pronoun)
    {
        if (ModelState.IsValid)
        {
            _context.Add(pronoun);
            await Save();
            return RedirectToAction("", "APronoun"); 
        }

        Pronoun returnPronoun = pronoun;
        return View(returnPronoun);
    }

    public async Task<IActionResult> Info(int id)
    {
        Pronoun pronoun = await FindPronoun(id);
        return View(pronoun);
    }

    public async Task<IActionResult> Delete(int id) {
        Pronoun pronoun = await FindPronoun(id);
        return View(pronoun);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> PostDelete(int id)
    {
        Pronoun deletePronoun = await FindPronoun(id);
        _context.Remove(deletePronoun);
        await Save();
        return RedirectToAction("", "APronoun");
    }

    public async Task<IActionResult> Update(int id) {
        Pronoun pronoun = await FindPronoun(id);
        return View(pronoun);
        
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(int id,[Bind("PName")] Pronoun pronoun) {
        
        if(ModelState.IsValid) {
            pronoun.ProunounId = id;
            _context.Update(pronoun);
            await Save();
            return RedirectToAction("","APronoun");
        }

        return View(pronoun);
    }

    //----------------------------------------------------------------------//
    private async Task Save()
    {
        await _context.SaveChangesAsync();
    }

    private async Task<Pronoun> FindPronoun(int id)
    {
        return await _context.Pronouns.FirstOrDefaultAsync(a => a.ProunounId == id);
    }
}
