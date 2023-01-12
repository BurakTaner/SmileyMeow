using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SmileyMeow.Data;
using VetClinicLibrary.AdoptionPet;
using VetClinicLibrary.Pett;

namespace SmileyMeow.Controllers.Admin
{
    public class APetAdoptionRequestsController : Controller
    {
        private readonly ILogger<APetAdoptionRequestsController> _logger;
        private readonly SmileyMeowDbContext _context;

        public APetAdoptionRequestsController(ILogger<APetAdoptionRequestsController> logger, SmileyMeowDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<AdoptionJoinTable> adoptionJoinTables = await _context.AdoptionJoinTables.Include(a => a.PetParent).ThenInclude(a => a.Userr).Include(a => a.Pet).ToListAsync(); 
            return View(adoptionJoinTables);
        }
        public IActionResult Confirmation(int id) {
            AdoptionJoinTable adoptionJoinTable = _context.AdoptionJoinTables.Include(a => a.Pet).Include(a => a.PetParent).FirstOrDefault(a => a.AdoptJoinTableId == id);
            return View(adoptionJoinTable);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmRequest(int id) {
            AdoptionJoinTable adoptionJoinTable = _context.AdoptionJoinTables.FirstOrDefault(a => a.AdoptJoinTableId == id);
            if (adoptionJoinTable is null)
            {
                return NotFound();
            }
            Pet pet = _context.Pets.FirstOrDefault(a => a.AnimalId == adoptionJoinTable.AnimalId);
            adoptionJoinTable.IsConfirmed = true;
            pet.IsAdoptable = false;
            adoptionJoinTable.Pet = pet;
            _context.Update(adoptionJoinTable);
            await _context.SaveChangesAsync();
            return RedirectToAction("","APetAdoptionRequests");
        }
        public IActionResult Decline(int id) {
            AdoptionJoinTable adoptionJoinTable = _context.AdoptionJoinTables.Include(a => a.Pet).Include(a => a.PetParent).FirstOrDefault(a => a.AdoptJoinTableId == id);
            return View(adoptionJoinTable);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeclineRequest(int id) {
            AdoptionJoinTable adoptionJoinTable = _context.AdoptionJoinTables.FirstOrDefault(a => a.AdoptJoinTableId == id);
            _context.Remove(adoptionJoinTable);
            await _context.SaveChangesAsync();
            return RedirectToAction("","APetAdoptionRequests");
        }
    }
}