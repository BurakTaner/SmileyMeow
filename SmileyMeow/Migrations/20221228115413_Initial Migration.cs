using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmileyMeow.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "appointmentstatus",
                columns: table => new
                {
                    appointmentstatussid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    status = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_appointmentstatus", x => x.appointmentstatussid);
                });

            migrationBuilder.CreateTable(
                name: "balances",
                columns: table => new
                {
                    balanceid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    personbalance = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_balances", x => x.balanceid);
                });

            migrationBuilder.CreateTable(
                name: "breeds",
                columns: table => new
                {
                    breedid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    bname = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_breeds", x => x.breedid);
                });

            migrationBuilder.CreateTable(
                name: "doctorschools",
                columns: table => new
                {
                    doctorid = table.Column<int>(type: "integer", nullable: false),
                    schoolid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_doctorschools", x => new { x.doctorid, x.schoolid });
                });

            migrationBuilder.CreateTable(
                name: "doctortitles",
                columns: table => new
                {
                    doctortitleid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tfullform = table.Column<string>(type: "text", nullable: true),
                    tshortform = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_doctortitles", x => x.doctortitleid);
                });

            migrationBuilder.CreateTable(
                name: "humangender",
                columns: table => new
                {
                    humangenderid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    gname = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_humangender", x => x.humangenderid);
                });

            migrationBuilder.CreateTable(
                name: "petgenders",
                columns: table => new
                {
                    petgenderid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    gname = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_petgenders", x => x.petgenderid);
                });

            migrationBuilder.CreateTable(
                name: "pronouns",
                columns: table => new
                {
                    prounounid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    pname = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_pronouns", x => x.prounounid);
                });

            migrationBuilder.CreateTable(
                name: "rolees",
                columns: table => new
                {
                    roleeid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_rolees", x => x.roleeid);
                });

            migrationBuilder.CreateTable(
                name: "schooltype",
                columns: table => new
                {
                    schooltypeid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_schooltype", x => x.schooltypeid);
                });

            migrationBuilder.CreateTable(
                name: "species",
                columns: table => new
                {
                    specieid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    sname = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_species", x => x.specieid);
                });

            migrationBuilder.CreateTable(
                name: "statuslevels",
                columns: table => new
                {
                    statuslevelid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_statuslevels", x => x.statuslevelid);
                });

            migrationBuilder.CreateTable(
                name: "userrs",
                columns: table => new
                {
                    userrid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    email = table.Column<string>(type: "text", nullable: true),
                    password = table.Column<string>(type: "text", nullable: true),
                    roleeid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_userrs", x => x.userrid);
                    table.ForeignKey(
                        name: "fk_userrs_rolees_roleeid",
                        column: x => x.roleeid,
                        principalTable: "rolees",
                        principalColumn: "roleeid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "school",
                columns: table => new
                {
                    schoolid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    schooltypeid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_school", x => x.schoolid);
                    table.ForeignKey(
                        name: "fk_school_schooltype_schooltypeid",
                        column: x => x.schooltypeid,
                        principalTable: "schooltype",
                        principalColumn: "schooltypeid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "petparents",
                columns: table => new
                {
                    petparentid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    firstname = table.Column<string>(type: "text", nullable: true),
                    middlename = table.Column<string>(type: "text", nullable: true),
                    lastname = table.Column<string>(type: "text", nullable: true),
                    dob = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    humangenderid = table.Column<int>(type: "integer", nullable: false),
                    phonenumber = table.Column<string>(type: "text", nullable: true),
                    userid = table.Column<int>(type: "integer", nullable: false),
                    balanceid = table.Column<int>(type: "integer", nullable: false),
                    pronounid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_petparents", x => x.petparentid);
                    table.ForeignKey(
                        name: "fk_petparents_balances_balanceid",
                        column: x => x.balanceid,
                        principalTable: "balances",
                        principalColumn: "balanceid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_petparents_humangender_humangenderid",
                        column: x => x.humangenderid,
                        principalTable: "humangender",
                        principalColumn: "humangenderid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_petparents_pronouns_pronounid",
                        column: x => x.pronounid,
                        principalTable: "pronouns",
                        principalColumn: "prounounid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_petparents_userrs_userrid",
                        column: x => x.userid,
                        principalTable: "userrs",
                        principalColumn: "userrid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "doctors",
                columns: table => new
                {
                    doctorid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    firstname = table.Column<string>(type: "text", nullable: true),
                    middlename = table.Column<string>(type: "text", nullable: true),
                    lastname = table.Column<string>(type: "text", nullable: true),
                    dob = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    humangenderid = table.Column<int>(type: "integer", nullable: false),
                    phonenumber = table.Column<string>(type: "text", nullable: true),
                    userid = table.Column<int>(type: "integer", nullable: false),
                    balanceid = table.Column<int>(type: "integer", nullable: false),
                    schoolid = table.Column<int>(type: "integer", nullable: true),
                    doctortitleid = table.Column<int>(type: "integer", nullable: false),
                    pronounid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_doctors", x => x.doctorid);
                    table.ForeignKey(
                        name: "fk_doctors_balances_balanceid",
                        column: x => x.balanceid,
                        principalTable: "balances",
                        principalColumn: "balanceid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_doctors_doctortitles_doctortitleid",
                        column: x => x.doctortitleid,
                        principalTable: "doctortitles",
                        principalColumn: "doctortitleid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_doctors_humangender_humangenderid",
                        column: x => x.humangenderid,
                        principalTable: "humangender",
                        principalColumn: "humangenderid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_doctors_pronouns_pronounid",
                        column: x => x.pronounid,
                        principalTable: "pronouns",
                        principalColumn: "prounounid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_doctors_school_schoolid",
                        column: x => x.schoolid,
                        principalTable: "school",
                        principalColumn: "schoolid");
                    table.ForeignKey(
                        name: "fk_doctors_userrs_userrid",
                        column: x => x.userid,
                        principalTable: "userrs",
                        principalColumn: "userrid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "doctorinfos",
                columns: table => new
                {
                    doctorid = table.Column<int>(type: "integer", nullable: false),
                    doctorinformation = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_doctorinfos", x => x.doctorid);
                    table.ForeignKey(
                        name: "fk_doctorinfos_doctors_doctorid",
                        column: x => x.doctorid,
                        principalTable: "doctors",
                        principalColumn: "doctorid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "adoptinfos",
                columns: table => new
                {
                    adoptinfoid = table.Column<int>(type: "integer", nullable: false),
                    adopttext = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_adoptinfos", x => x.adoptinfoid);
                });

            migrationBuilder.CreateTable(
                name: "appointments",
                columns: table => new
                {
                    petnpersonid = table.Column<int>(type: "integer", nullable: false),
                    doctorid = table.Column<int>(type: "integer", nullable: false),
                    timecreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    appointmentdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    appointmentstatussid = table.Column<int>(type: "integer", nullable: false),
                    doctorpreferenceid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_appointments", x => new { x.petnpersonid, x.doctorid });
                    table.ForeignKey(
                        name: "fk_appointments_appointmentstatus_appointmentstatustempid",
                        column: x => x.appointmentstatussid,
                        principalTable: "appointmentstatus",
                        principalColumn: "appointmentstatussid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_appointments_doctors_doctorid",
                        column: x => x.doctorid,
                        principalTable: "doctors",
                        principalColumn: "doctorid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_appointments_doctors_doctorpreferenceid",
                        column: x => x.doctorpreferenceid,
                        principalTable: "doctors",
                        principalColumn: "doctorid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "patientinformations",
                columns: table => new
                {
                    patientinformationid = table.Column<int>(type: "integer", nullable: false),
                    eatingstatusid = table.Column<int>(type: "integer", nullable: false),
                    peeingstatusid = table.Column<int>(type: "integer", nullable: false),
                    energystatusid = table.Column<int>(type: "integer", nullable: false),
                    informationaboutpatient = table.Column<string>(type: "text", nullable: true),
                    ilnesssesinthepast = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_patientinformations", x => x.patientinformationid);
                    table.ForeignKey(
                        name: "fk_patientinformations_statuslevels_eatingstatusid",
                        column: x => x.eatingstatusid,
                        principalTable: "statuslevels",
                        principalColumn: "statuslevelid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_patientinformations_statuslevels_energystatusid",
                        column: x => x.energystatusid,
                        principalTable: "statuslevels",
                        principalColumn: "statuslevelid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_patientinformations_statuslevels_peeingstatusid",
                        column: x => x.peeingstatusid,
                        principalTable: "statuslevels",
                        principalColumn: "statuslevelid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pets",
                columns: table => new
                {
                    animalid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    dob = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    petgenderid = table.Column<int>(type: "integer", nullable: false),
                    specieid = table.Column<int>(type: "integer", nullable: false),
                    breedid = table.Column<int>(type: "integer", nullable: false),
                    patientİnformationpatientinformationid = table.Column<int>(type: "integer", nullable: true),
                    adoptinfoid = table.Column<int>(type: "integer", nullable: false),
                    isadoptable = table.Column<bool>(type: "boolean", nullable: false),
                    patientinformationid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_pets", x => x.animalid);
                    table.ForeignKey(
                        name: "fk_pets_breeds_breedid",
                        column: x => x.breedid,
                        principalTable: "breeds",
                        principalColumn: "breedid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_pets_patientinformations_patientİnformationpatientinformati~",
                        column: x => x.patientİnformationpatientinformationid,
                        principalTable: "patientinformations",
                        principalColumn: "patientinformationid");
                    table.ForeignKey(
                        name: "fk_pets_petgenders_petgenderid",
                        column: x => x.petgenderid,
                        principalTable: "petgenders",
                        principalColumn: "petgenderid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_pets_species_specieid",
                        column: x => x.specieid,
                        principalTable: "species",
                        principalColumn: "specieid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "petsnpersons",
                columns: table => new
                {
                    petnpersonid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    petparentid = table.Column<int>(type: "integer", nullable: false),
                    animalid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_petsnpersons", x => x.petnpersonid);
                    table.ForeignKey(
                        name: "fk_petsnpersons_petparents_petparentid",
                        column: x => x.petparentid,
                        principalTable: "petparents",
                        principalColumn: "petparentid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_petsnpersons_pets_pettempid1",
                        column: x => x.animalid,
                        principalTable: "pets",
                        principalColumn: "animalid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "appointmentstatus",
                columns: new[] { "appointmentstatussid", "status" },
                values: new object[,]
                {
                    { 6, "Active Appointment" },
                    { 7, "Expired Appointment" },
                    { 8, "Canceled Appointment" }
                });

            migrationBuilder.InsertData(
                table: "balances",
                columns: new[] { "balanceid", "personbalance" },
                values: new object[,]
                {
                    { 6, 150.55m },
                    { 666, 90.65m }
                });

            migrationBuilder.InsertData(
                table: "breeds",
                columns: new[] { "breedid", "bname" },
                values: new object[] { 6, "Ragdoll" });

            migrationBuilder.InsertData(
                table: "doctorschools",
                columns: new[] { "doctorid", "schoolid" },
                values: new object[] { 6, 6 });

            migrationBuilder.InsertData(
                table: "doctortitles",
                columns: new[] { "doctortitleid", "tfullform", "tshortform" },
                values: new object[] { 6, "Vetenerian", "DVM" });

            migrationBuilder.InsertData(
                table: "humangender",
                columns: new[] { "humangenderid", "gname" },
                values: new object[,]
                {
                    { 6, "Non-Binary" },
                    { 66, "Genderfluid" }
                });

            migrationBuilder.InsertData(
                table: "petgenders",
                columns: new[] { "petgenderid", "gname" },
                values: new object[] { 6, "Female" });

            migrationBuilder.InsertData(
                table: "pronouns",
                columns: new[] { "prounounid", "pname" },
                values: new object[] { 6, "They/Them" });

            migrationBuilder.InsertData(
                table: "rolees",
                columns: new[] { "roleeid", "name" },
                values: new object[,]
                {
                    { 6, "PetParent" },
                    { 666, "Doctor" }
                });

            migrationBuilder.InsertData(
                table: "schooltype",
                columns: new[] { "schooltypeid", "name" },
                values: new object[] { 6, "University" });

            migrationBuilder.InsertData(
                table: "species",
                columns: new[] { "specieid", "sname" },
                values: new object[] { 6, "Wolf" });

            migrationBuilder.InsertData(
                table: "statuslevels",
                columns: new[] { "statuslevelid", "name" },
                values: new object[,]
                {
                    { 1, "Good" },
                    { 2, "Middle" },
                    { 3, "Bad" }
                });

            migrationBuilder.InsertData(
                table: "pets",
                columns: new[] { "animalid", "adoptinfoid", "breedid", "dob", "isadoptable", "name", "patientinformationid", "patientİnformationpatientinformationid", "petgenderid", "specieid" },
                values: new object[] { 6, 6, 6, new DateTime(2022, 12, 28, 14, 54, 12, 240, DateTimeKind.Local).AddTicks(7429), true, "Sif", 6, null, 6, 6 });

            migrationBuilder.InsertData(
                table: "school",
                columns: new[] { "schoolid", "name", "schooltypeid" },
                values: new object[] { 6, "University of California, Davis", 6 });

            migrationBuilder.InsertData(
                table: "userrs",
                columns: new[] { "userrid", "email", "password", "roleeid" },
                values: new object[,]
                {
                    { 6, "artorias@gmail.com", "sif123456", 6 },
                    { 666, "patches@gmail.com", "patches123456", 666 }
                });

            migrationBuilder.InsertData(
                table: "adoptinfos",
                columns: new[] { "adoptinfoid", "adopttext" },
                values: new object[] { 6, "So cute" });

            migrationBuilder.InsertData(
                table: "doctors",
                columns: new[] { "doctorid", "balanceid", "dob", "doctortitleid", "firstname", "humangenderid", "lastname", "middlename", "phonenumber", "pronounid", "schoolid", "userid" },
                values: new object[] { 6, 666, new DateTime(1978, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Patches", 66, "Whisper", null, "05434561275", 6, null, 666 });

            migrationBuilder.InsertData(
                table: "patientinformations",
                columns: new[] { "patientinformationid", "eatingstatusid", "energystatusid", "ilnesssesinthepast", "informationaboutpatient", "peeingstatusid" },
                values: new object[] { 6, 2, 1, "Sif is a 3-year-old wolf who had a case of mange a year ago, which was treated with medicated baths and topical ointments. She also developed an ear infection a few months ago, which was treated with antibiotics and ear drops. In the past, Sif has also had some minor digestive issues that we've been able to resolve with diet and supplement changes.", "My wolf Sif has been eating fine and her energy levels are good, but she has been having trouble with her peeing. She's been going more frequently and sometimes it seems like it's painful for her. I'm really concerned because she's usually such a healthy wolf.", 3 });

            migrationBuilder.InsertData(
                table: "petparents",
                columns: new[] { "petparentid", "balanceid", "dob", "firstname", "humangenderid", "lastname", "middlename", "phonenumber", "pronounid", "userid" },
                values: new object[] { 6, 6, new DateTime(1999, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Artorias", 6, "Astora", "Solaire", null, 6, 6 });

            migrationBuilder.InsertData(
                table: "doctorinfos",
                columns: new[] { "doctorid", "doctorinformation" },
                values: new object[] { 6, "Hi, I am Dr. Patches, a veterinarian with over 10 years of experience in the field. I received my Doctor of Veterinary Medicine degree from the University of California, Davis and have since worked at a variety of clinics, caring for all types of animals and their petparents. My specialty is in small animal medicine, but I am well-versed in treating all kinds of creatures, from cats and dogs to birds and reptiles. I am passionate about helping animals and their owners, and take pride in being able to diagnose and treat a wide range of conditions. In my free time, I enjoy volunteering at local animal shelters and spending time with my own pets, which include a rescue dog and two cats. I believe that effective communication with petparents is crucial in providing the best care for their beloved animals." });

            migrationBuilder.InsertData(
                table: "petsnpersons",
                columns: new[] { "petnpersonid", "animalid", "petparentid" },
                values: new object[] { 6, 6, 6 });

            migrationBuilder.InsertData(
                table: "appointments",
                columns: new[] { "doctorid", "petnpersonid", "appointmentdate", "appointmentstatussid", "doctorpreferenceid", "timecreated" },
                values: new object[] { 6, 6, new DateTime(2023, 1, 27, 14, 54, 12, 240, DateTimeKind.Local).AddTicks(8107), 6, 6, new DateTime(2022, 12, 28, 14, 54, 12, 240, DateTimeKind.Local).AddTicks(8103) });

            migrationBuilder.CreateIndex(
                name: "ix_appointments_appointmentstatussid",
                table: "appointments",
                column: "appointmentstatussid");

            migrationBuilder.CreateIndex(
                name: "ix_appointments_doctorid",
                table: "appointments",
                column: "doctorid");

            migrationBuilder.CreateIndex(
                name: "ix_appointments_doctorpreferenceid",
                table: "appointments",
                column: "doctorpreferenceid");

            migrationBuilder.CreateIndex(
                name: "ix_doctors_balanceid",
                table: "doctors",
                column: "balanceid");

            migrationBuilder.CreateIndex(
                name: "ix_doctors_doctortitleid",
                table: "doctors",
                column: "doctortitleid");

            migrationBuilder.CreateIndex(
                name: "ix_doctors_humangenderid",
                table: "doctors",
                column: "humangenderid");

            migrationBuilder.CreateIndex(
                name: "ix_doctors_pronounid",
                table: "doctors",
                column: "pronounid");

            migrationBuilder.CreateIndex(
                name: "ix_doctors_schoolid",
                table: "doctors",
                column: "schoolid");

            migrationBuilder.CreateIndex(
                name: "ix_doctors_userid",
                table: "doctors",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "ix_patientinformations_eatingstatusid",
                table: "patientinformations",
                column: "eatingstatusid");

            migrationBuilder.CreateIndex(
                name: "ix_patientinformations_energystatusid",
                table: "patientinformations",
                column: "energystatusid");

            migrationBuilder.CreateIndex(
                name: "ix_patientinformations_peeingstatusid",
                table: "patientinformations",
                column: "peeingstatusid");

            migrationBuilder.CreateIndex(
                name: "ix_petparents_balanceid",
                table: "petparents",
                column: "balanceid");

            migrationBuilder.CreateIndex(
                name: "ix_petparents_humangenderid",
                table: "petparents",
                column: "humangenderid");

            migrationBuilder.CreateIndex(
                name: "ix_petparents_pronounid",
                table: "petparents",
                column: "pronounid");

            migrationBuilder.CreateIndex(
                name: "ix_petparents_userid",
                table: "petparents",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "ix_pets_breedid",
                table: "pets",
                column: "breedid");

            migrationBuilder.CreateIndex(
                name: "ix_pets_patientİnformationpatientinformationid",
                table: "pets",
                column: "patientİnformationpatientinformationid");

            migrationBuilder.CreateIndex(
                name: "ix_pets_petgenderid",
                table: "pets",
                column: "petgenderid");

            migrationBuilder.CreateIndex(
                name: "ix_pets_specieid",
                table: "pets",
                column: "specieid");

            migrationBuilder.CreateIndex(
                name: "ix_petsnpersons_animalid",
                table: "petsnpersons",
                column: "animalid");

            migrationBuilder.CreateIndex(
                name: "ix_petsnpersons_petparentid",
                table: "petsnpersons",
                column: "petparentid");

            migrationBuilder.CreateIndex(
                name: "ix_school_schooltypeid",
                table: "school",
                column: "schooltypeid");

            migrationBuilder.CreateIndex(
                name: "ix_userrs_roleeid",
                table: "userrs",
                column: "roleeid");

            migrationBuilder.AddForeignKey(
                name: "fk_adoptinfos_pets_adoptinfoid",
                table: "adoptinfos",
                column: "adoptinfoid",
                principalTable: "pets",
                principalColumn: "animalid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_appointments_petsnpersons_petnpersonid",
                table: "appointments",
                column: "petnpersonid",
                principalTable: "petsnpersons",
                principalColumn: "petnpersonid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_patientinformations_pets_patientinformationid",
                table: "patientinformations",
                column: "patientinformationid",
                principalTable: "pets",
                principalColumn: "animalid",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_patientinformations_pets_patientinformationid",
                table: "patientinformations");

            migrationBuilder.DropTable(
                name: "adoptinfos");

            migrationBuilder.DropTable(
                name: "appointments");

            migrationBuilder.DropTable(
                name: "doctorinfos");

            migrationBuilder.DropTable(
                name: "doctorschools");

            migrationBuilder.DropTable(
                name: "appointmentstatus");

            migrationBuilder.DropTable(
                name: "petsnpersons");

            migrationBuilder.DropTable(
                name: "doctors");

            migrationBuilder.DropTable(
                name: "petparents");

            migrationBuilder.DropTable(
                name: "doctortitles");

            migrationBuilder.DropTable(
                name: "school");

            migrationBuilder.DropTable(
                name: "balances");

            migrationBuilder.DropTable(
                name: "humangender");

            migrationBuilder.DropTable(
                name: "pronouns");

            migrationBuilder.DropTable(
                name: "userrs");

            migrationBuilder.DropTable(
                name: "schooltype");

            migrationBuilder.DropTable(
                name: "rolees");

            migrationBuilder.DropTable(
                name: "pets");

            migrationBuilder.DropTable(
                name: "breeds");

            migrationBuilder.DropTable(
                name: "patientinformations");

            migrationBuilder.DropTable(
                name: "petgenders");

            migrationBuilder.DropTable(
                name: "species");

            migrationBuilder.DropTable(
                name: "statuslevels");
        }
    }
}
