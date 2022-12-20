using Microsoft.EntityFrameworkCore;
using VetClinicLibrary.Appointmentt;
using VetClinicLibrary.Appointmentt.PatientInformationn;
using VetClinicLibrary.Appointmentt.StatusLevell;
using VetClinicLibrary.Person;
using VetClinicLibrary.PetnPersonn;
using VetClinicLibrary.Pett;
using VetClinicLibrary.Pett.Adopt;
using VetClinicLibrary.Pett.Breedd;
using VetClinicLibrary.Pett.Gender;
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
        modelBuilder.Entity<Pet>()
                    .HasOne(p => p.AdoptionInfo)
                    .WithMany(a => a.Pet);

        modelBuilder.Entity<Appointment>()
                    .HasKey(apo => new {apo.PetnPersonId, apo.DoctorId});

        modelBuilder.Entity<AdoptInfo>()
                    .HasKey(ado => ado.AnimalId);
        
        
        modelBuilder.Entity<Balance>()
                    .HasKey(bala => bala.PersonId);
        
        
        modelBuilder.Entity<Pet>()
                    .HasKey(pet => pet.AnimalId);

        modelBuilder.Entity<DoctorSchool>()
                    .HasKey(docs => new { docs.DoctorId, docs.SchoolId});
    }


}
