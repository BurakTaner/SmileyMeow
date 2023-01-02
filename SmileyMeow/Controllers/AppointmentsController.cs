using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmileyMeow.Data;
using SmileyMeow.DTOs;
using SmileyMeow.ViewModels;
using VetClinicLibrary.Appointmentt.PatientInformationn;
using VetClinicLibrary.NotUserParentandPet;
using VetClinicLibrary.Person.Locationn;

namespace SmileyMeow.Controllers;
public class AppointmentsController : BasyController
{
    private readonly ILogger<AppointmentsController> _logger;
    private readonly SmileyMeowDbContext _context;

    public AppointmentsController(ILogger<AppointmentsController> logger, SmileyMeowDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> TakeNotUserAppointment()
    {
        AppointmentViewModel appointmentViewModel = await ReturnNotUserAppointmentEmpty();
        return View(appointmentViewModel);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> TakeNotUserAppointment([Bind("FirstName", "MiddleName", "LastName", "PhoneNumber", "Email")] NotUserParent notUserParent,
     [Bind("Name", "DOB", "PetGenderId", "SpecieId", "BreedId")] NotUserParentsPet notUserParentsPet,
     [Bind("EatingStatusId", "PeeingStatusId", "EnergyStatusId", "InformationAboutPatient", "IlnesssesInThePast")] PatientInformation patientInformation,
     [Bind("DoctorId", "AppointmentDate")] NotUserAppointment notUserAppointment,
     [Bind("DistrictId", "AddressDetails")] Address address, [Bind("CityId")] SelectedFormInputDTO selectedFormInputDTO)
    {
        // if (ModelState.IsValid)

        if (notUserAppointment.AppointmentDate.Minute != 00 && notUserAppointment.AppointmentDate.Minute != 30)
        {
            AppointmentViewModel appointmentViewModell = await MakeViewModelAgain(
            notUserParent, notUserParentsPet, patientInformation,
            notUserAppointment, address, selectedFormInputDTO);

            return View(appointmentViewModell);
        }
        // List<NotUserAppointment> doctorAppointments = await GetAppointments(notUserAppointment);

        // if (doctorAppointments.Count == 0)
        // {
        //     await InsertToDatabase(notUserParent, notUserParentsPet, patientInformation, notUserAppointment, address);
        //     return RedirectToAction("Index", "Home");
        // }

        // foreach (NotUserAppointment selectedDoctorAppointments in doctorAppointments)
        // {
        //     if(selectedDoctorAppointments.AppointmentDate.ToShortTimeString() == notUserAppointment.AppointmentDate.AddMinutes(20).ToShortTimeString()
        //      || selectedDoctorAppointments.AppointmentDate.AddMinutes(-20).ToShortTimeString() == notUserAppointment.AppointmentDate)
        // }



        AppointmentViewModel appointmentViewModel = await MakeViewModelAgain(notUserParent, notUserParentsPet, patientInformation, notUserAppointment, address, selectedFormInputDTO);
        return View(appointmentViewModel);
    }

    private async Task<List<NotUserAppointment>> GetAppointments(NotUserAppointment notUserAppointment)
    {
        return await _context.NotUserAppointments
        .Where(a => a.DoctorId == notUserAppointment.DoctorId &&
        a.AppointmentDate.Year == notUserAppointment.AppointmentDate.Year
        && a.AppointmentDate.Month == notUserAppointment.AppointmentDate.Month
        && a.AppointmentDate.Day == notUserAppointment.AppointmentDate.Day)
        .ToListAsync();
    }

    private async Task InsertToDatabase(NotUserParent notUserParent, NotUserParentsPet notUserParentsPet, PatientInformation patientInformation, NotUserAppointment notUserAppointment, Address address)
    {
        NotUserParentnPet joinTable = new();
        notUserParent.Address = address;
        joinTable.NotUserParentsPet = notUserParentsPet;
        joinTable.NotUserParent = notUserParent;
        notUserAppointment.PatientInformation = patientInformation;
        notUserAppointment.AppointmentStatussId = 6;
        notUserAppointment.NotUserParentnPet = joinTable;
        _context.PatientInformations.Add(patientInformation);
        _context.Addresses.Add(address);
        _context.NotUserParentsPet.Add(notUserParentsPet);
        _context.NotUserParents.Add(notUserParent);
        _context.NotUserParentnPet.Add(joinTable);
        _context.NotUserAppointments.Add(notUserAppointment);
        await _context.SaveChangesAsync();
    }

    private async Task<AppointmentViewModel> MakeViewModelAgain(NotUserParent notUserParent, NotUserParentsPet notUserParentsPet, PatientInformation patientInformation, NotUserAppointment notUserAppointment, Address address, SelectedFormInputDTO selectedFormInputDTO)
    {
        AppointmentViewModel appointmentViewModell = new ();

        appointmentViewModell.NotUserParent = notUserParent;
        appointmentViewModell.NotUserParentsPet = notUserParentsPet;
        appointmentViewModell.PetGenderList = await _context.PetGenders.ToListAsync();
        appointmentViewModell.SpecieList = await _context.Species.ToListAsync();
        appointmentViewModell.BreedList = await _context.Breeds.ToListAsync();
        appointmentViewModell.StatusLevelList = await _context.StatusLevels.ToListAsync();
        appointmentViewModell.Address = address;
        appointmentViewModell.PatientInformation = patientInformation;
        appointmentViewModell.NotUsersAppointment = notUserAppointment;
        appointmentViewModell.DoctorList = await _context.Doctors.Include(a => a.DoctorTitle).ToListAsync();
        if (selectedFormInputDTO.CityId == 0)
        {
            appointmentViewModell.CityList = null;
        }
        else
        {
            appointmentViewModell.CityList = await _context.Cities.ToListAsync();
        }
        appointmentViewModell.SelectedFormInputDTO = selectedFormInputDTO;
        if (selectedFormInputDTO.CityId != 0)
        {
            appointmentViewModell.DistrictList = await _context.Districts.Where(a => a.CityId == selectedFormInputDTO.CityId).ToListAsync();

        }
        else {
            appointmentViewModell.DistrictList = null;
        }
        // appointmentViewModell.SelectedCity = selectedCity;
        // appointmentViewModell.District =  _context.Districts.ToListAsync();
        return appointmentViewModell;
    }
    private async Task<AppointmentViewModel> ReturnNotUserAppointmentEmpty()
    {
        AppointmentViewModel appointmentViewModel = new();

        appointmentViewModel.DoctorList = await _context.Doctors
        .Include(a => a.DoctorTitle)
        .ToListAsync();

        appointmentViewModel.NotUserParent = new NotUserParent();
        appointmentViewModel.NotUserParentsPet = new NotUserParentsPet();
        appointmentViewModel.PetGenderList = await _context.PetGenders.ToListAsync();
        appointmentViewModel.SpecieList = await _context.Species.ToListAsync();
        appointmentViewModel.BreedList = await _context.Breeds.ToListAsync();
        appointmentViewModel.StatusLevelList = await _context.StatusLevels.ToListAsync();
        appointmentViewModel.Address = new();
        appointmentViewModel.PatientInformation = new PatientInformation();
        appointmentViewModel.NotUsersAppointment = new NotUserAppointment();
        appointmentViewModel.SelectedFormInputDTO = new SelectedFormInputDTO();
        return appointmentViewModel;
    }


    // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    // public IActionResult Error()
    // {
    //     return View("Error!");
    // }
}
