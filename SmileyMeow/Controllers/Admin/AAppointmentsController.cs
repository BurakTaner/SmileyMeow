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

namespace SmileyMeow.Controllers.Admin;

public class AAppointmentsController : Controller
{
    private readonly ILogger<AAppointmentsController> _logger;
    private readonly SmileyMeowDbContext _context;

    public AAppointmentsController(ILogger<AAppointmentsController> logger, SmileyMeowDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        List<Appointment> allAppointments = await ReturnAllAppointments();
        return View(allAppointments);
    }

    public async Task<IActionResult> Info(int id)
    {
        AppointmentsViewModel appoinmentsViewModel = await ReturnAppointmentsViewModel(id);
        return View(appoinmentsViewModel);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(int id, [Bind("AppointmentStatusId")] AppointmentUpdateDTO appointmentUpdateDTO) {

        if(ModelState.IsValid) {
            Appointment appointment = await _context.Appointments.FirstOrDefaultAsync();
            appointment.AppointmentStatussId = appointmentUpdateDTO.AppointmentStatusId;
            _context.Update(appointment);
            await _context.SaveChangesAsync();
            return RedirectToAction("","AAppointments");
        }
        AppointmentsViewModel appoinmentsViewModel = await ReturnAppointmentsViewModel(id);
        return View("Info",appoinmentsViewModel);
    }
    //----------------------------------------------------------------------------------------------------------------//

    private async Task<AppointmentsViewModel> ReturnAppointmentsViewModel(int id)
    {
        AppointmentsViewModel appoinmentsViewModel = new();
        appoinmentsViewModel.Appointment = await _context.Appointments.Include(a => a.Doctor).ThenInclude(a => a.DoctorTitle).Include(a => a.PetnPerson).
        ThenInclude(a => a.Pet).
        Include(a => a.PetnPerson).
        ThenInclude(a => a.PetParent).
        FirstOrDefaultAsync(a => a.AppointmentId == id);
        appoinmentsViewModel.AppointmentStatusList = await _context.AppointmentStatuses.ToListAsync();
        return appoinmentsViewModel;
    }
    private async Task<List<Appointment>> ReturnAllAppointments()
    {
        return await _context.Appointments
        .Include(a => a.Doctor)
        .ThenInclude(a => a.DoctorTitle)
        .Include(a => a.PetnPerson.PetParent)
        .Include(a => a.PetnPerson.Pet)
        .Include(a => a.AppointmentStatus)
        .OrderByDescending(a => a.AppointmentId)
        .ToListAsync();
    }
}
