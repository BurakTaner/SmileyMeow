﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SmileyMeow.Data;

#nullable disable

namespace SmileyMeow.Migrations
{
    [DbContext(typeof(SmileyMeowDbContext))]
    [Migration("20221220135421_First")]
    partial class First
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("VetClinicLibrary.Appointmentt.Appointment", b =>
                {
                    b.Property<int>("PetnPersonId")
                        .HasColumnType("integer")
                        .HasColumnName("petnpersonid");

                    b.Property<int>("DoctorId")
                        .HasColumnType("integer")
                        .HasColumnName("doctorid");

                    b.Property<DateTime>("AppointmentDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("appointmentdate");

                    b.Property<DateTime>("TimeCreated")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("timecreated");

                    b.HasKey("PetnPersonId", "DoctorId")
                        .HasName("pk_appointments");

                    b.ToTable("appointments", (string)null);
                });

            modelBuilder.Entity("VetClinicLibrary.Appointmentt.PatientInformationn.PatientInformation", b =>
                {
                    b.Property<int>("PatientInformationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("patientinformationid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PatientInformationId"));

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<int>("EatingStatusId")
                        .HasColumnType("integer")
                        .HasColumnName("eatingstatusid");

                    b.Property<int>("EnergyStatusId")
                        .HasColumnType("integer")
                        .HasColumnName("energystatusid");

                    b.Property<int>("PeeingStatusId")
                        .HasColumnType("integer")
                        .HasColumnName("peeingstatusid");

                    b.HasKey("PatientInformationId")
                        .HasName("pk_patientinformations");

                    b.HasIndex("EatingStatusId")
                        .HasDatabaseName("ix_patientinformations_eatingstatusid");

                    b.HasIndex("EnergyStatusId")
                        .HasDatabaseName("ix_patientinformations_energystatusid");

                    b.HasIndex("PeeingStatusId")
                        .HasDatabaseName("ix_patientinformations_peeingstatusid");

                    b.ToTable("patientinformations", (string)null);
                });

            modelBuilder.Entity("VetClinicLibrary.Appointmentt.StatusLevell.StatusLevel", b =>
                {
                    b.Property<int>("StatusLevelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("statuslevelid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("StatusLevelId"));

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("StatusLevelId")
                        .HasName("pk_statuslevels");

                    b.ToTable("statuslevels", (string)null);
                });

            modelBuilder.Entity("VetClinicLibrary.Person.Balance", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("personid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PersonId"));

                    b.Property<decimal>("PersonBalance")
                        .HasColumnType("numeric")
                        .HasColumnName("personbalance");

                    b.HasKey("PersonId")
                        .HasName("pk_balances");

                    b.ToTable("balances", (string)null);
                });

            modelBuilder.Entity("VetClinicLibrary.Person.Doctor", b =>
                {
                    b.Property<int>("DoctorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("doctorid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("DoctorId"));

                    b.Property<string>("Address")
                        .HasColumnType("text")
                        .HasColumnName("address");

                    b.Property<int>("BalanceId")
                        .HasColumnType("integer")
                        .HasColumnName("balanceid");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("dob");

                    b.Property<string>("FirstName")
                        .HasColumnType("text")
                        .HasColumnName("firstname");

                    b.Property<string>("LastName")
                        .HasColumnType("text")
                        .HasColumnName("lastname");

                    b.Property<string>("MiddleName")
                        .HasColumnType("text")
                        .HasColumnName("middlename");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text")
                        .HasColumnName("phonenumber");

                    b.Property<int?>("SchoolId")
                        .HasColumnType("integer")
                        .HasColumnName("schoolid");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("userid");

                    b.Property<int?>("UserrId")
                        .HasColumnType("integer")
                        .HasColumnName("userrid");

                    b.HasKey("DoctorId")
                        .HasName("pk_doctors");

                    b.HasIndex("BalanceId")
                        .HasDatabaseName("ix_doctors_balanceid");

                    b.HasIndex("SchoolId")
                        .HasDatabaseName("ix_doctors_schoolid");

                    b.HasIndex("UserrId")
                        .HasDatabaseName("ix_doctors_userrid");

                    b.ToTable("doctors", (string)null);
                });

