using Microsoft.EntityFrameworkCore;
using VetClinicLibrary.Appointmentt;
using VetClinicLibrary.Appointmentt.AppointmentStatuss;
using VetClinicLibrary.Appointmentt.PatientInformationn;
using VetClinicLibrary.Appointmentt.StatusLevell;
using VetClinicLibrary.NotUserParentandPet;
using VetClinicLibrary.Person;
using VetClinicLibrary.Person.DoctorInformationn;
using VetClinicLibrary.Person.HumanGenderr;
using VetClinicLibrary.Person.Locationn;
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
    public DbSet<School> Schools { get; set; }
    public DbSet<SchoolType> SchoolTypes { get; set; }
    public DbSet<Rolee> Rolees { get; set; }
    public DbSet<Userr> Userrs { get; set; }
    public DbSet<DoctorSchool> DoctorSchools { get; set; }
    public DbSet<DoctorTitle> DoctorTitles { get; set; }
    public DbSet<DoctorInformation> DoctorInformations { get; set; }
    public DbSet<Pronoun> Pronouns { get; set; }
    public DbSet<NotUserAppointment> NotUserAppointments { get; set; }
    public DbSet<NotUserParent> NotUserParents { get; set; }
    public DbSet<NotUserParentnPet> NotUserParentnPet { get; set; }
    public DbSet<NotUserParentsPet> NotUserParentsPet { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<AppointmentStatus> AppointmentStatuses { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<District> Districts  { get; set; }
    public DbSet<HumanGender> HumanGenders  { get; set; }

    //add configuration directory later
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // temporary 
        modelBuilder.Entity<Pet>()
                    .HasOne(p => p.AdoptionInfo)
                    .WithOne(a => a.Pet);
        
        modelBuilder.Entity<DoctorInformation>()
                    .HasOne(a => a.Doctor)
                    .WithOne(b => b.DoctorInformation)
                    .HasForeignKey<DoctorInformation>(a => a.DoctorId);

        modelBuilder.Entity<Appointment>()
                    .HasKey(apo => apo.AppointmentId);

        modelBuilder.Entity<AdoptInfo>()
                    .HasKey(ado => ado.AdoptInfoId);


        modelBuilder.Entity<Balance>()
                    .HasKey(bala => bala.BalanceId);

        modelBuilder.Entity<Pet>()
                    .HasKey(pet => pet.AnimalId);

        modelBuilder.Entity<DoctorSchool>()
                    .HasKey(docs => new { docs.DoctorId, docs.SchoolId });

        modelBuilder.Entity<Userr>().Ignore(p => p.ConfirmPasswordd);

        modelBuilder.Entity<DoctorInformation>()
                        .HasKey(di => di.DoctorId);

        modelBuilder.Entity<Pronoun>()
                        .HasKey(p => p.ProunounId);

        modelBuilder.Entity<PetParent>()
                        .HasOne(a => a.HumanGender)
                        .WithMany(b => b.PetParent)
                        .HasForeignKey(a => a.HumanGenderId);
                        
        modelBuilder.Entity<PetParent>()
                        .HasOne(a => a.Pronoun)
                        .WithMany(b => b.PetParents)
                        .HasForeignKey(a => a.PronounId);

        modelBuilder.Entity<Doctor>()
                        .HasOne(p => p.Pronoun)
                        .WithMany(d => d.Doctors)
                        .HasForeignKey(a => a.PronounId);

        modelBuilder.Entity<PatientInformation>()
                        .HasKey(a => a.PatientInformationId);

        

        modelBuilder.Entity<AppointmentStatus>()
                        .HasKey(a => a.AppointmentStatussId);


        modelBuilder.Entity<Appointment>()
                        .HasOne(a => a.AppointmentStatus)
                        .WithMany(b => b.Appointments)
                        .HasForeignKey(a => a.AppointmentStatussId);

        modelBuilder.Entity<Doctor>()
                        .HasOne(a => a.Userr)
                        .WithMany(b => b.Doctor)
                        .HasForeignKey(a => a.UserId);


        modelBuilder.Entity<PetParent>()
                        .HasOne(a => a.Userr)
                        .WithMany(b => b.PetParent)
                        .HasForeignKey(a => a.UserId);

        modelBuilder.Entity<PetnPerson>()
                        .HasOne(a => a.Pet)
                        .WithMany(b => b.PetnPersonn)
                        .HasForeignKey(a => a.AnimalId);

        modelBuilder.Entity<PetnPerson>()
                        .HasOne(a => a.PetParent)
                        .WithMany(b => b.PetnPersonn)
                        .HasForeignKey(a => a.PetParentId);
        
        modelBuilder.Entity<NotUserAppointment>()
                        .HasOne(a => a.AppointmentStatus)
                        .WithMany(b => b.NotUserAppointment)
                        .HasForeignKey(c => c.AppointmentStatussId);
        
        modelBuilder.Entity<NotUserParent>()
                        .HasKey(a => a.NotUserParentId);
        
        modelBuilder.Entity<NotUserParentsPet>()
                        .HasKey(a => a.AnimalId);
        
        modelBuilder.Entity<NotUserParentnPet>()
                        .HasKey(a => a.NotUserParenPetId);
        
        modelBuilder.Entity<NotUserAppointment>()
                        .HasKey(a => a.AppointmentId);

        modelBuilder.Entity<NotUserParent>()
                            .HasOne(a => a.Address)
                            .WithOne(b => b.NotUserParent)
                            .HasForeignKey<NotUserParent>(a => a.AddressId);

        modelBuilder.Entity<Address>()
                            .HasOne(a => a.District)
                            .WithMany(b => b.Addresses)
                            .HasForeignKey(a => a.DistrictId);

        
        modelBuilder.Entity<PetParent>()
                            .HasOne(a => a.Address)
                            .WithOne(b => b.PetParent)
                            .HasForeignKey<PetParent>(a => a.AddressId);

        modelBuilder.Entity<City>()
                        .HasKey(a => a.CityId);
                        

        modelBuilder.Entity<District>()
                        .HasKey(a => a.DistrictId);

        modelBuilder.Entity<NotUserAppointment>()
                        .HasOne(a => a.NotUserParentnPet)
                        .WithMany(b => b.NotUserAppointments)
                        .HasForeignKey(a => a.NotUserParentnPersonId);

        modelBuilder.Entity<NotUserAppointment>()
                        .HasOne(a => a.PatientInformation)
                        .WithOne(b => b.NotUserAppointment)
                        .HasForeignKey<NotUserAppointment>(a => a.PatientInformationId);

        modelBuilder.Entity<Appointment>()
                        .HasOne(a => a.PatientInformation)
                        .WithOne(b => b.Appointment)
                        .HasForeignKey<Appointment>(a => a.PatientInformationId);

        // dummy data
        modelBuilder.Entity<Pet>().HasData(
            new Pet { AnimalId = 6, PetGenderId = 6, BreedId = 6, DOB = DateTime.Now, IsAdoptable = false, SpecieId = 6, Name = "Sif", AdoptInfoId = 6 },
            new Pet { AnimalId = 9, PetGenderId = 6, BreedId = 6, DOB = DateTime.Now, IsAdoptable = true, SpecieId = 6, Name = "Shelob", AdoptInfoId = 7 }
        );

        modelBuilder.Entity<PetGender>().HasData(
            new PetGender { PetGenderId = 6, GName = "Female" },
            new PetGender { PetGenderId = 9, GName = "Male (neutralized)" }
        );

        modelBuilder.Entity<Breed>().HasData(
            new Breed { BreedId = 6, BName = "Ragdoll" },
            new Breed { BreedId = 9, BName = "Appaloosa" }
        );

        modelBuilder.Entity<Specie>().HasData(
            new Specie { SpecieId = 6, SName = "Wolf" },
            new Specie { SpecieId = 9, SName = "Horse" }
        );

        modelBuilder.Entity<AdoptInfo>().HasData(
            new AdoptInfo { AdoptInfoId = 6, AdoptText = "So cuteeeeeeeeeeeeeee" },
            new AdoptInfo { AdoptInfoId = 7, AdoptText = "So cuteeeeeeeeeeeeeee2" }
        );

        modelBuilder.Entity<SchoolType>().HasData(
            new SchoolType { SchoolTypeId = 6, STName = "University" }
        );

        modelBuilder.Entity<School>().HasData(
            new School { SchoolId = 6, SchoolTypeId = 6, SName = "University of California, Davis" }
        );

        modelBuilder.Entity<Userr>().HasData(
            new Userr { UserrId = 6, Emaill = "artorias@gmail.com", Passwordd = "sif123456", RoleeId = 6 },
            new Userr { UserrId = 666, Emaill = "patches@gmail.com", Passwordd = "patches123456", RoleeId = 7 },
            new Userr { UserrId = 128, Emaill = "anastacia@gmail.com", Passwordd = "anastacia123456", RoleeId = 7 },
            new Userr { UserrId = 129, Emaill = "admin@gmail.com", Passwordd = "admin123456", RoleeId = 8 },
            new Userr { UserrId = 130, Emaill = "supervisor@gmail.com", Passwordd = "supervisor123456", RoleeId = 9 }
        );

        modelBuilder.Entity<Rolee>().HasData(
            new Rolee { RoleeId = 5, RName = "Candidate" },
            new Rolee { RoleeId = 6, RName = "PetParent" },
            new Rolee { RoleeId = 7, RName = "Doctor" },
            new Rolee { RoleeId = 8, RName = "Admin" },
            new Rolee { RoleeId = 9, RName = "Supervisor" }
        );

        modelBuilder.Entity<Doctor>().HasData(
            new Doctor { DoctorId = 6, FirstName = "Patches", MiddleName = null, LastName = "Whisper", BalanceId = 666, DOB = Convert.ToDateTime("1978/12/10"), PhoneNumber = "05434561275", UserId = 666, HumanGenderId = 66, DoctorTitleId = 6, PronounId = 6, AddressId = 7},
            new Doctor { DoctorId = 9, FirstName = "Anastacia", MiddleName = "Ciaran", LastName = "Catarina", BalanceId = 128, DOB = Convert.ToDateTime("1980/6/4"), PhoneNumber = "05341299154", UserId = 128, HumanGenderId = 128, DoctorTitleId = 6, PronounId = 9, AddressId = 12}
        );

        modelBuilder.Entity<PetParent>().HasData(
            new PetParent { UserId = 6, FirstName = "Artorias", MiddleName = "Solaire", LastName = "Astora", BalanceId = 6, DOB = Convert.ToDateTime("1999/6/8"), PetParentId = 6, HumanGenderId = 6, PronounId = 6, AddressId = 6, PhoneNumber = "058745683324"}
        );

        modelBuilder.Entity<Address>().HasData(
            new Address { AddressId = 6, AddressDetails = "Block 5, after Boo's shop", DistrictId = 34},
            new Address { AddressId = 7, AddressDetails = "Block 6, after Foo's shop", DistrictId = 40},
            new Address { AddressId = 9, AddressDetails = "Block 6, after Coo's shop", DistrictId = 30},
            new Address { AddressId = 12, AddressDetails = "Block 7, after Too's shop", DistrictId = 30}
        );

        modelBuilder.Entity<HumanGender>().HasData(
            new HumanGender { HumanGenderId = 6, GName = "Non-Binary" },
            new HumanGender { HumanGenderId = 66, GName = "Genderfluid" },
            new HumanGender { HumanGenderId = 128, GName = "Female" }
        );

        modelBuilder.Entity<DoctorSchool>().HasData(
            new DoctorSchool { DoctorId = 6, SchoolId = 6 }
        );

        modelBuilder.Entity<PetnPerson>().HasData(
            new PetnPerson { AnimalId = 6, PetParentId = 6, PetnPersonId = 6 }
        );

        modelBuilder.Entity<Balance>().HasData(
            new Balance { BalanceId = 6, PersonBalance = Convert.ToDecimal("150.55") },
            new Balance { BalanceId = 666, PersonBalance = Convert.ToDecimal("90.65") },
            new Balance { BalanceId = 128, PersonBalance = Convert.ToDecimal("128.25") }
        );

        modelBuilder.Entity<Appointment>().HasData(
            new Appointment { AppointmentId = 6, PetnPersonId = 6, DoctorId = 6, TimeCreated = DateTime.Now, AppointmentDate = DateTime.Now.AddDays(30), AppointmentStatussId = 6, PatientInformationId = 6}
        );

        modelBuilder.Entity<DoctorTitle>().HasData(
            new DoctorTitle { DoctorTitleId = 6, TFullForm = "Vetenerian", TShortForm = "DVM" }

        );

        modelBuilder.Entity<DoctorInformation>().HasData(
            new DoctorInformation { DoctorId = 6, DoctorInformationText = "Hi, I am Dr. Patches, a veterinarian with over 10 years of experience in the field. I received my Doctor of Veterinary Medicine degree from the University of California, Davis and have since worked at a variety of clinics, caring for all types of animals and their petparents. My specialty is in small animal medicine, but I am well-versed in treating all kinds of creatures, from cats and dogs to birds and reptiles. I am passionate about helping animals and their owners, and take pride in being able to diagnose and treat a wide range of conditions. In my free time, I enjoy volunteering at local animal shelters and spending time with my own pets, which include a rescue dog and two cats. I believe that effective communication with petparents is crucial in providing the best care for their beloved animals." },
            new DoctorInformation { DoctorId = 9, DoctorInformationText = "As a veterinarian, I am constantly learning and growing in my profession. I am passionate about providing the best care possible to my patients, and am dedicated to staying up-to-date on the latest advaances in veterinary medicine. I understand that pets are more than just animals to their parents - they are members of the family, and I treat each one with the same care and respect I would any other family member. I take the time to listen to my clients and understand their concerns, and work with them to develop a personalized treatment plan that meets the needs of both the animal and the parent. One of the things I enjoy most about being a veterinarian is the opportunity to build long-term relationships with my patients and their parents. I love seeing my patients grow and thrive under my care, and take great pride in being able to help them live happy and healthy lives." }
        );

        modelBuilder.Entity<Pronoun>().HasData(
            new Pronoun { ProunounId = 6, PName = "They/Them" },
            new Pronoun { ProunounId = 9, PName = "She/Her" }
        );

        modelBuilder.Entity<AppointmentStatus>().HasData(
            new AppointmentStatus { AppointmentStatussId = 6, Status = "Active Appointment" },
            new AppointmentStatus { AppointmentStatussId = 7, Status = "Expired Appointment" },
            new AppointmentStatus { AppointmentStatussId = 8, Status = "Canceled Appointment" },
            new AppointmentStatus { AppointmentStatussId = 10, Status = "Finished Appointment" }

        );

        modelBuilder.Entity<PatientInformation>().HasData(
            new PatientInformation { PatientInformationId = 6, EatingStatusId = 2, EnergyStatusId = 1, PeeingStatusId = 3, InformationAboutPatient = "My wolf Sif has been eating fine and her energy levels are good, but she has been having trouble with her peeing. She's been going more frequently and sometimes it seems like it's painful for her. I'm really concerned because she's usually such a healthy wolf.", IlnesssesInThePast = "Sif is a 3-year-old wolf who had a case of mange a year ago, which was treated with medicated baths and topical ointments. She also developed an ear infection a few months ago, which was treated with antibiotics and ear drops. In the past, Sif has also had some minor digestive issues that we've been able to resolve with diet and supplement changes."},
            new PatientInformation { PatientInformationId = 9, EatingStatusId = 2, EnergyStatusId = 2, PeeingStatusId = 2, InformationAboutPatient = "Hi there, I'm the owner of a horse named Torrent. He's been feeling a bit under the weather lately and has had some difficulty breathing and a persistent cough. I'm really worried about him and would like to get him checked out by a veterinarian as soon as possible.Could you please let me know if you have any availability to see Torrent in the next few days? I'm very concerned about his health and want to make sure he gets the care he needs.Thank you for your attention to this matter. I appreciate any help you can provide in getting Torrent back to good health.", IlnesssesInThePast = "orrent is a chestnut brown horse with a strong and majestic presence. However, a few months ago, he fell ill and experienced difficulty breathing and a persistent cough. The vet diagnosed him with a respiratory infection and prescribed medication and rest. Thankfully, Torrent made a full recovery and is now back to his old self."}
        );

        modelBuilder.Entity<StatusLevel>().HasData(
            new StatusLevel { StatusLevelId = 1, Name = "Good" },
            new StatusLevel { StatusLevelId = 2, Name = "Middle" },
            new StatusLevel { StatusLevelId = 3, Name = "Bad" }
        );


        modelBuilder.Entity<NotUserParent>().HasData(
            new NotUserParent { NotUserParentId = 9 ,FirstName = "Gael" , MiddleName = "Oscar", LastName = "Siegward", Email = "GaelSlv@hotmail.com", AddressId = 9, PhoneNumber = "05421238573"}
        );

        modelBuilder.Entity<NotUserParentsPet>().HasData(
            new NotUserParentsPet {Name = "Torrent", DOB = Convert.ToDateTime("2011-12-10"), AnimalId = 9, BreedId = 9, PetGenderId = 9, SpecieId = 9}
        );

        modelBuilder.Entity<NotUserParentnPet>().HasData(
            new NotUserParentnPet { AnimalId = 9, NotUserParenPetId = 9, NotUserParentId = 9}
        );

        modelBuilder.Entity<NotUserAppointment>().HasData(
            new NotUserAppointment { AppointmentId = 6 ,NotUserParentnPersonId = 9, DoctorId = 9, AppointmentStatussId = 8, AppointmentDate = DateTime.Now.AddDays(-10), TimeCreated = DateTime.Now.AddDays(-40), PatientInformationId = 9}
        );

        modelBuilder.Entity<City>().HasData(

                                                    new City { CityId = 1, CName = "Adana" },
                                                    new City { CityId = 2, CName = "Adıyaman" },
                                                    new City { CityId = 3, CName = "Afyonkarahisar" },
                                                    new City { CityId = 4, CName = "Ağrı" },
                                                    new City { CityId = 5, CName = "Amasya" },
                                                    new City { CityId = 6, CName = "Ankara" },
                                                    new City { CityId = 7, CName = "Antalya" },
                                                    new City { CityId = 8, CName = "Artvin" },
                                                    new City { CityId = 9, CName = "Aydın" },
                                                    new City { CityId = 10, CName = "Balıkesir" },
                                                    new City { CityId = 11, CName = "Bilecik" },
                                                    new City { CityId = 12, CName = "Bingöl" },
                                                    new City { CityId = 13, CName = "Bitlis" },
                                                    new City { CityId = 14, CName = "Bolu" },
                                                    new City { CityId = 15, CName = "Burdur" },
                                                    new City { CityId = 16, CName = "Bursa" },
                                                    new City { CityId = 17, CName = "Çanakkale" },
                                                    new City { CityId = 18, CName = "Çankırı" },
                                                    new City { CityId = 19, CName = "Çorum" },
                                                    new City { CityId = 20, CName = "Denizli" },
                                                    new City { CityId = 21, CName = "Diyarbakır" },
                                                    new City { CityId = 22, CName = "Edirne" },
                                                    new City { CityId = 23, CName = "Elazığ" },
                                                    new City { CityId = 24, CName = "Erzincan" },
                                                    new City { CityId = 25, CName = "Erzurum" },
                                                    new City { CityId = 26, CName = "Eskişehir" },
                                                    new City { CityId = 27, CName = "Gaziantep" },
                                                    new City { CityId = 28, CName = "Giresun" },
                                                    new City { CityId = 29, CName = "Gümüşhane" },
                                                    new City { CityId = 30, CName = "Hakkari" },
                                                    new City { CityId = 31, CName = "Hatay" },
                                                    new City { CityId = 32, CName = "Isparta" },
                                                    new City { CityId = 33, CName = "Mersin" },
                                                    new City { CityId = 34, CName = "İstanbul" },
                                                    new City { CityId = 35, CName = "İzmir" },
                                                    new City { CityId = 36, CName = "Kars" },
                                                    new City { CityId = 37, CName = "Kastamonu" },
                                                    new City { CityId = 38, CName = "Kayseri" },
                                                    new City { CityId = 39, CName = "Kırklareli" },
                                                    new City { CityId = 40, CName = "Kırşehir" },
                                                    new City { CityId = 41, CName = "Kocaeli" },
                                                    new City { CityId = 42, CName = "Konya" },
                                                    new City { CityId = 43, CName = "Kütahya" },
                                                    new City { CityId = 44, CName = "Malatya" },
                                                    new City { CityId = 45, CName = "Manisa" },
                                                    new City { CityId = 46, CName = "Kahramanmaraş" },
                                                    new City { CityId = 47, CName = "Mardin" },
                                                    new City { CityId = 48, CName = "Muğla" },
                                                    new City { CityId = 49, CName = "Muş" },
                                                    new City { CityId = 50, CName = "Nevşehir" },
                                                    new City { CityId = 51, CName = "Niğde" },
                                                    new City { CityId = 52, CName = "Ordu" },
                                                    new City { CityId = 53, CName = "Rize" },
                                                    new City { CityId = 54, CName = "Sakarya" },
                                                    new City { CityId = 55, CName = "Samsun" },
                                                    new City { CityId = 56, CName = "Siirt" },
                                                    new City { CityId = 57, CName = "Sinop" },
                                                    new City { CityId = 58, CName = "Sivas" },
                                                    new City { CityId = 59, CName = "Tekirdağ" },
                                                    new City { CityId = 60, CName = "Tokat" },
                                                    new City { CityId = 61, CName = "Trabzon" },
                                                    new City { CityId = 62, CName = "Tunceli" },
                                                    new City { CityId = 63, CName = "Şanlıurfa" },
                                                    new City { CityId = 64, CName = "Uşak" },
                                                    new City { CityId = 65, CName = "Van" },
                                                    new City { CityId = 66, CName = "Yozgat" },
                                                    new City { CityId = 67, CName = "Zonguldak" },
                                                    new City { CityId = 68, CName = "Aksaray" },
                                                    new City { CityId = 69, CName = "Bayburt" },
                                                    new City { CityId = 70, CName = "Karaman" },
                                                    new City { CityId = 71, CName = "Kırıkkale" },
                                                    new City { CityId = 72, CName = "Batman" },
                                                    new City { CityId = 73, CName = "Şırnak" },
                                                    new City { CityId = 74, CName = "Bartın" },
                                                    new City { CityId = 75, CName = "Ardahan" },
                                                    new City { CityId = 76, CName = "Iğdır" },
                                                    new City { CityId = 77, CName = "Yalova" },
                                                    new City { CityId = 78, CName = "Karabük" },
                                                    new City { CityId = 79, CName = "Kilis" },
                                                    new City { CityId = 80, CName = "Osmaniye" },
                                                    new City { CityId = 81, CName = "Düzce" }

                                        );

        modelBuilder.Entity<District>().HasData(

                                                new District { DistrictId = 1, DName = "Seyhan", CityId = 1 },
                                                new District { DistrictId = 2, DName = "Ceyhan", CityId = 1 },
                                                new District { DistrictId = 3, DName = "Feke", CityId = 1 },
                                                new District { DistrictId = 4, DName = "Karaisalı", CityId = 1 },
                                                new District { DistrictId = 5, DName = "Karataş", CityId = 1 },
                                                new District { DistrictId = 6, DName = "Kozan", CityId = 1 },
                                                new District { DistrictId = 7, DName = "Pozantı", CityId = 1 },
                                                new District { DistrictId = 8, DName = "Saimbeyli", CityId = 1 },
                                                new District { DistrictId = 9, DName = "Tufanbeyli", CityId = 1 },
                                                new District { DistrictId = 10, DName = "Yumurtalık", CityId = 1 },
                                                new District { DistrictId = 11, DName = "Yüreğir", CityId = 1 },
                                                new District { DistrictId = 12, DName = "Aladağ", CityId = 1 },
                                                new District { DistrictId = 13, DName = "İmamoğlu", CityId = 1 },
                                                new District { DistrictId = 14, DName = "Sarıçam", CityId = 1 },
                                                new District { DistrictId = 15, DName = "Çukurova", CityId = 1 },
                                                new District { DistrictId = 16, DName = "Adıyaman Merkez", CityId = 2 },
                                                new District { DistrictId = 17, DName = "Besni", CityId = 2 },
                                                new District { DistrictId = 18, DName = "Çelikhan", CityId = 2 },
                                                new District { DistrictId = 19, DName = "Gerger", CityId = 2 },
                                                new District { DistrictId = 20, DName = "Gölbaşı / Adıyaman", CityId = 2 },
                                                new District { DistrictId = 21, DName = "Kahta", CityId = 2 },
                                                new District { DistrictId = 22, DName = "Samsat", CityId = 2 },
                                                new District { DistrictId = 23, DName = "Sincik", CityId = 2 },
                                                new District { DistrictId = 24, DName = "Tut", CityId = 2 },
                                                new District { DistrictId = 25, DName = "Afyonkarahisar Merkez", CityId = 3 },
                                                new District { DistrictId = 26, DName = "Bolvadin", CityId = 3 },
                                                new District { DistrictId = 27, DName = "Çay", CityId = 3 },
                                                new District { DistrictId = 28, DName = "Dazkırı", CityId = 3 },
                                                new District { DistrictId = 29, DName = "Dinar", CityId = 3 },
                                                new District { DistrictId = 30, DName = "Emirdağ", CityId = 3 },
                                                new District { DistrictId = 31, DName = "İhsaniye", CityId = 3 },
                                                new District { DistrictId = 32, DName = "Sandıklı", CityId = 3 },
                                                new District { DistrictId = 33, DName = "Sinanpaşa", CityId = 3 },
                                                new District { DistrictId = 34, DName = "Sultandağı", CityId = 3 },
                                                new District { DistrictId = 35, DName = "Şuhut", CityId = 3 },
                                                new District { DistrictId = 36, DName = "Başmakçı", CityId = 3 },
                                                new District { DistrictId = 37, DName = "Bayat / Afyonkarahisar", CityId = 3 },
                                                new District { DistrictId = 38, DName = "İscehisar", CityId = 3 },
                                                new District { DistrictId = 39, DName = "Çobanlar", CityId = 3 },
                                                new District { DistrictId = 40, DName = "Evciler", CityId = 3 },
                                                new District { DistrictId = 41, DName = "Hocalar", CityId = 3 },
                                                new District { DistrictId = 42, DName = "Kızılören", CityId = 3 },
                                                new District { DistrictId = 43, DName = "Ağrı Merkez", CityId = 4 },
                                                new District { DistrictId = 44, DName = "Diyadin", CityId = 4 },
                                                new District { DistrictId = 45, DName = "Doğubayazıt", CityId = 4 },
                                                new District { DistrictId = 46, DName = "Eleşkirt", CityId = 4 },
                                                new District { DistrictId = 47, DName = "Hamur", CityId = 4 },
                                                new District { DistrictId = 48, DName = "Patnos", CityId = 4 },
                                                new District { DistrictId = 49, DName = "Taşlıçay", CityId = 4 },
                                                new District { DistrictId = 50, DName = "Tutak", CityId = 4 },
                                                new District { DistrictId = 51, DName = "Amasya Merkez", CityId = 5 },
                                                new District { DistrictId = 52, DName = "Göynücek", CityId = 5 },
                                                new District { DistrictId = 53, DName = "Gümüşhacıköy", CityId = 5 },
                                                new District { DistrictId = 54, DName = "Merzifon", CityId = 5 },
                                                new District { DistrictId = 55, DName = "Suluova", CityId = 5 },
                                                new District { DistrictId = 56, DName = "Taşova", CityId = 5 },
                                                new District { DistrictId = 57, DName = "Hamamözü", CityId = 5 },
                                                new District { DistrictId = 58, DName = "Altındağ", CityId = 6 },
                                                new District { DistrictId = 59, DName = "Ayaş", CityId = 6 },
                                                new District { DistrictId = 60, DName = "Bala", CityId = 6 },
                                                new District { DistrictId = 61, DName = "Beypazarı", CityId = 6 },
                                                new District { DistrictId = 62, DName = "Çamlıdere", CityId = 6 },
                                                new District { DistrictId = 63, DName = "Çankaya", CityId = 6 },
                                                new District { DistrictId = 64, DName = "Çubuk", CityId = 6 },
                                                new District { DistrictId = 65, DName = "Elmadağ", CityId = 6 },
                                                new District { DistrictId = 66, DName = "Güdül", CityId = 6 },
                                                new District { DistrictId = 67, DName = "Haymana", CityId = 6 },
                                                new District { DistrictId = 68, DName = "Kalecik", CityId = 6 },
                                                new District { DistrictId = 69, DName = "Kızılcahamam", CityId = 6 },
                                                new District { DistrictId = 70, DName = "Nallıhan", CityId = 6 },
                                                new District { DistrictId = 71, DName = "Polatlı", CityId = 6 },
                                                new District { DistrictId = 72, DName = "Şereflikoçhisar", CityId = 6 },
                                                new District { DistrictId = 73, DName = "Yenimahalle", CityId = 6 },
                                                new District { DistrictId = 74, DName = "Gölbaşı / Ankara", CityId = 6 },
                                                new District { DistrictId = 75, DName = "Keçiören", CityId = 6 },
                                                new District { DistrictId = 76, DName = "Mamak", CityId = 6 },
                                                new District { DistrictId = 77, DName = "Sincan", CityId = 6 },
                                                new District { DistrictId = 78, DName = "Kazan", CityId = 6 },
                                                new District { DistrictId = 79, DName = "Akyurt", CityId = 6 },
                                                new District { DistrictId = 80, DName = "Etimesgut", CityId = 6 },
                                                new District { DistrictId = 81, DName = "Evren", CityId = 6 },
                                                new District { DistrictId = 82, DName = "Pursaklar", CityId = 6 },
                                                new District { DistrictId = 83, DName = "Akseki", CityId = 7 },
                                                new District { DistrictId = 84, DName = "Alanya", CityId = 7 },
                                                new District { DistrictId = 85, DName = "Elmalı", CityId = 7 },
                                                new District { DistrictId = 86, DName = "Finike", CityId = 7 },
                                                new District { DistrictId = 87, DName = "Gazipaşa", CityId = 7 },
                                                new District { DistrictId = 88, DName = "Gündoğmuş", CityId = 7 },
                                                new District { DistrictId = 89, DName = "Kaş", CityId = 7 },
                                                new District { DistrictId = 90, DName = "Korkuteli", CityId = 7 },
                                                new District { DistrictId = 91, DName = "Kumluca", CityId = 7 },
                                                new District { DistrictId = 92, DName = "Manavgat", CityId = 7 },
                                                new District { DistrictId = 93, DName = "Serik", CityId = 7 },
                                                new District { DistrictId = 94, DName = "Demre", CityId = 7 },
                                                new District { DistrictId = 95, DName = "İbradı", CityId = 7 },
                                                new District { DistrictId = 96, DName = "Kemer / Antalya", CityId = 7 },
                                                new District { DistrictId = 97, DName = "Aksu / Antalya", CityId = 7 },
                                                new District { DistrictId = 98, DName = "Döşemealtı", CityId = 7 },
                                                new District { DistrictId = 99, DName = "Kepez", CityId = 7 },
                                                new District { DistrictId = 100, DName = "Konyaaltı", CityId = 7 },
                                                new District { DistrictId = 101, DName = "Muratpaşa", CityId = 7 },
                                                new District { DistrictId = 102, DName = "Ardanuç", CityId = 8 },
                                                new District { DistrictId = 103, DName = "Arhavi", CityId = 8 },
                                                new District { DistrictId = 104, DName = "Artvin Merkez", CityId = 8 },
                                                new District { DistrictId = 105, DName = "Borçka", CityId = 8 },
                                                new District { DistrictId = 106, DName = "Hopa", CityId = 8 },
                                                new District { DistrictId = 107, DName = "Şavşat", CityId = 8 },
                                                new District { DistrictId = 108, DName = "Yusufeli", CityId = 8 },
                                                new District { DistrictId = 109, DName = "Murgul", CityId = 8 },
                                                new District { DistrictId = 110, DName = "Bozdoğan", CityId = 9 },
                                                new District { DistrictId = 111, DName = "Çine", CityId = 9 },
                                                new District { DistrictId = 112, DName = "Germencik", CityId = 9 },
                                                new District { DistrictId = 113, DName = "Karacasu", CityId = 9 },
                                                new District { DistrictId = 114, DName = "Koçarlı", CityId = 9 },
                                                new District { DistrictId = 115, DName = "Kuşadası", CityId = 9 },
                                                new District { DistrictId = 116, DName = "Kuyucak", CityId = 9 },
                                                new District { DistrictId = 117, DName = "Nazilli", CityId = 9 },
                                                new District { DistrictId = 118, DName = "Söke", CityId = 9 },
                                                new District { DistrictId = 119, DName = "Sultanhisar", CityId = 9 },
                                                new District { DistrictId = 120, DName = "Yenipazar / Aydın", CityId = 9 },
                                                new District { DistrictId = 121, DName = "Buharkent", CityId = 9 },
                                                new District { DistrictId = 122, DName = "İncirliova", CityId = 9 },
                                                new District { DistrictId = 123, DName = "Karpuzlu", CityId = 9 },
                                                new District { DistrictId = 124, DName = "Köşk", CityId = 9 },
                                                new District { DistrictId = 125, DName = "Didim", CityId = 9 },
                                                new District { DistrictId = 126, DName = "Efeler", CityId = 9 },
                                                new District { DistrictId = 127, DName = "Ayvalık", CityId = 10 },
                                                new District { DistrictId = 128, DName = "Balya", CityId = 10 },
                                                new District { DistrictId = 129, DName = "Bandırma", CityId = 10 },
                                                new District { DistrictId = 130, DName = "Bigadiç", CityId = 10 },
                                                new District { DistrictId = 131, DName = "Burhaniye", CityId = 10 },
                                                new District { DistrictId = 132, DName = "Dursunbey", CityId = 10 },
                                                new District { DistrictId = 133, DName = "Edremit / Balıkesir", CityId = 10 },
                                                new District { DistrictId = 134, DName = "Erdek", CityId = 10 },
                                                new District { DistrictId = 135, DName = "Gönen / Balıkesir", CityId = 10 },
                                                new District { DistrictId = 136, DName = "Havran", CityId = 10 },
                                                new District { DistrictId = 137, DName = "İvrindi", CityId = 10 },
                                                new District { DistrictId = 138, DName = "Kepsut", CityId = 10 },
                                                new District { DistrictId = 139, DName = "Manyas", CityId = 10 },
                                                new District { DistrictId = 140, DName = "Savaştepe", CityId = 10 },
                                                new District { DistrictId = 141, DName = "Sındırgı", CityId = 10 },
                                                new District { DistrictId = 142, DName = "Susurluk", CityId = 10 },
                                                new District { DistrictId = 143, DName = "Marmara", CityId = 10 },
                                                new District { DistrictId = 144, DName = "Gömeç", CityId = 10 },
                                                new District { DistrictId = 145, DName = "Altıeylül", CityId = 10 },
                                                new District { DistrictId = 146, DName = "Karesi", CityId = 10 },
                                                new District { DistrictId = 147, DName = "Bilecik Merkez", CityId = 11 },
                                                new District { DistrictId = 148, DName = "Bozüyük", CityId = 11 },
                                                new District { DistrictId = 149, DName = "Gölpazarı", CityId = 11 },
                                                new District { DistrictId = 150, DName = "Osmaneli", CityId = 11 },
                                                new District { DistrictId = 151, DName = "Pazaryeri", CityId = 11 },
                                                new District { DistrictId = 152, DName = "Söğüt", CityId = 11 },
                                                new District { DistrictId = 153, DName = "Yenipazar / Bilecik", CityId = 11 },
                                                new District { DistrictId = 154, DName = "İnhisar", CityId = 11 },
                                                new District { DistrictId = 155, DName = "Bingöl Merkez", CityId = 12 },
                                                new District { DistrictId = 156, DName = "Genç", CityId = 12 },
                                                new District { DistrictId = 157, DName = "Karlıova", CityId = 12 },
                                                new District { DistrictId = 158, DName = "Kiğı", CityId = 12 },
                                                new District { DistrictId = 159, DName = "Solhan", CityId = 12 },
                                                new District { DistrictId = 160, DName = "Adaklı", CityId = 12 },
                                                new District { DistrictId = 161, DName = "Yayladere", CityId = 12 },
                                                new District { DistrictId = 162, DName = "Yedisu", CityId = 12 },
                                                new District { DistrictId = 163, DName = "Adilcevaz", CityId = 13 },
                                                new District { DistrictId = 164, DName = "Ahlat", CityId = 13 },
                                                new District { DistrictId = 165, DName = "Bitlis Merkez", CityId = 13 },
                                                new District { DistrictId = 166, DName = "Hizan", CityId = 13 },
                                                new District { DistrictId = 167, DName = "Mutki", CityId = 13 },
                                                new District { DistrictId = 168, DName = "Tatvan", CityId = 13 },
                                                new District { DistrictId = 169, DName = "Güroymak", CityId = 13 },
                                                new District { DistrictId = 170, DName = "Bolu Merkez", CityId = 14 },
                                                new District { DistrictId = 171, DName = "Gerede", CityId = 14 },
                                                new District { DistrictId = 172, DName = "Göynük", CityId = 14 },
                                                new District { DistrictId = 173, DName = "Kıbrıscık", CityId = 14 },
                                                new District { DistrictId = 174, DName = "Mengen", CityId = 14 },
                                                new District { DistrictId = 175, DName = "Mudurnu", CityId = 14 },
                                                new District { DistrictId = 176, DName = "Seben", CityId = 14 },
                                                new District { DistrictId = 177, DName = "Dörtdivan", CityId = 14 },
                                                new District { DistrictId = 178, DName = "Yeniçağa", CityId = 14 },
                                                new District { DistrictId = 179, DName = "Ağlasun", CityId = 15 },
                                                new District { DistrictId = 180, DName = "Bucak", CityId = 15 },
                                                new District { DistrictId = 181, DName = "Burdur Merkez", CityId = 15 },
                                                new District { DistrictId = 182, DName = "Gölhisar", CityId = 15 },
                                                new District { DistrictId = 183, DName = "Tefenni", CityId = 15 },
                                                new District { DistrictId = 184, DName = "Yeşilova", CityId = 15 },
                                                new District { DistrictId = 185, DName = "Karamanlı", CityId = 15 },
                                                new District { DistrictId = 186, DName = "Kemer / Burdur", CityId = 15 },
                                                new District { DistrictId = 187, DName = "Altınyayla / Burdur", CityId = 15 },
                                                new District { DistrictId = 188, DName = "Çavdır", CityId = 15 },
                                                new District { DistrictId = 189, DName = "Çeltikçi", CityId = 15 },
                                                new District { DistrictId = 190, DName = "Gemlik", CityId = 16 },
                                                new District { DistrictId = 191, DName = "İnegöl", CityId = 16 },
                                                new District { DistrictId = 192, DName = "İznik", CityId = 16 },
                                                new District { DistrictId = 193, DName = "Karacabey", CityId = 16 },
                                                new District { DistrictId = 194, DName = "Keles", CityId = 16 },
                                                new District { DistrictId = 195, DName = "Mudanya", CityId = 16 },
                                                new District { DistrictId = 196, DName = "Mustafakemalpaşa", CityId = 16 },
                                                new District { DistrictId = 197, DName = "Orhaneli", CityId = 16 },
                                                new District { DistrictId = 198, DName = "Orhangazi", CityId = 16 },
                                                new District { DistrictId = 199, DName = "Yenişehir / Bursa", CityId = 16 },
                                                new District { DistrictId = 200, DName = "Büyükorhan", CityId = 16 },
                                                new District { DistrictId = 201, DName = "Harmancık", CityId = 16 },
                                                new District { DistrictId = 202, DName = "Nilüfer", CityId = 16 },
                                                new District { DistrictId = 203, DName = "Osmangazi", CityId = 16 },
                                                new District { DistrictId = 204, DName = "Yıldırım", CityId = 16 },
                                                new District { DistrictId = 205, DName = "Gürsu", CityId = 16 },
                                                new District { DistrictId = 206, DName = "Kestel", CityId = 16 },
                                                new District { DistrictId = 207, DName = "Ayvacık / Çanakkale", CityId = 17 },
                                                new District { DistrictId = 208, DName = "Bayramiç", CityId = 17 },
                                                new District { DistrictId = 209, DName = "Biga", CityId = 17 },
                                                new District { DistrictId = 210, DName = "Bozcaada", CityId = 17 },
                                                new District { DistrictId = 211, DName = "Çan", CityId = 17 },
                                                new District { DistrictId = 212, DName = "Çanakkale Merkez", CityId = 17 },
                                                new District { DistrictId = 213, DName = "Eceabat", CityId = 17 },
                                                new District { DistrictId = 214, DName = "Ezine", CityId = 17 },
                                                new District { DistrictId = 215, DName = "Gelibolu", CityId = 17 },
                                                new District { DistrictId = 216, DName = "Gökçeada", CityId = 17 },
                                                new District { DistrictId = 217, DName = "Lapseki", CityId = 17 },
                                                new District { DistrictId = 218, DName = "Yenice / Çanakkale", CityId = 17 },
                                                new District { DistrictId = 219, DName = "Çankırı Merkez", CityId = 18 },
                                                new District { DistrictId = 220, DName = "Çerkeş", CityId = 18 },
                                                new District { DistrictId = 221, DName = "Eldivan", CityId = 18 },
                                                new District { DistrictId = 222, DName = "Ilgaz", CityId = 18 },
                                                new District { DistrictId = 223, DName = "Kurşunlu", CityId = 18 },
                                                new District { DistrictId = 224, DName = "Orta", CityId = 18 },
                                                new District { DistrictId = 225, DName = "Şabanözü", CityId = 18 },
                                                new District { DistrictId = 226, DName = "Yapraklı", CityId = 18 },
                                                new District { DistrictId = 227, DName = "Atkaracalar", CityId = 18 },
                                                new District { DistrictId = 228, DName = "Kızılırmak", CityId = 18 },
                                                new District { DistrictId = 229, DName = "Bayramören", CityId = 18 },
                                                new District { DistrictId = 230, DName = "Korgun", CityId = 18 },
                                                new District { DistrictId = 231, DName = "Alaca", CityId = 19 },
                                                new District { DistrictId = 232, DName = "Bayat / Çorum", CityId = 19 },
                                                new District { DistrictId = 233, DName = "Çorum Merkez", CityId = 19 },
                                                new District { DistrictId = 234, DName = "İskilip", CityId = 19 },
                                                new District { DistrictId = 235, DName = "Kargı", CityId = 19 },
                                                new District { DistrictId = 236, DName = "Mecitözü", CityId = 19 },
                                                new District { DistrictId = 237, DName = "Ortaköy / Çorum", CityId = 19 },
                                                new District { DistrictId = 238, DName = "Osmancık", CityId = 19 },
                                                new District { DistrictId = 239, DName = "Sungurlu", CityId = 19 },
                                                new District { DistrictId = 240, DName = "Boğazkale", CityId = 19 },
                                                new District { DistrictId = 241, DName = "Uğurludağ", CityId = 19 },
                                                new District { DistrictId = 242, DName = "Dodurga", CityId = 19 },
                                                new District { DistrictId = 243, DName = "Laçin", CityId = 19 },
                                                new District { DistrictId = 244, DName = "Oğuzlar", CityId = 19 },
                                                new District { DistrictId = 245, DName = "Acıpayam", CityId = 20 },
                                                new District { DistrictId = 246, DName = "Buldan", CityId = 20 },
                                                new District { DistrictId = 247, DName = "Çal", CityId = 20 },
                                                new District { DistrictId = 248, DName = "Çameli", CityId = 20 },
                                                new District { DistrictId = 249, DName = "Çardak", CityId = 20 },
                                                new District { DistrictId = 250, DName = "Çivril", CityId = 20 },
                                                new District { DistrictId = 251, DName = "Güney", CityId = 20 },
                                                new District { DistrictId = 252, DName = "Kale / Denizli", CityId = 20 },
                                                new District { DistrictId = 253, DName = "Sarayköy", CityId = 20 },
                                                new District { DistrictId = 254, DName = "Tavas", CityId = 20 },
                                                new District { DistrictId = 255, DName = "Babadağ", CityId = 20 },
                                                new District { DistrictId = 256, DName = "Bekilli", CityId = 20 },
                                                new District { DistrictId = 257, DName = "Honaz", CityId = 20 },
                                                new District { DistrictId = 258, DName = "Serinhisar", CityId = 20 },
                                                new District { DistrictId = 259, DName = "Pamukkale", CityId = 20 },
                                                new District { DistrictId = 260, DName = "Baklan", CityId = 20 },
                                                new District { DistrictId = 261, DName = "Beyağaç", CityId = 20 },
                                                new District { DistrictId = 262, DName = "Bozkurt / Denizli", CityId = 20 },
                                                new District { DistrictId = 263, DName = "Merkezefendi", CityId = 20 },
                                                new District { DistrictId = 264, DName = "Bismil", CityId = 21 },
                                                new District { DistrictId = 265, DName = "Çermik", CityId = 21 },
                                                new District { DistrictId = 266, DName = "Çınar", CityId = 21 },
                                                new District { DistrictId = 267, DName = "Çüngüş", CityId = 21 },
                                                new District { DistrictId = 268, DName = "Dicle", CityId = 21 },
                                                new District { DistrictId = 269, DName = "Ergani", CityId = 21 },
                                                new District { DistrictId = 270, DName = "Hani", CityId = 21 },
                                                new District { DistrictId = 271, DName = "Hazro", CityId = 21 },
                                                new District { DistrictId = 272, DName = "Kulp", CityId = 21 },
                                                new District { DistrictId = 273, DName = "Lice", CityId = 21 },
                                                new District { DistrictId = 274, DName = "Silvan", CityId = 21 },
                                                new District { DistrictId = 275, DName = "Eğil", CityId = 21 },
                                                new District { DistrictId = 276, DName = "Kocaköy", CityId = 21 },
                                                new District { DistrictId = 277, DName = "Bağlar", CityId = 21 },
                                                new District { DistrictId = 278, DName = "Kayapınar", CityId = 21 },
                                                new District { DistrictId = 279, DName = "Sur", CityId = 21 },
                                                new District { DistrictId = 280, DName = "Yenişehir / Diyarbakır", CityId = 21 },
                                                new District { DistrictId = 281, DName = "Edirne Merkez", CityId = 22 },
                                                new District { DistrictId = 282, DName = "Enez", CityId = 22 },
                                                new District { DistrictId = 283, DName = "Havsa", CityId = 22 },
                                                new District { DistrictId = 284, DName = "İpsala", CityId = 22 },
                                                new District { DistrictId = 285, DName = "Keşan", CityId = 22 },
                                                new District { DistrictId = 286, DName = "Lalapaşa", CityId = 22 },
                                                new District { DistrictId = 287, DName = "Meriç", CityId = 22 },
                                                new District { DistrictId = 288, DName = "Uzunköprü", CityId = 22 },
                                                new District { DistrictId = 289, DName = "Süloğlu", CityId = 22 },
                                                new District { DistrictId = 290, DName = "Ağın", CityId = 23 },
                                                new District { DistrictId = 291, DName = "Baskil", CityId = 23 },
                                                new District { DistrictId = 292, DName = "Elazığ Merkez", CityId = 23 },
                                                new District { DistrictId = 293, DName = "Karakoçan", CityId = 23 },
                                                new District { DistrictId = 294, DName = "Keban", CityId = 23 },
                                                new District { DistrictId = 295, DName = "Maden", CityId = 23 },
                                                new District { DistrictId = 296, DName = "Palu", CityId = 23 },
                                                new District { DistrictId = 297, DName = "Sivrice", CityId = 23 },
                                                new District { DistrictId = 298, DName = "Arıcak", CityId = 23 },
                                                new District { DistrictId = 299, DName = "Kovancılar", CityId = 23 },
                                                new District { DistrictId = 300, DName = "Alacakaya", CityId = 23 },
                                                new District { DistrictId = 301, DName = "Çayırlı", CityId = 24 },
                                                new District { DistrictId = 302, DName = "Erzincan Merkez", CityId = 24 },
                                                new District { DistrictId = 303, DName = "İliç", CityId = 24 },
                                                new District { DistrictId = 304, DName = "Kemah", CityId = 24 },
                                                new District { DistrictId = 305, DName = "Kemaliye", CityId = 24 },
                                                new District { DistrictId = 306, DName = "Refahiye", CityId = 24 },
                                                new District { DistrictId = 307, DName = "Tercan", CityId = 24 },
                                                new District { DistrictId = 308, DName = "Üzümlü", CityId = 24 },
                                                new District { DistrictId = 309, DName = "Otlukbeli", CityId = 24 },
                                                new District { DistrictId = 310, DName = "Aşkale", CityId = 25 },
                                                new District { DistrictId = 311, DName = "Çat", CityId = 25 },
                                                new District { DistrictId = 312, DName = "Hınıs", CityId = 25 },
                                                new District { DistrictId = 313, DName = "Horasan", CityId = 25 },
                                                new District { DistrictId = 314, DName = "İspir", CityId = 25 },
                                                new District { DistrictId = 315, DName = "Karayazı", CityId = 25 },
                                                new District { DistrictId = 316, DName = "Narman", CityId = 25 },
                                                new District { DistrictId = 317, DName = "Oltu", CityId = 25 },
                                                new District { DistrictId = 318, DName = "Olur", CityId = 25 },
                                                new District { DistrictId = 319, DName = "Pasinler", CityId = 25 },
                                                new District { DistrictId = 320, DName = "Şenkaya", CityId = 25 },
                                                new District { DistrictId = 321, DName = "Tekman", CityId = 25 },
                                                new District { DistrictId = 322, DName = "Tortum", CityId = 25 },
                                                new District { DistrictId = 323, DName = "Karaçoban", CityId = 25 },
                                                new District { DistrictId = 324, DName = "Uzundere", CityId = 25 },
                                                new District { DistrictId = 325, DName = "Pazaryolu", CityId = 25 },
                                                new District { DistrictId = 326, DName = "Aziziye", CityId = 25 },
                                                new District { DistrictId = 327, DName = "Köprüköy", CityId = 25 },
                                                new District { DistrictId = 328, DName = "Palandöken", CityId = 25 },
                                                new District { DistrictId = 329, DName = "Yakutiye", CityId = 25 },
                                                new District { DistrictId = 330, DName = "Çifteler", CityId = 26 },
                                                new District { DistrictId = 331, DName = "Mahmudiye", CityId = 26 },
                                                new District { DistrictId = 332, DName = "Mihalıççık", CityId = 26 },
                                                new District { DistrictId = 333, DName = "Sarıcakaya", CityId = 26 },
                                                new District { DistrictId = 334, DName = "Seyitgazi", CityId = 26 },
                                                new District { DistrictId = 335, DName = "Sivrihisar", CityId = 26 },
                                                new District { DistrictId = 336, DName = "Alpu", CityId = 26 },
                                                new District { DistrictId = 337, DName = "Beylikova", CityId = 26 },
                                                new District { DistrictId = 338, DName = "İnönü", CityId = 26 },
                                                new District { DistrictId = 339, DName = "Günyüzü", CityId = 26 },
                                                new District { DistrictId = 340, DName = "Han", CityId = 26 },
                                                new District { DistrictId = 341, DName = "Mihalgazi", CityId = 26 },
                                                new District { DistrictId = 342, DName = "Odunpazarı", CityId = 26 },
                                                new District { DistrictId = 343, DName = "Tepebaşı", CityId = 26 },
                                                new District { DistrictId = 344, DName = "Araban", CityId = 27 },
                                                new District { DistrictId = 345, DName = "İslahiye", CityId = 27 },
                                                new District { DistrictId = 346, DName = "Nizip", CityId = 27 },
                                                new District { DistrictId = 347, DName = "Oğuzeli", CityId = 27 },
                                                new District { DistrictId = 348, DName = "Yavuzeli", CityId = 27 },
                                                new District { DistrictId = 349, DName = "Şahinbey", CityId = 27 },
                                                new District { DistrictId = 350, DName = "Şehitkamil", CityId = 27 },
                                                new District { DistrictId = 351, DName = "Karkamış", CityId = 27 },
                                                new District { DistrictId = 352, DName = "Nurdağı", CityId = 27 },
                                                new District { DistrictId = 353, DName = "Alucra", CityId = 28 },
                                                new District { DistrictId = 354, DName = "Bulancak", CityId = 28 },
                                                new District { DistrictId = 355, DName = "Dereli", CityId = 28 },
                                                new District { DistrictId = 356, DName = "Espiye", CityId = 28 },
                                                new District { DistrictId = 357, DName = "Eynesil", CityId = 28 },
                                                new District { DistrictId = 358, DName = "Giresun Merkez", CityId = 28 },
                                                new District { DistrictId = 359, DName = "Görele", CityId = 28 },
                                                new District { DistrictId = 360, DName = "Keşap", CityId = 28 },
                                                new District { DistrictId = 361, DName = "Şebinkarahisar", CityId = 28 },
                                                new District { DistrictId = 362, DName = "Tirebolu", CityId = 28 },
                                                new District { DistrictId = 363, DName = "Piraziz", CityId = 28 },
                                                new District { DistrictId = 364, DName = "Yağlıdere", CityId = 28 },
                                                new District { DistrictId = 365, DName = "Çamoluk", CityId = 28 },
                                                new District { DistrictId = 366, DName = "Çanakçı", CityId = 28 },
                                                new District { DistrictId = 367, DName = "Doğankent", CityId = 28 },
                                                new District { DistrictId = 368, DName = "Güce", CityId = 28 },
                                                new District { DistrictId = 369, DName = "Gümüşhane Merkez", CityId = 29 },
                                                new District { DistrictId = 370, DName = "Kelkit", CityId = 29 },
                                                new District { DistrictId = 371, DName = "Şiran", CityId = 29 },
                                                new District { DistrictId = 372, DName = "Torul", CityId = 29 },
                                                new District { DistrictId = 373, DName = "Köse", CityId = 29 },
                                                new District { DistrictId = 374, DName = "Kürtün", CityId = 29 },
                                                new District { DistrictId = 375, DName = "Çukurca", CityId = 30 },
                                                new District { DistrictId = 376, DName = "Hakkari Merkez", CityId = 30 },
                                                new District { DistrictId = 377, DName = "Şemdinli", CityId = 30 },
                                                new District { DistrictId = 378, DName = "Yüksekova", CityId = 30 },
                                                new District { DistrictId = 379, DName = "Altınözü", CityId = 31 },
                                                new District { DistrictId = 380, DName = "Dörtyol", CityId = 31 },
                                                new District { DistrictId = 381, DName = "Hassa", CityId = 31 },
                                                new District { DistrictId = 382, DName = "İskenderun", CityId = 31 },
                                                new District { DistrictId = 383, DName = "Kırıkhan", CityId = 31 },
                                                new District { DistrictId = 384, DName = "Reyhanlı", CityId = 31 },
                                                new District { DistrictId = 385, DName = "Samandağ", CityId = 31 },
                                                new District { DistrictId = 386, DName = "Yayladağı", CityId = 31 },
                                                new District { DistrictId = 387, DName = "Erzin", CityId = 31 },
                                                new District { DistrictId = 388, DName = "Belen", CityId = 31 },
                                                new District { DistrictId = 389, DName = "Kumlu", CityId = 31 },
                                                new District { DistrictId = 390, DName = "Antakya", CityId = 31 },
                                                new District { DistrictId = 391, DName = "Arsuz", CityId = 31 },
                                                new District { DistrictId = 392, DName = "Defne", CityId = 31 },
                                                new District { DistrictId = 393, DName = "Payas", CityId = 31 },
                                                new District { DistrictId = 394, DName = "Atabey", CityId = 32 },
                                                new District { DistrictId = 395, DName = "Eğirdir", CityId = 32 },
                                                new District { DistrictId = 396, DName = "Gelendost", CityId = 32 },
                                                new District { DistrictId = 397, DName = "Isparta Merkez", CityId = 32 },
                                                new District { DistrictId = 398, DName = "Keçiborlu", CityId = 32 },
                                                new District { DistrictId = 399, DName = "Senirkent", CityId = 32 },
                                                new District { DistrictId = 400, DName = "Sütçüler", CityId = 32 },
                                                new District { DistrictId = 401, DName = "Şarkikaraağaç", CityId = 32 },
                                                new District { DistrictId = 402, DName = "Uluborlu", CityId = 32 },
                                                new District { DistrictId = 403, DName = "Yalvaç", CityId = 32 },
                                                new District { DistrictId = 404, DName = "Aksu / Isparta", CityId = 32 },
                                                new District { DistrictId = 405, DName = "Gönen / Isparta", CityId = 32 },
                                                new District { DistrictId = 406, DName = "Yenişarbademli", CityId = 32 },
                                                new District { DistrictId = 407, DName = "Anamur", CityId = 33 },
                                                new District { DistrictId = 408, DName = "Erdemli", CityId = 33 },
                                                new District { DistrictId = 409, DName = "Gülnar", CityId = 33 },
                                                new District { DistrictId = 410, DName = "Mut", CityId = 33 },
                                                new District { DistrictId = 411, DName = "Silifke", CityId = 33 },
                                                new District { DistrictId = 412, DName = "Tarsus", CityId = 33 },
                                                new District { DistrictId = 413, DName = "Aydıncık / Mersin", CityId = 33 },
                                                new District { DistrictId = 414, DName = "Bozyazı", CityId = 33 },
                                                new District { DistrictId = 415, DName = "Çamlıyayla", CityId = 33 },
                                                new District { DistrictId = 416, DName = "Akdeniz", CityId = 33 },
                                                new District { DistrictId = 417, DName = "Mezitli", CityId = 33 },
                                                new District { DistrictId = 418, DName = "Toroslar", CityId = 33 },
                                                new District { DistrictId = 419, DName = "Yenişehir / Mersin", CityId = 33 },
                                                new District { DistrictId = 420, DName = "Adalar", CityId = 34 },
                                                new District { DistrictId = 421, DName = "Bakırköy", CityId = 34 },
                                                new District { DistrictId = 422, DName = "Beşiktaş", CityId = 34 },
                                                new District { DistrictId = 423, DName = "Beykoz", CityId = 34 },
                                                new District { DistrictId = 424, DName = "Beyoğlu", CityId = 34 },
                                                new District { DistrictId = 425, DName = "Çatalca", CityId = 34 },
                                                new District { DistrictId = 426, DName = "Eyüp", CityId = 34 },
                                                new District { DistrictId = 427, DName = "Fatih", CityId = 34 },
                                                new District { DistrictId = 428, DName = "Gaziosmanpaşa", CityId = 34 },
                                                new District { DistrictId = 429, DName = "Kadıköy", CityId = 34 },
                                                new District { DistrictId = 430, DName = "Kartal", CityId = 34 },
                                                new District { DistrictId = 431, DName = "Sarıyer", CityId = 34 },
                                                new District { DistrictId = 432, DName = "Silivri", CityId = 34 },
                                                new District { DistrictId = 433, DName = "Şile", CityId = 34 },
                                                new District { DistrictId = 434, DName = "Şişli", CityId = 34 },
                                                new District { DistrictId = 435, DName = "Üsküdar", CityId = 34 },
                                                new District { DistrictId = 436, DName = "Zeytinburnu", CityId = 34 },
                                                new District { DistrictId = 437, DName = "Büyükçekmece", CityId = 34 },
                                                new District { DistrictId = 438, DName = "Kağıthane", CityId = 34 },
                                                new District { DistrictId = 439, DName = "Küçükçekmece", CityId = 34 },
                                                new District { DistrictId = 440, DName = "Pendik", CityId = 34 },
                                                new District { DistrictId = 441, DName = "Ümraniye", CityId = 34 },
                                                new District { DistrictId = 442, DName = "Bayrampaşa", CityId = 34 },
                                                new District { DistrictId = 443, DName = "Avcılar", CityId = 34 },
                                                new District { DistrictId = 444, DName = "Bağcılar", CityId = 34 },
                                                new District { DistrictId = 445, DName = "Bahçelievler", CityId = 34 },
                                                new District { DistrictId = 446, DName = "Güngören", CityId = 34 },
                                                new District { DistrictId = 447, DName = "Maltepe", CityId = 34 },
                                                new District { DistrictId = 448, DName = "Sultanbeyli", CityId = 34 },
                                                new District { DistrictId = 449, DName = "Tuzla", CityId = 34 },
                                                new District { DistrictId = 450, DName = "Esenler", CityId = 34 },
                                                new District { DistrictId = 451, DName = "Arnavutköy", CityId = 34 },
                                                new District { DistrictId = 452, DName = "Ataşehir", CityId = 34 },
                                                new District { DistrictId = 453, DName = "Başakşehir", CityId = 34 },
                                                new District { DistrictId = 454, DName = "Beylikdüzü", CityId = 34 },
                                                new District { DistrictId = 455, DName = "Çekmeköy", CityId = 34 },
                                                new District { DistrictId = 456, DName = "Esenyurt", CityId = 34 },
                                                new District { DistrictId = 457, DName = "Sancaktepe", CityId = 34 },
                                                new District { DistrictId = 458, DName = "Sultangazi", CityId = 34 },
                                                new District { DistrictId = 459, DName = "Aliağa", CityId = 35 },
                                                new District { DistrictId = 460, DName = "Bayındır", CityId = 35 },
                                                new District { DistrictId = 461, DName = "Bergama", CityId = 35 },
                                                new District { DistrictId = 462, DName = "Bornova", CityId = 35 },
                                                new District { DistrictId = 463, DName = "Çeşme", CityId = 35 },
                                                new District { DistrictId = 464, DName = "Dikili", CityId = 35 },
                                                new District { DistrictId = 465, DName = "Foça", CityId = 35 },
                                                new District { DistrictId = 466, DName = "Karaburun", CityId = 35 },
                                                new District { DistrictId = 467, DName = "Karşıyaka", CityId = 35 },
                                                new District { DistrictId = 468, DName = "Kemalpaşa / İzmir", CityId = 35 },
                                                new District { DistrictId = 469, DName = "Kınık", CityId = 35 },
                                                new District { DistrictId = 470, DName = "Kiraz", CityId = 35 },
                                                new District { DistrictId = 471, DName = "Menemen", CityId = 35 },
                                                new District { DistrictId = 472, DName = "Ödemiş", CityId = 35 },
                                                new District { DistrictId = 473, DName = "Seferihisar", CityId = 35 },
                                                new District { DistrictId = 474, DName = "Selçuk", CityId = 35 },
                                                new District { DistrictId = 475, DName = "Tire", CityId = 35 },
                                                new District { DistrictId = 476, DName = "Torbalı", CityId = 35 },
                                                new District { DistrictId = 477, DName = "Urla", CityId = 35 },
                                                new District { DistrictId = 478, DName = "Beydağ", CityId = 35 },
                                                new District { DistrictId = 479, DName = "Buca", CityId = 35 },
                                                new District { DistrictId = 480, DName = "Konak", CityId = 35 },
                                                new District { DistrictId = 481, DName = "Menderes", CityId = 35 },
                                                new District { DistrictId = 482, DName = "Balçova", CityId = 35 },
                                                new District { DistrictId = 483, DName = "Çiğli", CityId = 35 },
                                                new District { DistrictId = 484, DName = "Gaziemir", CityId = 35 },
                                                new District { DistrictId = 485, DName = "Narlıdere", CityId = 35 },
                                                new District { DistrictId = 486, DName = "Güzelbahçe", CityId = 35 },
                                                new District { DistrictId = 487, DName = "Bayraklı", CityId = 35 },
                                                new District { DistrictId = 488, DName = "Karabağlar", CityId = 35 },
                                                new District { DistrictId = 489, DName = "Arpaçay", CityId = 36 },
                                                new District { DistrictId = 490, DName = "Digor", CityId = 36 },
                                                new District { DistrictId = 491, DName = "Kağızman", CityId = 36 },
                                                new District { DistrictId = 492, DName = "Kars Merkez", CityId = 36 },
                                                new District { DistrictId = 493, DName = "Sarıkamış", CityId = 36 },
                                                new District { DistrictId = 494, DName = "Selim", CityId = 36 },
                                                new District { DistrictId = 495, DName = "Susuz", CityId = 36 },
                                                new District { DistrictId = 496, DName = "Akyaka", CityId = 36 },
                                                new District { DistrictId = 497, DName = "Abana", CityId = 37 },
                                                new District { DistrictId = 498, DName = "Araç", CityId = 37 },
                                                new District { DistrictId = 499, DName = "Azdavay", CityId = 37 },
                                                new District { DistrictId = 500, DName = "Bozkurt / Kastamonu", CityId = 37 },
                                                new District { DistrictId = 501, DName = "Cide", CityId = 37 },
                                                new District { DistrictId = 502, DName = "Çatalzeytin", CityId = 37 },
                                                new District { DistrictId = 503, DName = "Daday", CityId = 37 },
                                                new District { DistrictId = 504, DName = "Devrekani", CityId = 37 },
                                                new District { DistrictId = 505, DName = "İnebolu", CityId = 37 },
                                                new District { DistrictId = 506, DName = "Kastamonu Merkez", CityId = 37 },
                                                new District { DistrictId = 507, DName = "Küre", CityId = 37 },
                                                new District { DistrictId = 508, DName = "Taşköprü", CityId = 37 },
                                                new District { DistrictId = 509, DName = "Tosya", CityId = 37 },
                                                new District { DistrictId = 510, DName = "İhsangazi", CityId = 37 },
                                                new District { DistrictId = 511, DName = "Pınarbaşı / Kastamonu", CityId = 37 },
                                                new District { DistrictId = 512, DName = "Şenpazar", CityId = 37 },
                                                new District { DistrictId = 513, DName = "Ağlı", CityId = 37 },
                                                new District { DistrictId = 514, DName = "Doğanyurt", CityId = 37 },
                                                new District { DistrictId = 515, DName = "Hanönü", CityId = 37 },
                                                new District { DistrictId = 516, DName = "Seydiler", CityId = 37 },
                                                new District { DistrictId = 517, DName = "Bünyan", CityId = 38 },
                                                new District { DistrictId = 518, DName = "Develi", CityId = 38 },
                                                new District { DistrictId = 519, DName = "Felahiye", CityId = 38 },
                                                new District { DistrictId = 520, DName = "İncesu", CityId = 38 },
                                                new District { DistrictId = 521, DName = "Pınarbaşı / Kayseri", CityId = 38 },
                                                new District { DistrictId = 522, DName = "Sarıoğlan", CityId = 38 },
                                                new District { DistrictId = 523, DName = "Sarız", CityId = 38 },
                                                new District { DistrictId = 524, DName = "Tomarza", CityId = 38 },
                                                new District { DistrictId = 525, DName = "Yahyalı", CityId = 38 },
                                                new District { DistrictId = 526, DName = "Yeşilhisar", CityId = 38 },
                                                new District { DistrictId = 527, DName = "Akkışla", CityId = 38 },
                                                new District { DistrictId = 528, DName = "Talas", CityId = 38 },
                                                new District { DistrictId = 529, DName = "Kocasinan", CityId = 38 },
                                                new District { DistrictId = 530, DName = "Melikgazi", CityId = 38 },
                                                new District { DistrictId = 531, DName = "Hacılar", CityId = 38 },
                                                new District { DistrictId = 532, DName = "Özvatan", CityId = 38 },
                                                new District { DistrictId = 533, DName = "Babaeski", CityId = 39 },
                                                new District { DistrictId = 534, DName = "Demirköy", CityId = 39 },
                                                new District { DistrictId = 535, DName = "Kırklareli Merkez", CityId = 39 },
                                                new District { DistrictId = 536, DName = "Kofçaz", CityId = 39 },
                                                new District { DistrictId = 537, DName = "Lüleburgaz", CityId = 39 },
                                                new District { DistrictId = 538, DName = "Pehlivanköy", CityId = 39 },
                                                new District { DistrictId = 539, DName = "Pınarhisar", CityId = 39 },
                                                new District { DistrictId = 540, DName = "Vize", CityId = 39 },
                                                new District { DistrictId = 541, DName = "Çiçekdağı", CityId = 40 },
                                                new District { DistrictId = 542, DName = "Kaman", CityId = 40 },
                                                new District { DistrictId = 543, DName = "Kırşehir Merkez", CityId = 40 },
                                                new District { DistrictId = 544, DName = "Mucur", CityId = 40 },
                                                new District { DistrictId = 545, DName = "Akpınar", CityId = 40 },
                                                new District { DistrictId = 546, DName = "Akçakent", CityId = 40 },
                                                new District { DistrictId = 547, DName = "Boztepe", CityId = 40 },
                                                new District { DistrictId = 548, DName = "Gebze", CityId = 41 },
                                                new District { DistrictId = 549, DName = "Gölcük", CityId = 41 },
                                                new District { DistrictId = 550, DName = "Kandıra", CityId = 41 },
                                                new District { DistrictId = 551, DName = "Karamürsel", CityId = 41 },
                                                new District { DistrictId = 552, DName = "Körfez", CityId = 41 },
                                                new District { DistrictId = 553, DName = "Derince", CityId = 41 },
                                                new District { DistrictId = 554, DName = "Başiskele", CityId = 41 },
                                                new District { DistrictId = 555, DName = "Çayırova", CityId = 41 },
                                                new District { DistrictId = 556, DName = "Darıca", CityId = 41 },
                                                new District { DistrictId = 557, DName = "Dilovası", CityId = 41 },
                                                new District { DistrictId = 558, DName = "İzmit", CityId = 41 },
                                                new District { DistrictId = 559, DName = "Kartepe", CityId = 41 },
                                                new District { DistrictId = 560, DName = "Akşehir", CityId = 42 },
                                                new District { DistrictId = 561, DName = "Beyşehir", CityId = 42 },
                                                new District { DistrictId = 562, DName = "Bozkır", CityId = 42 },
                                                new District { DistrictId = 563, DName = "Cihanbeyli", CityId = 42 },
                                                new District { DistrictId = 564, DName = "Çumra", CityId = 42 },
                                                new District { DistrictId = 565, DName = "Doğanhisar", CityId = 42 },
                                                new District { DistrictId = 566, DName = "Ereğli / Konya", CityId = 42 },
                                                new District { DistrictId = 567, DName = "Hadim", CityId = 42 },
                                                new District { DistrictId = 568, DName = "Ilgın", CityId = 42 },
                                                new District { DistrictId = 569, DName = "Kadınhanı", CityId = 42 },
                                                new District { DistrictId = 570, DName = "Karapınar", CityId = 42 },
                                                new District { DistrictId = 571, DName = "Kulu", CityId = 42 },
                                                new District { DistrictId = 572, DName = "Sarayönü", CityId = 42 },
                                                new District { DistrictId = 573, DName = "Seydişehir", CityId = 42 },
                                                new District { DistrictId = 574, DName = "Yunak", CityId = 42 },
                                                new District { DistrictId = 575, DName = "Akören", CityId = 42 },
                                                new District { DistrictId = 576, DName = "Altınekin", CityId = 42 },
                                                new District { DistrictId = 577, DName = "Derebucak", CityId = 42 },
                                                new District { DistrictId = 578, DName = "Hüyük", CityId = 42 },
                                                new District { DistrictId = 579, DName = "Karatay", CityId = 42 },
                                                new District { DistrictId = 580, DName = "Meram", CityId = 42 },
                                                new District { DistrictId = 581, DName = "Selçuklu", CityId = 42 },
                                                new District { DistrictId = 582, DName = "Taşkent", CityId = 42 },
                                                new District { DistrictId = 583, DName = "Ahırlı", CityId = 42 },
                                                new District { DistrictId = 584, DName = "Çeltik", CityId = 42 },
                                                new District { DistrictId = 585, DName = "Derbent", CityId = 42 },
                                                new District { DistrictId = 586, DName = "Emirgazi", CityId = 42 },
                                                new District { DistrictId = 587, DName = "Güneysınır", CityId = 42 },
                                                new District { DistrictId = 588, DName = "Halkapınar", CityId = 42 },
                                                new District { DistrictId = 589, DName = "Tuzlukçu", CityId = 42 },
                                                new District { DistrictId = 590, DName = "Yalıhüyük", CityId = 42 },
                                                new District { DistrictId = 591, DName = "Altıntaş", CityId = 43 },
                                                new District { DistrictId = 592, DName = "Domaniç", CityId = 43 },
                                                new District { DistrictId = 593, DName = "Emet", CityId = 43 },
                                                new District { DistrictId = 594, DName = "Gediz", CityId = 43 },
                                                new District { DistrictId = 595, DName = "Kütahya Merkez", CityId = 43 },
                                                new District { DistrictId = 596, DName = "Simav", CityId = 43 },
                                                new District { DistrictId = 597, DName = "Tavşanlı", CityId = 43 },
                                                new District { DistrictId = 598, DName = "Aslanapa", CityId = 43 },
                                                new District { DistrictId = 599, DName = "Dumlupınar", CityId = 43 },
                                                new District { DistrictId = 600, DName = "Hisarcık", CityId = 43 },
                                                new District { DistrictId = 601, DName = "Şaphane", CityId = 43 },
                                                new District { DistrictId = 602, DName = "Çavdarhisar", CityId = 43 },
                                                new District { DistrictId = 603, DName = "Pazarlar", CityId = 43 },
                                                new District { DistrictId = 604, DName = "Akçadağ", CityId = 44 },
                                                new District { DistrictId = 605, DName = "Arapgir", CityId = 44 },
                                                new District { DistrictId = 606, DName = "Arguvan", CityId = 44 },
                                                new District { DistrictId = 607, DName = "Darende", CityId = 44 },
                                                new District { DistrictId = 608, DName = "Doğanşehir", CityId = 44 },
                                                new District { DistrictId = 609, DName = "Hekimhan", CityId = 44 },
                                                new District { DistrictId = 610, DName = "Pütürge", CityId = 44 },
                                                new District { DistrictId = 611, DName = "Yeşilyurt / Malatya", CityId = 44 },
                                                new District { DistrictId = 612, DName = "Battalgazi", CityId = 44 },
                                                new District { DistrictId = 613, DName = "Doğanyol", CityId = 44 },
                                                new District { DistrictId = 614, DName = "Kale / Malatya", CityId = 44 },
                                                new District { DistrictId = 615, DName = "Kuluncak", CityId = 44 },
                                                new District { DistrictId = 616, DName = "Yazıhan", CityId = 44 },
                                                new District { DistrictId = 617, DName = "Akhisar", CityId = 45 },
                                                new District { DistrictId = 618, DName = "Alaşehir", CityId = 45 },
                                                new District { DistrictId = 619, DName = "Demirci", CityId = 45 },
                                                new District { DistrictId = 620, DName = "Gördes", CityId = 45 },
                                                new District { DistrictId = 621, DName = "Kırkağaç", CityId = 45 },
                                                new District { DistrictId = 622, DName = "Kula", CityId = 45 },
                                                new District { DistrictId = 623, DName = "Salihli", CityId = 45 },
                                                new District { DistrictId = 624, DName = "Sarıgöl", CityId = 45 },
                                                new District { DistrictId = 625, DName = "Saruhanlı", CityId = 45 },
                                                new District { DistrictId = 626, DName = "Selendi", CityId = 45 },
                                                new District { DistrictId = 627, DName = "Soma", CityId = 45 },
                                                new District { DistrictId = 628, DName = "Turgutlu", CityId = 45 },
                                                new District { DistrictId = 629, DName = "Ahmetli", CityId = 45 },
                                                new District { DistrictId = 630, DName = "Gölmarmara", CityId = 45 },
                                                new District { DistrictId = 631, DName = "Köprübaşı / Manisa", CityId = 45 },
                                                new District { DistrictId = 632, DName = "Şehzadeler", CityId = 45 },
                                                new District { DistrictId = 633, DName = "Yunusemre", CityId = 45 },
                                                new District { DistrictId = 634, DName = "Afşin", CityId = 46 },
                                                new District { DistrictId = 635, DName = "Andırın", CityId = 46 },
                                                new District { DistrictId = 636, DName = "Elbistan", CityId = 46 },
                                                new District { DistrictId = 637, DName = "Göksun", CityId = 46 },
                                                new District { DistrictId = 638, DName = "Pazarcık", CityId = 46 },
                                                new District { DistrictId = 639, DName = "Türkoğlu", CityId = 46 },
                                                new District { DistrictId = 640, DName = "Çağlayancerit", CityId = 46 },
                                                new District { DistrictId = 641, DName = "Ekinözü", CityId = 46 },
                                                new District { DistrictId = 642, DName = "Nurhak", CityId = 46 },
                                                new District { DistrictId = 643, DName = "Dulkadiroğlu", CityId = 46 },
                                                new District { DistrictId = 644, DName = "Onikişubat", CityId = 46 },
                                                new District { DistrictId = 645, DName = "Derik", CityId = 47 },
                                                new District { DistrictId = 646, DName = "Kızıltepe", CityId = 47 },
                                                new District { DistrictId = 647, DName = "Mazıdağı", CityId = 47 },
                                                new District { DistrictId = 648, DName = "Midyat", CityId = 47 },
                                                new District { DistrictId = 649, DName = "Nusaybin", CityId = 47 },
                                                new District { DistrictId = 650, DName = "Ömerli", CityId = 47 },
                                                new District { DistrictId = 651, DName = "Savur", CityId = 47 },
                                                new District { DistrictId = 652, DName = "Dargeçit", CityId = 47 },
                                                new District { DistrictId = 653, DName = "Yeşilli", CityId = 47 },
                                                new District { DistrictId = 654, DName = "Artuklu", CityId = 47 },
                                                new District { DistrictId = 655, DName = "Bodrum", CityId = 48 },
                                                new District { DistrictId = 656, DName = "Datça", CityId = 48 },
                                                new District { DistrictId = 657, DName = "Fethiye", CityId = 48 },
                                                new District { DistrictId = 658, DName = "Köyceğiz", CityId = 48 },
                                                new District { DistrictId = 659, DName = "Marmaris", CityId = 48 },
                                                new District { DistrictId = 660, DName = "Milas", CityId = 48 },
                                                new District { DistrictId = 661, DName = "Ula", CityId = 48 },
                                                new District { DistrictId = 662, DName = "Yatağan", CityId = 48 },
                                                new District { DistrictId = 663, DName = "Dalaman", CityId = 48 },
                                                new District { DistrictId = 664, DName = "Ortaca", CityId = 48 },
                                                new District { DistrictId = 665, DName = "Kavaklıdere", CityId = 48 },
                                                new District { DistrictId = 666, DName = "Menteşe", CityId = 48 },
                                                new District { DistrictId = 667, DName = "Seydikemer", CityId = 48 },
                                                new District { DistrictId = 668, DName = "Bulanık", CityId = 49 },
                                                new District { DistrictId = 669, DName = "Malazgirt", CityId = 49 },
                                                new District { DistrictId = 670, DName = "Muş Merkez", CityId = 49 },
                                                new District { DistrictId = 671, DName = "Varto", CityId = 49 },
                                                new District { DistrictId = 672, DName = "Hasköy", CityId = 49 },
                                                new District { DistrictId = 673, DName = "Korkut", CityId = 49 },
                                                new District { DistrictId = 674, DName = "Avanos", CityId = 50 },
                                                new District { DistrictId = 675, DName = "Derinkuyu", CityId = 50 },
                                                new District { DistrictId = 676, DName = "Gülşehir", CityId = 50 },
                                                new District { DistrictId = 677, DName = "Hacıbektaş", CityId = 50 },
                                                new District { DistrictId = 678, DName = "Kozaklı", CityId = 50 },
                                                new District { DistrictId = 679, DName = "Nevşehir Merkez", CityId = 50 },
                                                new District { DistrictId = 680, DName = "Ürgüp", CityId = 50 },
                                                new District { DistrictId = 681, DName = "Acıgöl", CityId = 50 },
                                                new District { DistrictId = 682, DName = "Bor", CityId = 51 },
                                                new District { DistrictId = 683, DName = "Çamardı", CityId = 51 },
                                                new District { DistrictId = 684, DName = "Niğde Merkez", CityId = 51 },
                                                new District { DistrictId = 685, DName = "Ulukışla", CityId = 51 },
                                                new District { DistrictId = 686, DName = "Altunhisar", CityId = 51 },
                                                new District { DistrictId = 687, DName = "Çiftlik", CityId = 51 },
                                                new District { DistrictId = 688, DName = "Akkuş", CityId = 52 },
                                                new District { DistrictId = 689, DName = "Aybastı", CityId = 52 },
                                                new District { DistrictId = 690, DName = "Fatsa", CityId = 52 },
                                                new District { DistrictId = 691, DName = "Gölköy", CityId = 52 },
                                                new District { DistrictId = 692, DName = "Korgan", CityId = 52 },
                                                new District { DistrictId = 693, DName = "Kumru", CityId = 52 },
                                                new District { DistrictId = 694, DName = "Mesudiye", CityId = 52 },
                                                new District { DistrictId = 695, DName = "Perşembe", CityId = 52 },
                                                new District { DistrictId = 696, DName = "Ulubey / Ordu", CityId = 52 },
                                                new District { DistrictId = 697, DName = "Ünye", CityId = 52 },
                                                new District { DistrictId = 698, DName = "Gülyalı", CityId = 52 },
                                                new District { DistrictId = 699, DName = "Gürgentepe", CityId = 52 },
                                                new District { DistrictId = 700, DName = "Çamaş", CityId = 52 },
                                                new District { DistrictId = 701, DName = "Çatalpınar", CityId = 52 },
                                                new District { DistrictId = 702, DName = "Çaybaşı", CityId = 52 },
                                                new District { DistrictId = 703, DName = "İkizce", CityId = 52 },
                                                new District { DistrictId = 704, DName = "Kabadüz", CityId = 52 },
                                                new District { DistrictId = 705, DName = "Kabataş", CityId = 52 },
                                                new District { DistrictId = 706, DName = "Altınordu", CityId = 52 },
                                                new District { DistrictId = 707, DName = "Ardeşen", CityId = 53 },
                                                new District { DistrictId = 708, DName = "Çamlıhemşin", CityId = 53 },
                                                new District { DistrictId = 709, DName = "Çayeli", CityId = 53 },
                                                new District { DistrictId = 710, DName = "Fındıklı", CityId = 53 },
                                                new District { DistrictId = 711, DName = "İkizdere", CityId = 53 },
                                                new District { DistrictId = 712, DName = "Kalkandere", CityId = 53 },
                                                new District { DistrictId = 713, DName = "Pazar / Rize", CityId = 53 },
                                                new District { DistrictId = 714, DName = "Rize Merkez", CityId = 53 },
                                                new District { DistrictId = 715, DName = "Güneysu", CityId = 53 },
                                                new District { DistrictId = 716, DName = "Derepazarı", CityId = 53 },
                                                new District { DistrictId = 717, DName = "Hemşin", CityId = 53 },
                                                new District { DistrictId = 718, DName = "İyidere", CityId = 53 },
                                                new District { DistrictId = 719, DName = "Akyazı", CityId = 54 },
                                                new District { DistrictId = 720, DName = "Geyve", CityId = 54 },
                                                new District { DistrictId = 721, DName = "Hendek", CityId = 54 },
                                                new District { DistrictId = 722, DName = "Karasu", CityId = 54 },
                                                new District { DistrictId = 723, DName = "Kaynarca", CityId = 54 },
                                                new District { DistrictId = 724, DName = "Sapanca", CityId = 54 },
                                                new District { DistrictId = 725, DName = "Kocaali", CityId = 54 },
                                                new District { DistrictId = 726, DName = "Pamukova", CityId = 54 },
                                                new District { DistrictId = 727, DName = "Taraklı", CityId = 54 },
                                                new District { DistrictId = 728, DName = "Ferizli", CityId = 54 },
                                                new District { DistrictId = 729, DName = "Karapürçek", CityId = 54 },
                                                new District { DistrictId = 730, DName = "Söğütlü", CityId = 54 },
                                                new District { DistrictId = 731, DName = "Adapazarı", CityId = 54 },
                                                new District { DistrictId = 732, DName = "Arifiye", CityId = 54 },
                                                new District { DistrictId = 733, DName = "Erenler", CityId = 54 },
                                                new District { DistrictId = 734, DName = "Serdivan", CityId = 54 },
                                                new District { DistrictId = 735, DName = "Alaçam", CityId = 55 },
                                                new District { DistrictId = 736, DName = "Bafra", CityId = 55 },
                                                new District { DistrictId = 737, DName = "Çarşamba", CityId = 55 },
                                                new District { DistrictId = 738, DName = "Havza", CityId = 55 },
                                                new District { DistrictId = 739, DName = "Kavak", CityId = 55 },
                                                new District { DistrictId = 740, DName = "Ladik", CityId = 55 },
                                                new District { DistrictId = 741, DName = "Terme", CityId = 55 },
                                                new District { DistrictId = 742, DName = "Vezirköprü", CityId = 55 },
                                                new District { DistrictId = 743, DName = "Asarcık", CityId = 55 },
                                                new District { DistrictId = 744, DName = "43604", CityId = 55 },
                                                new District { DistrictId = 745, DName = "Salıpazarı", CityId = 55 },
                                                new District { DistrictId = 746, DName = "Tekkeköy", CityId = 55 },
                                                new District { DistrictId = 747, DName = "Ayvacık / Samsun", CityId = 55 },
                                                new District { DistrictId = 748, DName = "Yakakent", CityId = 55 },
                                                new District { DistrictId = 749, DName = "Atakum", CityId = 55 },
                                                new District { DistrictId = 750, DName = "Canik", CityId = 55 },
                                                new District { DistrictId = 751, DName = "İlkadım", CityId = 55 },
                                                new District { DistrictId = 752, DName = "Baykan", CityId = 56 },
                                                new District { DistrictId = 753, DName = "Eruh", CityId = 56 },
                                                new District { DistrictId = 754, DName = "Kurtalan", CityId = 56 },
                                                new District { DistrictId = 755, DName = "Pervari", CityId = 56 },
                                                new District { DistrictId = 756, DName = "Siirt Merkez", CityId = 56 },
                                                new District { DistrictId = 757, DName = "Şirvan", CityId = 56 },
                                                new District { DistrictId = 758, DName = "Tillo", CityId = 56 },
                                                new District { DistrictId = 759, DName = "Ayancık", CityId = 57 },
                                                new District { DistrictId = 760, DName = "Boyabat", CityId = 57 },
                                                new District { DistrictId = 761, DName = "Durağan", CityId = 57 },
                                                new District { DistrictId = 762, DName = "Erfelek", CityId = 57 },
                                                new District { DistrictId = 763, DName = "Gerze", CityId = 57 },
                                                new District { DistrictId = 764, DName = "Sinop Merkez", CityId = 57 },
                                                new District { DistrictId = 765, DName = "Türkeli", CityId = 57 },
                                                new District { DistrictId = 766, DName = "Dikmen", CityId = 57 },
                                                new District { DistrictId = 767, DName = "Saraydüzü", CityId = 57 },
                                                new District { DistrictId = 768, DName = "Divriği", CityId = 58 },
                                                new District { DistrictId = 769, DName = "Gemerek", CityId = 58 },
                                                new District { DistrictId = 770, DName = "Gürün", CityId = 58 },
                                                new District { DistrictId = 771, DName = "Hafik", CityId = 58 },
                                                new District { DistrictId = 772, DName = "İmranlı", CityId = 58 },
                                                new District { DistrictId = 773, DName = "Kangal", CityId = 58 },
                                                new District { DistrictId = 774, DName = "Koyulhisar", CityId = 58 },
                                                new District { DistrictId = 775, DName = "Sivas Merkez", CityId = 58 },
                                                new District { DistrictId = 776, DName = "Suşehri", CityId = 58 },
                                                new District { DistrictId = 777, DName = "Şarkışla", CityId = 58 },
                                                new District { DistrictId = 778, DName = "Yıldızeli", CityId = 58 },
                                                new District { DistrictId = 779, DName = "Zara", CityId = 58 },
                                                new District { DistrictId = 780, DName = "Akıncılar", CityId = 58 },
                                                new District { DistrictId = 781, DName = "Altınyayla / Sivas", CityId = 58 },
                                                new District { DistrictId = 782, DName = "Doğanşar", CityId = 58 },
                                                new District { DistrictId = 783, DName = "Gölova", CityId = 58 },
                                                new District { DistrictId = 784, DName = "Ulaş", CityId = 58 },
                                                new District { DistrictId = 785, DName = "Çerkezköy", CityId = 59 },
                                                new District { DistrictId = 786, DName = "Çorlu", CityId = 59 },
                                                new District { DistrictId = 787, DName = "Hayrabolu", CityId = 59 },
                                                new District { DistrictId = 788, DName = "Malkara", CityId = 59 },
                                                new District { DistrictId = 789, DName = "Muratlı", CityId = 59 },
                                                new District { DistrictId = 790, DName = "Saray / Tekirdağ", CityId = 59 },
                                                new District { DistrictId = 791, DName = "Şarköy", CityId = 59 },
                                                new District { DistrictId = 792, DName = "Marmaraereğlisi", CityId = 59 },
                                                new District { DistrictId = 793, DName = "Ergene", CityId = 59 },
                                                new District { DistrictId = 794, DName = "Kapaklı", CityId = 59 },
                                                new District { DistrictId = 795, DName = "Süleymanpaşa", CityId = 59 },
                                                new District { DistrictId = 796, DName = "Almus", CityId = 60 },
                                                new District { DistrictId = 797, DName = "Artova", CityId = 60 },
                                                new District { DistrictId = 798, DName = "Erbaa", CityId = 60 },
                                                new District { DistrictId = 799, DName = "Niksar", CityId = 60 },
                                                new District { DistrictId = 800, DName = "Reşadiye", CityId = 60 },
                                                new District { DistrictId = 801, DName = "Tokat Merkez", CityId = 60 },
                                                new District { DistrictId = 802, DName = "Turhal", CityId = 60 },
                                                new District { DistrictId = 803, DName = "Zile", CityId = 60 },
                                                new District { DistrictId = 804, DName = "Pazar / Tokat", CityId = 60 },
                                                new District { DistrictId = 805, DName = "Yeşilyurt / Tokat", CityId = 60 },
                                                new District { DistrictId = 806, DName = "Başçiftlik", CityId = 60 },
                                                new District { DistrictId = 807, DName = "Sulusaray", CityId = 60 },
                                                new District { DistrictId = 808, DName = "Akçaabat", CityId = 61 },
                                                new District { DistrictId = 809, DName = "Araklı", CityId = 61 },
                                                new District { DistrictId = 810, DName = "Arsin", CityId = 61 },
                                                new District { DistrictId = 811, DName = "Çaykara", CityId = 61 },
                                                new District { DistrictId = 812, DName = "Maçka", CityId = 61 },
                                                new District { DistrictId = 813, DName = "Of", CityId = 61 },
                                                new District { DistrictId = 814, DName = "Sürmene", CityId = 61 },
                                                new District { DistrictId = 815, DName = "Tonya", CityId = 61 },
                                                new District { DistrictId = 816, DName = "Vakfıkebir", CityId = 61 },
                                                new District { DistrictId = 817, DName = "Yomra", CityId = 61 },
                                                new District { DistrictId = 818, DName = "Beşikdüzü", CityId = 61 },
                                                new District { DistrictId = 819, DName = "Şalpazarı", CityId = 61 },
                                                new District { DistrictId = 820, DName = "Çarşıbaşı", CityId = 61 },
                                                new District { DistrictId = 821, DName = "Dernekpazarı", CityId = 61 },
                                                new District { DistrictId = 822, DName = "Düzköy", CityId = 61 },
                                                new District { DistrictId = 823, DName = "Hayrat", CityId = 61 },
                                                new District { DistrictId = 824, DName = "Köprübaşı / Trabzon", CityId = 61 },
                                                new District { DistrictId = 825, DName = "Ortahisar", CityId = 61 },
                                                new District { DistrictId = 826, DName = "Çemişgezek", CityId = 62 },
                                                new District { DistrictId = 827, DName = "Hozat", CityId = 62 },
                                                new District { DistrictId = 828, DName = "Mazgirt", CityId = 62 },
                                                new District { DistrictId = 829, DName = "Nazımiye", CityId = 62 },
                                                new District { DistrictId = 830, DName = "Ovacık / Tunceli", CityId = 62 },
                                                new District { DistrictId = 831, DName = "Pertek", CityId = 62 },
                                                new District { DistrictId = 832, DName = "Pülümür", CityId = 62 },
                                                new District { DistrictId = 833, DName = "Tunceli Merkez", CityId = 62 },
                                                new District { DistrictId = 834, DName = "Akçakale", CityId = 63 },
                                                new District { DistrictId = 835, DName = "Birecik", CityId = 63 },
                                                new District { DistrictId = 836, DName = "Bozova", CityId = 63 },
                                                new District { DistrictId = 837, DName = "Ceylanpınar", CityId = 63 },
                                                new District { DistrictId = 838, DName = "Halfeti", CityId = 63 },
                                                new District { DistrictId = 839, DName = "Hilvan", CityId = 63 },
                                                new District { DistrictId = 840, DName = "Siverek", CityId = 63 },
                                                new District { DistrictId = 841, DName = "Suruç", CityId = 63 },
                                                new District { DistrictId = 842, DName = "Viranşehir", CityId = 63 },
                                                new District { DistrictId = 843, DName = "Harran", CityId = 63 },
                                                new District { DistrictId = 844, DName = "Eyyübiye", CityId = 63 },
                                                new District { DistrictId = 845, DName = "Haliliye", CityId = 63 },
                                                new District { DistrictId = 846, DName = "Karaköprü", CityId = 63 },
                                                new District { DistrictId = 847, DName = "Banaz", CityId = 64 },
                                                new District { DistrictId = 848, DName = "Eşme", CityId = 64 },
                                                new District { DistrictId = 849, DName = "Karahallı", CityId = 64 },
                                                new District { DistrictId = 850, DName = "Sivaslı", CityId = 64 },
                                                new District { DistrictId = 851, DName = "Ulubey / Uşak", CityId = 64 },
                                                new District { DistrictId = 852, DName = "Uşak Merkez", CityId = 64 },
                                                new District { DistrictId = 853, DName = "Başkale", CityId = 65 },
                                                new District { DistrictId = 854, DName = "Çatak", CityId = 65 },
                                                new District { DistrictId = 855, DName = "Erciş", CityId = 65 },
                                                new District { DistrictId = 856, DName = "Gevaş", CityId = 65 },
                                                new District { DistrictId = 857, DName = "Gürpınar", CityId = 65 },
                                                new District { DistrictId = 858, DName = "Muradiye", CityId = 65 },
                                                new District { DistrictId = 859, DName = "Özalp", CityId = 65 },
                                                new District { DistrictId = 860, DName = "Bahçesaray", CityId = 65 },
                                                new District { DistrictId = 861, DName = "Çaldıran", CityId = 65 },
                                                new District { DistrictId = 862, DName = "Edremit / Van", CityId = 65 },
                                                new District { DistrictId = 863, DName = "Saray / Van", CityId = 65 },
                                                new District { DistrictId = 864, DName = "İpekyolu", CityId = 65 },
                                                new District { DistrictId = 865, DName = "Tuşba", CityId = 65 },
                                                new District { DistrictId = 866, DName = "Akdağmadeni", CityId = 66 },
                                                new District { DistrictId = 867, DName = "Boğazlıyan", CityId = 66 },
                                                new District { DistrictId = 868, DName = "Çayıralan", CityId = 66 },
                                                new District { DistrictId = 869, DName = "Çekerek", CityId = 66 },
                                                new District { DistrictId = 870, DName = "Sarıkaya", CityId = 66 },
                                                new District { DistrictId = 871, DName = "Sorgun", CityId = 66 },
                                                new District { DistrictId = 872, DName = "Şefaatli", CityId = 66 },
                                                new District { DistrictId = 873, DName = "Yerköy", CityId = 66 },
                                                new District { DistrictId = 874, DName = "Yozgat Merkez", CityId = 66 },
                                                new District { DistrictId = 875, DName = "Aydıncık / Yozgat", CityId = 66 },
                                                new District { DistrictId = 876, DName = "Çandır", CityId = 66 },
                                                new District { DistrictId = 877, DName = "Kadışehri", CityId = 66 },
                                                new District { DistrictId = 878, DName = "Saraykent", CityId = 66 },
                                                new District { DistrictId = 879, DName = "Yenifakılı", CityId = 66 },
                                                new District { DistrictId = 880, DName = "Çaycuma", CityId = 67 },
                                                new District { DistrictId = 881, DName = "Devrek", CityId = 67 },
                                                new District { DistrictId = 882, DName = "Ereğli / Zonguldak", CityId = 67 },
                                                new District { DistrictId = 883, DName = "Zonguldak Merkez", CityId = 67 },
                                                new District { DistrictId = 884, DName = "Alaplı", CityId = 67 },
                                                new District { DistrictId = 885, DName = "Gökçebey", CityId = 67 },
                                                new District { DistrictId = 886, DName = "Kilimli", CityId = 67 },
                                                new District { DistrictId = 887, DName = "Kozlu", CityId = 67 },
                                                new District { DistrictId = 888, DName = "Aksaray Merkez", CityId = 68 },
                                                new District { DistrictId = 889, DName = "Ortaköy / Aksaray", CityId = 68 },
                                                new District { DistrictId = 890, DName = "Ağaçören", CityId = 68 },
                                                new District { DistrictId = 891, DName = "Güzelyurt", CityId = 68 },
                                                new District { DistrictId = 892, DName = "Sarıyahşi", CityId = 68 },
                                                new District { DistrictId = 893, DName = "Eskil", CityId = 68 },
                                                new District { DistrictId = 894, DName = "Gülağaç", CityId = 68 },
                                                new District { DistrictId = 895, DName = "Bayburt Merkez", CityId = 69 },
                                                new District { DistrictId = 896, DName = "Aydıntepe", CityId = 69 },
                                                new District { DistrictId = 897, DName = "Demirözü", CityId = 69 },
                                                new District { DistrictId = 898, DName = "Ermenek", CityId = 70 },
                                                new District { DistrictId = 899, DName = "Karaman Merkez", CityId = 70 },
                                                new District { DistrictId = 900, DName = "Ayrancı", CityId = 70 },
                                                new District { DistrictId = 901, DName = "Kazımkarabekir", CityId = 70 },
                                                new District { DistrictId = 902, DName = "Başyayla", CityId = 70 },
                                                new District { DistrictId = 903, DName = "Sarıveliler", CityId = 70 },
                                                new District { DistrictId = 904, DName = "Delice", CityId = 71 },
                                                new District { DistrictId = 905, DName = "Keskin", CityId = 71 },
                                                new District { DistrictId = 906, DName = "Kırıkkale Merkez", CityId = 71 },
                                                new District { DistrictId = 907, DName = "Sulakyurt", CityId = 71 },
                                                new District { DistrictId = 908, DName = "Bahşili", CityId = 71 },
                                                new District { DistrictId = 909, DName = "Balışeyh", CityId = 71 },
                                                new District { DistrictId = 910, DName = "Çelebi", CityId = 71 },
                                                new District { DistrictId = 911, DName = "Karakeçili", CityId = 71 },
                                                new District { DistrictId = 912, DName = "Yahşihan", CityId = 71 },
                                                new District { DistrictId = 913, DName = "Batman Merkez", CityId = 72 },
                                                new District { DistrictId = 914, DName = "Beşiri", CityId = 72 },
                                                new District { DistrictId = 915, DName = "Gercüş", CityId = 72 },
                                                new District { DistrictId = 916, DName = "Kozluk", CityId = 72 },
                                                new District { DistrictId = 917, DName = "Sason", CityId = 72 },
                                                new District { DistrictId = 918, DName = "Hasankeyf", CityId = 72 },
                                                new District { DistrictId = 919, DName = "Beytüşşebap", CityId = 73 },
                                                new District { DistrictId = 920, DName = "Cizre", CityId = 73 },
                                                new District { DistrictId = 921, DName = "İdil", CityId = 73 },
                                                new District { DistrictId = 922, DName = "Silopi", CityId = 73 },
                                                new District { DistrictId = 923, DName = "Şırnak Merkez", CityId = 73 },
                                                new District { DistrictId = 924, DName = "Uludere", CityId = 73 },
                                                new District { DistrictId = 925, DName = "Güçlükonak", CityId = 73 },
                                                new District { DistrictId = 926, DName = "Bartın Merkez", CityId = 74 },
                                                new District { DistrictId = 927, DName = "Kurucaşile", CityId = 74 },
                                                new District { DistrictId = 928, DName = "Ulus", CityId = 74 },
                                                new District { DistrictId = 929, DName = "Amasra", CityId = 74 },
                                                new District { DistrictId = 930, DName = "Ardahan Merkez", CityId = 75 },
                                                new District { DistrictId = 931, DName = "Çıldır", CityId = 75 },
                                                new District { DistrictId = 932, DName = "Göle", CityId = 75 },
                                                new District { DistrictId = 933, DName = "Hanak", CityId = 75 },
                                                new District { DistrictId = 934, DName = "Posof", CityId = 75 },
                                                new District { DistrictId = 935, DName = "Damal", CityId = 75 },
                                                new District { DistrictId = 936, DName = "Aralık", CityId = 76 },
                                                new District { DistrictId = 937, DName = "Iğdır Merkez", CityId = 76 },
                                                new District { DistrictId = 938, DName = "Tuzluca", CityId = 76 },
                                                new District { DistrictId = 939, DName = "Karakoyunlu", CityId = 76 },
                                                new District { DistrictId = 940, DName = "Yalova Merkez", CityId = 77 },
                                                new District { DistrictId = 941, DName = "Altınova", CityId = 77 },
                                                new District { DistrictId = 942, DName = "Armutlu", CityId = 77 },
                                                new District { DistrictId = 943, DName = "Çınarcık", CityId = 77 },
                                                new District { DistrictId = 944, DName = "Çiftlikköy", CityId = 77 },
                                                new District { DistrictId = 945, DName = "Termal", CityId = 77 },
                                                new District { DistrictId = 946, DName = "Eflani", CityId = 78 },
                                                new District { DistrictId = 947, DName = "Eskipazar", CityId = 78 },
                                                new District { DistrictId = 948, DName = "Karabük Merkez", CityId = 78 },
                                                new District { DistrictId = 949, DName = "Ovacık / Karabük", CityId = 78 },
                                                new District { DistrictId = 950, DName = "Safranbolu", CityId = 78 },
                                                new District { DistrictId = 951, DName = "Yenice / Karabük", CityId = 78 },
                                                new District { DistrictId = 952, DName = "Kilis Merkez", CityId = 79 },
                                                new District { DistrictId = 953, DName = "Elbeyli", CityId = 79 },
                                                new District { DistrictId = 954, DName = "Musabeyli", CityId = 79 },
                                                new District { DistrictId = 955, DName = "Polateli", CityId = 79 },
                                                new District { DistrictId = 956, DName = "Bahçe", CityId = 80 },
                                                new District { DistrictId = 957, DName = "Kadirli", CityId = 80 },
                                                new District { DistrictId = 958, DName = "Osmaniye Merkez", CityId = 80 },
                                                new District { DistrictId = 959, DName = "Düziçi", CityId = 80 },
                                                new District { DistrictId = 960, DName = "Hasanbeyli", CityId = 80 },
                                                new District { DistrictId = 961, DName = "Sumbas", CityId = 80 },
                                                new District { DistrictId = 962, DName = "Toprakkale", CityId = 80 },
                                                new District { DistrictId = 963, DName = "Akçakoca", CityId = 81 },
                                                new District { DistrictId = 964, DName = "Düzce Merkez", CityId = 81 },
                                                new District { DistrictId = 965, DName = "Yığılca", CityId = 81 },
                                                new District { DistrictId = 966, DName = "Cumayeri", CityId = 81 },
                                                new District { DistrictId = 967, DName = "Gölyaka", CityId = 81 },
                                                new District { DistrictId = 968, DName = "Çilimli", CityId = 81 },
                                                new District { DistrictId = 969, DName = "Gümüşova", CityId = 81 },
                                                new District { DistrictId = 970, DName = "Kaynaşlı", CityId = 81 }

                                                );
    }

}
