using Microsoft.EntityFrameworkCore;
using VetClinicLibrary.Appointmentt;
using VetClinicLibrary.Appointmentt.AppointmentStatuss;
using VetClinicLibrary.Appointmentt.PatientInformationn;
using VetClinicLibrary.Appointmentt.StatusLevell;
using VetClinicLibrary.Person;
using VetClinicLibrary.Person.DoctorInfoo;
using VetClinicLibrary.Person.HumanGenderr;
using VetClinicLibrary.Person.Prounounn;
using VetClinicLibrary.Person.Titles;
using VetClinicLibrary.PetnPersonn;
using VetClinicLibrary.Pett;
using VetClinicLibrary.Pett.Adopt;
using VetClinicLibrary.Pett.Breedd;
using VetClinicLibrary.Pett.PetGenderr;
using VetClinicLibrary.Pett.Speciee;
using VetClinicLibrary.Schooll;
using VetClinicLibrary.SchoolTypee;
using VetClinicLibrary.User;

namespace SmileyMeow.Data;
public class SmileyMeowDbContext : DbContext
{
    public SmileyMeowDbContext(DbContextOptions<SmileyMeowDbContext> options) : base(options)
    { }

    public DbSet<PatientInformation> PatientInformations { get; set; }
    public DbSet<StatusLevel> StatusLevels { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Balance> Balances { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<PetParent> PetParents { get; set; }
    public DbSet<PetnPerson> PetsnPersons { get; set; }
    public DbSet<AdoptInfo> AdoptInfos { get; set; }
    public DbSet<Breed> Breeds { get; set; }
    public DbSet<PetGender> PetGenders { get; set; }
    public DbSet<Specie> Species { get; set; }
    public DbSet<Pet> Pets { get; set; }
    public DbSet<School> School { get; set; }
    public DbSet<SchoolType> SchoolType { get; set; }
    public DbSet<Rolee> Rolees { get; set; }
    public DbSet<Userr> Userrs { get; set; }
    public DbSet<DoctorSchool> DoctorSchools { get; set; }
    public DbSet<DoctorTitle> DoctorTitles { get; set; }
    public DbSet<DoctorInfo> DoctorInfos { get; set; }
    public DbSet<Pronoun> Pronouns { get; set; }

    //add configuration folder later
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // temporary 
        modelBuilder.Entity<Pet>()
                    .HasOne(p => p.AdoptionInfo)
                    .WithMany(a => a.Pet);

        modelBuilder.Entity<Appointment>()
                    .HasKey(apo => new { apo.PetnPersonId, apo.DoctorId });

        modelBuilder.Entity<AdoptInfo>()
                    .HasKey(ado => ado.AnimalId);


        modelBuilder.Entity<Balance>()
                    .HasKey(bala => bala.BalanceId);

        modelBuilder.Entity<Pet>()
                    .HasKey(pet => pet.AnimalId);

        modelBuilder.Entity<DoctorSchool>()
                    .HasKey(docs => new { docs.DoctorId, docs.SchoolId });

        modelBuilder.Entity<Userr>().Ignore(p => p.PasswordRepeat);

        modelBuilder.Entity<DoctorInfo>()
                        .HasKey(di => di.DoctorId);

        modelBuilder.Entity<Pronoun>()
                        .HasKey(p => p.ProunounId);
        
        modelBuilder.Entity<Pronoun>()
                        .HasMany(p => p.PetParents)
                        .WithOne(pp => pp.Pronoun);
        
        modelBuilder.Entity<Pronoun>()
                        .HasMany(p => p.Doctors)
                        .WithOne(d => d.Pronoun);

        //

        // dummy data
        modelBuilder.Entity<Pet>().HasData(
            new Pet { AnimalId = 6, PetGenderId = 6, BreedId = 6, DOB = DateTime.Now, IsAdoptable = true, SpecieId = 6, Name = "Sif" }
        );

        modelBuilder.Entity<PetGender>().HasData(
            new PetGender { PetGenderId = 6, GName = "Female" }
        );

        modelBuilder.Entity<Breed>().HasData(
            new Breed { BreedId = 6, BName = "Ragdoll" }
        );

        modelBuilder.Entity<Specie>().HasData(
            new Specie { SpecieId = 6, SName = "Wolf" }
        );

        modelBuilder.Entity<AdoptInfo>().HasData(
            new AdoptInfo { AnimalId = 6, AdoptText = "So cute" }
        );

        modelBuilder.Entity<SchoolType>().HasData(
            new SchoolType { SchoolTypeId = 6, Name = "University" }
        );

        modelBuilder.Entity<School>().HasData(
            new School { SchoolId = 6, SchoolTypeId = 6, Name = "University of California, Davis" }
        );

        modelBuilder.Entity<Userr>().HasData(
            new Userr { UserrId = 6, Email = "artorias@gmail.com", Password = "sif123456", RoleeId = 6 },
            new Userr { UserrId = 666, Email = "patches@gmail.com", Password = "patches123456", RoleeId = 666 }
        );

        modelBuilder.Entity<Rolee>().HasData(
            new Rolee { RoleeId = 6, Name = "PetParent" },
            new Rolee { RoleeId = 666, Name = "Doctor" }
        );

        modelBuilder.Entity<Doctor>().HasData(
            new Doctor { DoctorId = 6, FirstName = "Patches", MiddleName = null, LastName = "Whisper", BalanceId = 666, DOB = Convert.ToDateTime("1978/12/10"), PhoneNumber = "05434561275", UserId = 666, HumanGenderId = 66, DoctorTitleId = 6, PronounId = 6}
        );

        modelBuilder.Entity<PetParent>().HasData(
            new PetParent { UserId = 6, FirstName = "Artorias", MiddleName = "Solaire", LastName = "Astora", BalanceId = 6, DOB = Convert.ToDateTime("1999/6/8"), PetParentId = 6, HumanGenderId = 6,PronounId = 6}
        );

        modelBuilder.Entity<HumanGender>().HasData(
            new HumanGender { HumanGenderId = 6, GName = "Non-Binary"}, 
            new HumanGender { HumanGenderId = 66, GName = "Genderfluid"} 
        );

        modelBuilder.Entity<DoctorSchool>().HasData(
            new DoctorSchool { DoctorId = 6, SchoolId = 6}
        );

        modelBuilder.Entity<PetnPerson>().HasData(
            new PetnPerson { AnimalId = 6, PetParentId = 6, PetnPersonId = 6}
        );

        modelBuilder.Entity<Balance>().HasData(
            new Balance { BalanceId = 6, PersonBalance = Convert.ToDecimal("150.55")},
            new Balance { BalanceId = 666, PersonBalance = Convert.ToDecimal("90.65")}
        );

        modelBuilder.Entity<Appointment>().HasData(
            new Appointment { PetnPersonId = 6, DoctorId = 6, TimeCreated = DateTime.Now, AppointmentDate = DateTime.Now.AddDays(30), AppointmentStatussId = 6}
        );

        modelBuilder.Entity<DoctorTitle>().HasData(
            new DoctorTitle { DoctorTitleId = 6, TFullForm = "Vetenerian", TShortForm = "DVM"}
            
        );

        modelBuilder.Entity<DoctorInfo>().HasData(
            new DoctorInfo { DoctorId = 6, DoctorInformation = "Hi, I am Dr. Patches, a veterinarian with over 10 years of experience in the field. I received my Doctor of Veterinary Medicine degree from the University of California, Davis and have since worked at a variety of clinics, caring for all types of animals and their petparents. My specialty is in small animal medicine, but I am well-versed in treating all kinds of creatures, from cats and dogs to birds and reptiles. I am passionate about helping animals and their owners, and take pride in being able to diagnose and treat a wide range of conditions. In my free time, I enjoy volunteering at local animal shelters and spending time with my own pets, which include a rescue dog and two cats. I believe that effective communication with petparents is crucial in providing the best care for their beloved animals."}
        );

        modelBuilder.Entity<Pronoun>().HasData(
            new Pronoun { ProunounId = 6, PName = "They/Them"}
        );

        modelBuilder.Entity<AppointmentStatus>().HasData(
            new AppointmentStatus { AppointmentStatussId = 6, Status = "Active Appointment" },
            new AppointmentStatus { AppointmentStatussId = 7, Status = "Expired Appointment" }, 
            new AppointmentStatus { AppointmentStatussId = 8, Status = "Canceled Appointment" }            
            
        );
    }

}