            modelBuilder.Entity("VetClinicLibrary.Person.PetParent", b =>
                {
                    b.Property<int>("PetParentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("petparentid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PetParentId"));

                    b.Property<string>("Address")
                        .HasColumnType("text")
                        .HasColumnName("address");

                    b.Property<int>("BalanceId")
                        .HasColumnType("integer")
                        .HasColumnName("balanceid");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("dob");

                    b.Property<string>("FirstName")
                        .HasColumnType("text")
                        .HasColumnName("firstname");

                    b.Property<string>("LastName")
                        .HasColumnType("text")
                        .HasColumnName("lastname");

                    b.Property<string>("MiddleName")
                        .HasColumnType("text")
                        .HasColumnName("middlename");

                    b.Property<int?>("PetAnimalId")
                        .HasColumnType("integer")
                        .HasColumnName("petanimalid");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text")
                        .HasColumnName("phonenumber");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("userid");

                    b.Property<int?>("UserrId")
                        .HasColumnType("integer")
                        .HasColumnName("userrid");

                    b.HasKey("PetParentId")
                        .HasName("pk_petparents");

                    b.HasIndex("BalanceId")
                        .HasDatabaseName("ix_petparents_balanceid");

                    b.HasIndex("PetAnimalId")
                        .HasDatabaseName("ix_petparents_petanimalid");

                    b.HasIndex("UserrId")
                        .HasDatabaseName("ix_petparents_userrid");

                    b.ToTable("petparents", (string)null);
                });

            modelBuilder.Entity("VetClinicLibrary.PetnPersonn.PetnPerson", b =>
                {
                    b.Property<int>("PetnPersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("petnpersonid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PetnPersonId"));

                    b.Property<int>("AnimalId")
                        .HasColumnType("integer")
                        .HasColumnName("animalid");

                    b.Property<int>("PetParentId")
                        .HasColumnType("integer")
                        .HasColumnName("petparentid");

                    b.HasKey("PetnPersonId")
                        .HasName("pk_petsnpersons");

                    b.ToTable("petsnpersons", (string)null);
                });

            modelBuilder.Entity("VetClinicLibrary.Pett.Adopt.AdoptInfo", b =>
                {
                    b.Property<int>("AnimalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("animalid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AnimalId"));

                    b.Property<string>("AdoptText")
                        .HasColumnType("text")
                        .HasColumnName("adopttext");

                    b.HasKey("AnimalId")
                        .HasName("pk_adoptinfos");

                    b.ToTable("adoptinfos", (string)null);
                });

            modelBuilder.Entity("VetClinicLibrary.Pett.Breedd.Breed", b =>
                {
                    b.Property<int>("BreedId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("breedid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("BreedId"));

                    b.Property<string>("BName")
                        .HasColumnType("text")
                        .HasColumnName("bname");

                    b.HasKey("BreedId")
                        .HasName("pk_breeds");

                    b.ToTable("breeds", (string)null);
                });

            modelBuilder.Entity("VetClinicLibrary.Pett.Gender.PetGender", b =>
                {
                    b.Property<int>("PetGenderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("petgenderid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PetGenderId"));

                    b.Property<string>("GName")
                        .HasColumnType("text")
                        .HasColumnName("gname");

                    b.HasKey("PetGenderId")
                        .HasName("pk_petgenders");

                    b.ToTable("petgenders", (string)null);
                });

            modelBuilder.Entity("VetClinicLibrary.Pett.Pet", b =>
                {
                    b.Property<int>("AnimalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("animalid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AnimalId"));

                    b.Property<int?>("AdoptionInfoAnimalId")
                        .HasColumnType("integer")
                        .HasColumnName("adoptioninfoanimalid");

                    b.Property<int>("BreedId")
                        .HasColumnType("integer")
                        .HasColumnName("breedid");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("dob");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<int?>("PatientİnformationPatientInformationId")
                        .HasColumnType("integer")
                        .HasColumnName("patientİnformationpatientinformationid");

                    b.Property<int>("PetGenderId")
                        .HasColumnType("integer")
                        .HasColumnName("petgenderid");

                    b.Property<int>("SpecieId")
                        .HasColumnType("integer")
                        .HasColumnName("specieid");

                    b.HasKey("AnimalId")
                        .HasName("pk_pets");

                    b.HasIndex("AdoptionInfoAnimalId")
                        .HasDatabaseName("ix_pets_adoptioninfoanimalid");

                    b.HasIndex("BreedId")
                        .HasDatabaseName("ix_pets_breedid");

                    b.HasIndex("PatientİnformationPatientInformationId")
                        .HasDatabaseName("ix_pets_patientİnformationpatientinformationid");

                    b.HasIndex("PetGenderId")
                        .HasDatabaseName("ix_pets_petgenderid");

                    b.HasIndex("SpecieId")
                        .HasDatabaseName("ix_pets_specieid");

                    b.ToTable("pets", (string)null);
                });

            modelBuilder.Entity("VetClinicLibrary.Pett.Speciee.Specie", b =>
                {
                    b.Property<int>("SpecieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("specieid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("SpecieId"));

                    b.Property<string>("SName")
                        .HasColumnType("text")
                        .HasColumnName("sname");

                    b.HasKey("SpecieId")
                        .HasName("pk_species");

                    b.ToTable("species", (string)null);
                });

            modelBuilder.Entity("VetClinicLibrary.SchoolTypee.SchoolType", b =>
                {
                    b.Property<int>("SchoolTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("schooltypeid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("SchoolTypeId"));

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("SchoolTypeId")
                        .HasName("pk_schooltype");

                    b.ToTable("schooltype", (string)null);
                });

            modelBuilder.Entity("VetClinicLibrary.Schooll.DoctorSchool", b =>
                {
                    b.Property<int>("DoctorId")
                        .HasColumnType("integer")
                        .HasColumnName("doctorid");

                    b.Property<int>("SchoolId")
                        .HasColumnType("integer")
                        .HasColumnName("schoolid");

                    b.HasKey("DoctorId", "SchoolId")
                        .HasName("pk_doctorschools");

                    b.ToTable("doctorschools", (string)null);
                });

            modelBuilder.Entity("VetClinicLibrary.Schooll.School", b =>
                {
                    b.Property<int>("SchoolId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("schoolid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("SchoolId"));

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<int>("SchoolTypeId")
                        .HasColumnType("integer")
                        .HasColumnName("schooltypeid");

                    b.HasKey("SchoolId")
                        .HasName("pk_school");

                    b.HasIndex("SchoolTypeId")
                        .HasDatabaseName("ix_school_schooltypeid");

                    b.ToTable("school", (string)null);
                });

            modelBuilder.Entity("VetClinicLibrary.User.Rolee", b =>
                {
                    b.Property<int>("RoleeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("roleeid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("RoleeId"));

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("RoleeId")
                        .HasName("pk_rolees");

                    b.ToTable("rolees", (string)null);
                });

            modelBuilder.Entity("VetClinicLibrary.User.Userr", b =>
                {
                    b.Property<int>("UserrId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("userrid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserrId"));

                    b.Property<string>("Email")
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("Password")
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.Property<string>("PasswordRepeat")
                        .HasColumnType("text")
                        .HasColumnName("passwordrepeat");

                    b.Property<int>("RoleeId")
                        .HasColumnType("integer")
                        .HasColumnName("roleeid");

                    b.HasKey("UserrId")
                        .HasName("pk_userrs");

                    b.HasIndex("RoleeId")
                        .HasDatabaseName("ix_userrs_roleeid");

                    b.ToTable("userrs", (string)null);
                });

            modelBuilder.Entity("VetClinicLibrary.Appointmentt.PatientInformationn.PatientInformation", b =>
                {
                    b.HasOne("VetClinicLibrary.Appointmentt.StatusLevell.StatusLevel", "EatingStatus")
                        .WithMany()
                        .HasForeignKey("EatingStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_patientinformations_statuslevels_eatingstatusid");

                    b.HasOne("VetClinicLibrary.Appointmentt.StatusLevell.StatusLevel", "EnergyStatus")
                        .WithMany()
                        .HasForeignKey("EnergyStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_patientinformations_statuslevels_energystatusid");

                    b.HasOne("VetClinicLibrary.Appointmentt.StatusLevell.StatusLevel", "PeeingStatus")
                        .WithMany()
                        .HasForeignKey("PeeingStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_patientinformations_statuslevels_peeingstatusid");

                    b.Navigation("EatingStatus");

                    b.Navigation("EnergyStatus");

                    b.Navigation("PeeingStatus");
                });

            modelBuilder.Entity("VetClinicLibrary.Person.Doctor", b =>
                {
                    b.HasOne("VetClinicLibrary.Person.Balance", "Balance")
                        .WithMany()
                        .HasForeignKey("BalanceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_doctors_balances_balanceid");

                    b.HasOne("VetClinicLibrary.Schooll.School", "School")
                        .WithMany()
                        .HasForeignKey("SchoolId")
                        .HasConstraintName("fk_doctors_school_schoolid");

                    b.HasOne("VetClinicLibrary.User.Userr", "Userr")
                        .WithMany()
                        .HasForeignKey("UserrId")
                        .HasConstraintName("fk_doctors_userrs_userrid");

                    b.Navigation("Balance");

                    b.Navigation("School");

                    b.Navigation("Userr");
                });

            modelBuilder.Entity("VetClinicLibrary.Person.PetParent", b =>
                {
                    b.HasOne("VetClinicLibrary.Person.Balance", "Balance")
                        .WithMany()
                        .HasForeignKey("BalanceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_petparents_balances_balanceid");

                    b.HasOne("VetClinicLibrary.Pett.Pet", null)
                        .WithMany("PetParents")
                        .HasForeignKey("PetAnimalId")
                        .HasConstraintName("fk_petparents_pets_pettempid");

                    b.HasOne("VetClinicLibrary.User.Userr", "Userr")
                        .WithMany()
                        .HasForeignKey("UserrId")
                        .HasConstraintName("fk_petparents_userrs_userrid");

                    b.Navigation("Balance");

                    b.Navigation("Userr");
                });

            modelBuilder.Entity("VetClinicLibrary.Pett.Pet", b =>
                {
                    b.HasOne("VetClinicLibrary.Pett.Adopt.AdoptInfo", "AdoptionInfo")
                        .WithMany("Pet")
                        .HasForeignKey("AdoptionInfoAnimalId")
                        .HasConstraintName("fk_pets_adoptinfos_adoptioninfotempid");

                    b.HasOne("VetClinicLibrary.Pett.Breedd.Breed", "Breed")
                        .WithMany("Pet")
                        .HasForeignKey("BreedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_pets_breeds_breedid");

                    b.HasOne("VetClinicLibrary.Appointmentt.PatientInformationn.PatientInformation", "Patientİnformation")
                        .WithMany()
                        .HasForeignKey("PatientİnformationPatientInformationId")
                        .HasConstraintName("fk_pets_patientinformations_patientİnformationpatientinformati~");

                    b.HasOne("VetClinicLibrary.Pett.Gender.PetGender", "PetGender")
                        .WithMany("Pet")
                        .HasForeignKey("PetGenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_pets_petgenders_petgenderid");

                    b.HasOne("VetClinicLibrary.Pett.Speciee.Specie", "Specie")
                        .WithMany("Pet")
                        .HasForeignKey("SpecieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_pets_species_specieid");

                    b.Navigation("AdoptionInfo");

                    b.Navigation("Breed");

                    b.Navigation("Patientİnformation");

                    b.Navigation("PetGender");

                    b.Navigation("Specie");
                });

            modelBuilder.Entity("VetClinicLibrary.Schooll.School", b =>
                {
                    b.HasOne("VetClinicLibrary.SchoolTypee.SchoolType", "SchoolType")
                        .WithMany()
                        .HasForeignKey("SchoolTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_school_schooltype_schooltypeid");

                    b.Navigation("SchoolType");
                });

            modelBuilder.Entity("VetClinicLibrary.User.Userr", b =>
                {
                    b.HasOne("VetClinicLibrary.User.Rolee", "Rolee")
                        .WithMany()
                        .HasForeignKey("RoleeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_userrs_rolees_roleeid");

                    b.Navigation("Rolee");
                });

            modelBuilder.Entity("VetClinicLibrary.Pett.Adopt.AdoptInfo", b =>
                {
                    b.Navigation("Pet");
                });

            modelBuilder.Entity("VetClinicLibrary.Pett.Breedd.Breed", b =>
                {
                    b.Navigation("Pet");
                });

            modelBuilder.Entity("VetClinicLibrary.Pett.Gender.PetGender", b =>
                {
                    b.Navigation("Pet");
                });

            modelBuilder.Entity("VetClinicLibrary.Pett.Pet", b =>
                {
                    b.Navigation("PetParents");
                });

            modelBuilder.Entity("VetClinicLibrary.Pett.Speciee.Specie", b =>
                {
                    b.Navigation("Pet");
                });
#pragma warning restore 612, 618
        }
    }
}
