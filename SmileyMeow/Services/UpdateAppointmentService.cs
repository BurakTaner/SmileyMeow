using Hangfire;
using Microsoft.EntityFrameworkCore;
using SmileyMeow.Data;
using VetClinicLibrary.Appointmentt;
using System.IO;

namespace SmileyMeow.Services;

public class UpdateAppointmentService :IUpdateAppointmentService
{
    private readonly SmileyMeowDbContext _context;
    // private readonly IWriteToFileService _writetojsonfile;

    public UpdateAppointmentService(SmileyMeowDbContext context)
    {
        _context = context;
    }

    public async Task GetAppointmentsFromDb()
    {
        List<Appointment> allAppointments = await _context.Appointments
        .Include(a => a.PetnPerson)
        .ThenInclude(a => a.Pet)
        .Include(a => a.PetnPerson)
        .ThenInclude(a => a.PetParent)
        .Include(a => a.AppointmentStatus)
        .ToListAsync();
        foreach (Appointment appointment in allAppointments)
        {
            // List<UpdatedAppointment> updatedAppointments = new();
            if (appointment.AppointmentDate < DateTime.Now)
            {
                if(appointment.AppointmentStatussId == 6)
                {
                    appointment.AppointmentStatussId = 7;
                    _context.Update(appointment);
                    // UpdatedAppointment updatedAppointment = CreateDTO(appointment);
                    await _context.SaveChangesAsync();
                    BackgroundJob.Enqueue(() => Console.WriteLine("An appointment updated!"));
                    // updatedAppointments.Add(updatedAppointment);

                }
                // _writetojsonfile.ReadAndWriteToFile(updatedAppointments);
            }
        }
    }

    // private static UpdatedAppointment CreateDTO(Appointment appointment)
    // {
    //     UpdatedAppointment updatedAppointment = new();
    //     updatedAppointment.AppointmentDate = appointment.AppointmentDate;
    //     updatedAppointment.Pet = appointment.PetnPerson.Pet;
    //     updatedAppointment.PetParent = appointment.PetnPerson.PetParent;
    //     updatedAppointment.Status = appointment.AppointmentStatus.Status;
    //     return updatedAppointment;
    // }
}
