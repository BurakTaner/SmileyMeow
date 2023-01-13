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
using VetClinicLibrary.Appointmentt;
using VetClinicLibrary.NotUserParentandPet;

namespace SmileyMeow.Controllers.Admin;

public class ANotUserAppointmentsController : Controller
{
    private readonly ILogger<ANotUserAppointmentsController> _logger;
    private readonly SmileyMeowDbContext _context;

    public ANotUserAppointmentsController(ILogger<ANotUserAppointmentsController> logger, SmileyMeowDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        List<NotUserAppointment> allAppointments = await ReturnAllNotUserAppointmentsAppointments();
        return View(allAppointments);
    }

    public async Task<IActionResult> Info(int id)
    {
        NotUserAppointmentUpdateViewModel notUserAppointmentUpdateViewModel = await ReturnNotAppointmentsViewModel(id);
        return View(notUserAppointmentUpdateViewModel);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(int id, [Bind("AppointmentStatusId")] AppointmentUpdateDTO appointmentUpdateDTO) {

        if(ModelState.IsValid) {
            NotUserAppointment notUserAppointment = await _context.NotUserAppointments.FirstOrDefaultAsync(a => a.AppointmentId == id);
            notUserAppointment.AppointmentStatussId = appointmentUpdateDTO.AppointmentStatusId;
            _context.Update(notUserAppointment);
            await _context.SaveChangesAsync();
            return RedirectToAction("","ANotUserAppointments");
        }
        NotUserAppointmentUpdateViewModel notUserAppointmentUpdateViewModel = await ReturnNotAppointmentsViewModel(id);
        return View("Info",notUserAppointmentUpdateViewModel);
    }
    //----------------------------------------------------------------------------------------------------------------//

    private async Task<NotUserAppointmentUpdateViewModel> ReturnNotAppointmentsViewModel(int id)
    {
        NotUserAppointmentUpdateViewModel notUserAppointmentUpdateViewModel = new();
        notUserAppointmentUpdateViewModel.NotUserAppointment = await _context.NotUserAppointments
        .Include(a => a.Doctor)
        .ThenInclude(a => a.DoctorTitle)
        .Include(a => a.NotUserParentnPet.NotUserParent)
        .Include(a => a.NotUserParentnPet.NotUserParentsPet)
        .FirstOrDefaultAsync(a => a.AppointmentId == id);
        notUserAppointmentUpdateViewModel.AppointmentStatusList = await _context.AppointmentStatuses.ToListAsync();
        return notUserAppointmentUpdateViewModel;
    }
    private async Task<List<NotUserAppointment>> ReturnAllNotUserAppointmentsAppointments()
    {
        return await _context.NotUserAppointments
        .Include(a => a.Doctor)
        .ThenInclude(a => a.DoctorTitle)
        .Include(a => a.NotUserParentnPet.NotUserParent)
        .Include(a => a.NotUserParentnPet.NotUserParentsPet)
        .Include(a => a.AppointmentStatus)
        .OrderByDescending(a => a.AppointmentId)
        .ToListAsync();
    }
}
