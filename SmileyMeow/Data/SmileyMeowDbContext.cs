using System.Buffers;
using Microsoft.EntityFrameworkCore;
using VetClinicLibrary.Appointmentt;
using VetClinicLibrary.Appointmentt.PatientInformationn;
using VetClinicLibrary.Appointmentt.StatusLevell;
using VetClinicLibrary.Person;
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

    //add configuration folder later
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        // temporary 
        modelBuilder.Entity<Pet>()
                    .HasOne(p => p.AdoptionInfo)
                    .WithMany(a => a.Pet);

        modelBuilder.Entity<Appointment>()
                    .HasKey(apo => new {apo.PetnPersonId, apo.DoctorId});     

        modelBuilder.Entity<AdoptInfo>()
                    .HasKey(ado => ado.AnimalId);
        
        
        modelBuilder.Entity<Balance>()
                    .HasKey(bala => bala.BalanceId);
        
        
        modelBuilder.Entity<Pet>()
                    .HasKey(pet => pet.AnimalId);

        modelBuilder.Entity<DoctorSchool>()
                    .HasKey(docs => new { docs.DoctorId, docs.SchoolId});
        //

        // dum
        modelBuilder.Entity<Pet>().HasData(
            new Pet {AnimalId = 6, PetGenderId = 6 ,BreedId = 6, DOB = DateTime.Now, IsAdoptable = true, SpecieId = 6, Name = "Sif"}
        );

        modelBuilder.Entity<PetGender>().HasData(
            new PetGender {PetGenderId = 6, GName = "Female"}
        );

        modelBuilder.Entity<Breed>().HasData(
            new Breed {BreedId = 6, BName = "Ragdoll" }
        );

        modelBuilder.Entity<Specie>().HasData(
            new Specie { SpecieId = 6, SName = "Wolf"}
        );

        modelBuilder.Entity<AdoptInfo>().HasData(
                new AdoptInfo { AnimalId = 6, AdoptText = "So cute"}
        );
    }


}
