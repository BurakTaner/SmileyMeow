using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmileyMeow.Data;
using SmileyMeow.DTOs;
using SmileyMeow.ViewModels;
using VetClinicLibrary.Appointmentt;
using VetClinicLibrary.Appointmentt.PatientInformationn;
using VetClinicLibrary.NotUserParentandPet;
using VetClinicLibrary.Person;
using VetClinicLibrary.Person.Locationn;
using VetClinicLibrary.PetnPersonn;
using VetClinicLibrary.Pett;

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
    public async Task<IActionResult> TakeUserAppointment(int? selectedPetFromProfile)
    {
        int? loggedUserParentId = _context.PetParents.Where(a => a.UserId == ReturnLoggedUserId()).Select(a => a.PetParentId).FirstOrDefault();
        if (loggedUserParentId is null or 0)
        {
            return View("CreateAProfileInformation");
        }
        UserAppointmentViewModel userAppointmentViewModel = await ReturnUserAppointmentEmpty(selectedPetFromProfile);
        return View(userAppointmentViewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> TakeUserAppointment([Bind("DoctorId", "AppointmentDate")] Appointment appointment,
    [Bind("SelectedPet")] SelectedFormInputUserDTO selectedFormInputNotUserDTO,
    [Bind("EatingStatusId", "PeeingStatusId", "EnergyStatusId", "InformationAboutPatient", "IlnesssesInThePast")] PatientInformation patientInformation)
    {
        int loggedUser = ReturnLoggedUserId();
        // if (ModelState.IsValid)
        if (appointment.AppointmentDate.Minute == 00 || appointment.AppointmentDate.Minute == 30)
        {
            List<Appointment> doctorAppointments = await GetUserAppointments(appointment);
            if (doctorAppointments.Count is 0)
            {
                await InsertToUserAppointments(appointment, selectedFormInputNotUserDTO, patientInformation, loggedUser);
                return RedirectToAction("AppointmentsResult", "Appointments");
            }
        }

        UserAppointmentViewModel userAppointmentViewModel = await MakeUserViewModelAgain(appointment, selectedFormInputNotUserDTO, patientInformation, loggedUser);
        ModelState.AddModelError("","There is already an appointment for this date");
        return View(userAppointmentViewModel);
    }

    private async Task<UserAppointmentViewModel> MakeUserViewModelAgain(Appointment appointment, SelectedFormInputUserDTO selectedFormInputNotUserDTO, PatientInformation patientInformation, int loggedUser)
    {
        UserAppointmentViewModel userAppointmentViewModel = new();
        await AddAlreadyAddedPetsToViewModel(loggedUser, userAppointmentViewModel);
        userAppointmentViewModel.Appointment = appointment;
        userAppointmentViewModel.DoctorList = await _context.Doctors.Include(a => a.DoctorTitle).ToListAsync();
        userAppointmentViewModel.PatientInformation = patientInformation;
        userAppointmentViewModel.SelectedFormInputUserDTO = selectedFormInputNotUserDTO;
        userAppointmentViewModel.StatusLevelList = await _context.StatusLevels.ToListAsync();
        return userAppointmentViewModel;
    }

    public async Task<IActionResult> TakeNotUserAppointment()
    {
        NotUserAppointmentViewModel appointmentViewModel = await ReturnNotUserAppointmentEmpty();
        return View(appointmentViewModel);
    }



    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> TakeNotUserAppointment([Bind("FirstName", "MiddleName", "LastName", "PhoneNumber", "Email")] NotUserParent notUserParent,
     [Bind("Name", "DOB", "PetGenderId", "SpecieId", "BreedId")] NotUserParentsPet notUserParentsPet,
     [Bind("EatingStatusId", "PeeingStatusId", "EnergyStatusId", "InformationAboutPatient", "IlnesssesInThePast")] PatientInformation patientInformation,
     [Bind("DoctorId", "AppointmentDate")] NotUserAppointment notUserAppointment,
     [Bind("DistrictId", "AddressDetails")] Address address, [Bind("CityId")] SelectedFormInputCityDTO selectedFormInputNotUserDTO)
    {
        if (ModelState.IsValid){

        if (notUserAppointment.AppointmentDate.Minute != 00 && notUserAppointment.AppointmentDate.Minute != 30)
        {
            NotUserAppointmentViewModel appointmentViewModell = await MakeNotUserViewModelAgain(
            notUserParent, notUserParentsPet, patientInformation,
            notUserAppointment, address, selectedFormInputNotUserDTO);
            ModelState.AddModelError("","You have choose invalid date or time");
            return View(appointmentViewModell);
        }
        List<NotUserAppointment> doctorAppointments = await GetNotUserAppointments(notUserAppointment);

        if (doctorAppointments.Count == 0)
        {
            await InsertToNotUserAppointments(notUserParent, notUserParentsPet, patientInformation, notUserAppointment, address);
            return RedirectToAction("AppointmentsResult", "Appointments");
        }
        }

        // foreach (NotUserAppointment selectedDoctorAppointments in doctorAppointments)
        // {
        //     if(selectedDoctorAppointments.AppointmentDate.ToShortTimeString() == notUserAppointment.AppointmentDate.AddMinutes(20).ToShortTimeString()
        //      || selectedDoctorAppointments.AppointmentDate.AddMinutes(-20).ToShortTimeString() == notUserAppointment.AppointmentDate.ToShortTimeString())
        // }



        NotUserAppointmentViewModel appointmentViewModel = await MakeNotUserViewModelAgain(notUserParent, notUserParentsPet, patientInformation, notUserAppointment, address, selectedFormInputNotUserDTO);
        ModelState.AddModelError("","There is already an appointment for this date");
        return View(appointmentViewModel);
    }
    public IActionResult AppointmentsResult() {
        return View();
    }

    private async Task<List<NotUserAppointment>> GetNotUserAppointments(NotUserAppointment notUserAppointment)
    {
        return await _context.NotUserAppointments
        .Where(a => a.DoctorId == notUserAppointment.DoctorId &&
        a.AppointmentDate.Year == notUserAppointment.AppointmentDate.Year
        && a.AppointmentDate.Month == notUserAppointment.AppointmentDate.Month
        && a.AppointmentDate.Day == notUserAppointment.AppointmentDate.Day && 
        notUserAppointment.AppointmentDate.Hour == a.AppointmentDate.Hour && 
        notUserAppointment.AppointmentDate.Minute == a.AppointmentDate.Minute)
        .AsSplitQuery()
        .ToListAsync();
    }
    private async Task<List<Appointment>> GetUserAppointments(Appointment appointment)
    {
        return await _context.Appointments
        .Where(a => a.DoctorId == appointment.DoctorId &&
        a.AppointmentDate.Year == appointment.AppointmentDate.Year
        && a.AppointmentDate.Month == appointment.AppointmentDate.Month
        && a.AppointmentDate.Day == appointment.AppointmentDate.Day && 
        appointment.AppointmentDate.Hour == a.AppointmentDate.Hour && 
        a.AppointmentDate.Minute == appointment.AppointmentDate.Minute)
        .AsSplitQuery()
        .ToListAsync();
    }

    private async Task InsertToNotUserAppointments(NotUserParent notUserParent, NotUserParentsPet notUserParentsPet, PatientInformation patientInformation, NotUserAppointment notUserAppointment, Address address)
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

    private async Task InsertToUserAppointments(Appointment appointment, SelectedFormInputUserDTO selectedFormInputNotUserDTO, PatientInformation patientInformation, int loggedUser)
    {
        int loggedUsersParentId = await _context.PetParents.Where(a => a.UserId == ReturnLoggedUserId()).Select(a => a.PetParentId).FirstOrDefaultAsync();
        PetnPerson joinTable = await _context.PetsnPersons.Where(a => a.PetParentId == loggedUsersParentId && a.AnimalId == selectedFormInputNotUserDTO.SelectedPet).FirstOrDefaultAsync();
        appointment.AppointmentStatussId = 6;
        appointment.PatientInformation = patientInformation;
        appointment.PetnPerson= joinTable;
        _context.Appointments.Add(appointment);
        await _context.SaveChangesAsync();
    }

    private async Task<NotUserAppointmentViewModel> MakeNotUserViewModelAgain(NotUserParent notUserParent, NotUserParentsPet notUserParentsPet, PatientInformation patientInformation, NotUserAppointment notUserAppointment, Address address, SelectedFormInputCityDTO selectedFormInputNotUserDTO)
    {
        NotUserAppointmentViewModel appointmentViewModell = new();

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
        appointmentViewModell.CityList = (selectedFormInputNotUserDTO.CityId == 0 ? null : appointmentViewModell.CityList = await _context.Cities.ToListAsync());
        appointmentViewModell.SelectedFormInputCityDTO = selectedFormInputNotUserDTO;
        appointmentViewModell.DistrictList = await _context.Districts.Where(a => a.CityId == selectedFormInputNotUserDTO.CityId).ToListAsync();
        return appointmentViewModell;
    }
    private async Task<NotUserAppointmentViewModel> ReturnNotUserAppointmentEmpty()
    {
        NotUserAppointmentViewModel appointmentViewModel = new();

        appointmentViewModel.DoctorList = await _context.Doctors
        .Include(a => a.DoctorTitle)
        .ToListAsync();

        appointmentViewModel.NotUserParent = new();
        appointmentViewModel.NotUserParentsPet = new();
        appointmentViewModel.PetGenderList = await _context.PetGenders.ToListAsync();
        appointmentViewModel.SpecieList = await _context.Species.ToListAsync();
        appointmentViewModel.BreedList = await _context.Breeds.ToListAsync();
        appointmentViewModel.StatusLevelList = await _context.StatusLevels.ToListAsync();
        appointmentViewModel.Address = new();
        appointmentViewModel.PatientInformation = new();
        appointmentViewModel.NotUsersAppointment = new();
        appointmentViewModel.SelectedFormInputCityDTO = new();

        return appointmentViewModel;
    }
    private async Task<UserAppointmentViewModel> ReturnUserAppointmentEmpty(int? selectedPetFromProfile)
    {
        int loggedUser = ReturnLoggedUserId();

        UserAppointmentViewModel userAppointmentViewModel = new();

        await AddAlreadyAddedPetsToViewModel(loggedUser, userAppointmentViewModel);

        userAppointmentViewModel.DoctorList = await _context.Doctors.Include(a => a.DoctorTitle).ToListAsync();
        userAppointmentViewModel.StatusLevelList = await _context.StatusLevels.ToListAsync();
        userAppointmentViewModel.PatientInformation = new();
        userAppointmentViewModel.Appointment = new();
        userAppointmentViewModel.SelectedFormInputUserDTO = new();
        if (selectedPetFromProfile is not null)
        {
            userAppointmentViewModel.SelectedFormInputUserDTO.SelectedPet = (int)selectedPetFromProfile;

        }
        
        return userAppointmentViewModel;
    }

    private async Task AddAlreadyAddedPetsToViewModel(int loggedUser, UserAppointmentViewModel userAppointmentViewModel)
    {
        List<int> alreadyAddedPetsIds = await _context.PetsnPersons.
        Where(a => a.PetParent.UserId == loggedUser).
        Select(a => a.AnimalId).ToListAsync();
        userAppointmentViewModel.AlreadyAddedPets = new();
        foreach (int Id in alreadyAddedPetsIds)
        {
            Pet addedPet = await _context.Pets.FirstOrDefaultAsync(a => a.AnimalId == Id);
            userAppointmentViewModel.AlreadyAddedPets.Add(addedPet);
        }
    }
}
