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
                name: "appointmentstatuses",
                columns: table => new
                {
                    appointmentstatussid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    status = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_appointmentstatuses", x => x.appointmentstatussid);
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
                name: "city",
                columns: table => new
                {
                    cityid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cname = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_city", x => x.cityid);
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
                name: "district",
                columns: table => new
                {
                    districtid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    dname = table.Column<string>(type: "text", nullable: true),
                    cityid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_district", x => x.districtid);
                    table.ForeignKey(
                        name: "fk_district_city_cityid",
                        column: x => x.cityid,
                        principalTable: "city",
                        principalColumn: "cityid",
                        onDelete: ReferentialAction.Cascade);
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
                name: "patientinformations",
                columns: table => new
                {
                    patientinformationid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
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
                name: "addresses",
                columns: table => new
                {
                    addressid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    districtid = table.Column<int>(type: "integer", nullable: false),
                    addressdetails = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_addresses", x => x.addressid);
                    table.ForeignKey(
                        name: "fk_addresses_district_districtid",
                        column: x => x.districtid,
                        principalTable: "district",
                        principalColumn: "districtid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "notuserparentspet",
                columns: table => new
                {
                    animalid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    dob = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    petgenderid = table.Column<int>(type: "integer", nullable: false),
                    specieid = table.Column<int>(type: "integer", nullable: false),
                    breedid = table.Column<int>(type: "integer", nullable: false),
                    patientinformationid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_notuserparentspet", x => x.animalid);
                    table.ForeignKey(
                        name: "fk_notuserparentspet_breeds_breedid",
                        column: x => x.breedid,
                        principalTable: "breeds",
                        principalColumn: "breedid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_notuserparentspet_patientinformations_patientinformationid",
                        column: x => x.patientinformationid,
                        principalTable: "patientinformations",
                        principalColumn: "patientinformationid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_notuserparentspet_petgenders_petgenderid",
                        column: x => x.petgenderid,
                        principalTable: "petgenders",
                        principalColumn: "petgenderid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_notuserparentspet_species_specieid",
                        column: x => x.specieid,
                        principalTable: "species",
                        principalColumn: "specieid",
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
                        name: "fk_pets_patientinformations_patientinformationid",
                        column: x => x.patientinformationid,
                        principalTable: "patientinformations",
                        principalColumn: "patientinformationid",
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
                    pronounid = table.Column<int>(type: "integer", nullable: false),
                    addressid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_doctors", x => x.doctorid);
                    table.ForeignKey(
                        name: "fk_doctors_addresses_addressid",
                        column: x => x.addressid,
                        principalTable: "addresses",
                        principalColumn: "addressid",
                        onDelete: ReferentialAction.Cascade);
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
                name: "notuserparents",
                columns: table => new
                {
                    notuserparentid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    firstname = table.Column<string>(type: "text", nullable: true),
                    middlename = table.Column<string>(type: "text", nullable: true),
                    lastname = table.Column<string>(type: "text", nullable: true),
                    phonenumber = table.Column<string>(type: "text", nullable: true),
                    email = table.Column<string>(type: "text", nullable: true),
                    addressid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_notuserparents", x => x.notuserparentid);
                    table.ForeignKey(
                        name: "fk_notuserparents_addresses_addressid",
                        column: x => x.addressid,
                        principalTable: "addresses",
                        principalColumn: "addressid",
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
                    pronounid = table.Column<int>(type: "integer", nullable: false),
                    addressid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_petparents", x => x.petparentid);
                    table.ForeignKey(
                        name: "fk_petparents_addresses_addressid",
                        column: x => x.addressid,
                        principalTable: "addresses",
                        principalColumn: "addressid",
                        onDelete: ReferentialAction.Cascade);
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
                name: "adoptinfos",
                columns: table => new
                {
                    adoptinfoid = table.Column<int>(type: "integer", nullable: false),
                    adopttext = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_adoptinfos", x => x.adoptinfoid);
                    table.ForeignKey(
                        name: "fk_adoptinfos_pets_adoptinfoid",
                        column: x => x.adoptinfoid,
                        principalTable: "pets",
                        principalColumn: "animalid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "doctorinformations",
                columns: table => new
                {
                    doctorid = table.Column<int>(type: "integer", nullable: false),
                    doctorinformationtext = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_doctorinformations", x => x.doctorid);
                    table.ForeignKey(
                        name: "fk_doctorinformations_doctors_doctorid",
                        column: x => x.doctorid,
                        principalTable: "doctors",
                        principalColumn: "doctorid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "notuserparentnpet",
                columns: table => new
                {
                    notuserparenpetid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    notuserparentid = table.Column<int>(type: "integer", nullable: false),
                    animalid = table.Column<int>(type: "integer", nullable: false),
                    notuserparentspetanimalid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_notuserparentnpet", x => x.notuserparenpetid);
                    table.ForeignKey(
                        name: "fk_notuserparentnpet_notuserparents_notuserparentid",
                        column: x => x.notuserparentid,
                        principalTable: "notuserparents",
                        principalColumn: "notuserparentid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_notuserparentnpet_notuserparentspet_notuserparentspettempid",
                        column: x => x.notuserparentspetanimalid,
                        principalTable: "notuserparentspet",
                        principalColumn: "animalid");
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

            migrationBuilder.CreateTable(
                name: "notuserappointments",
                columns: table => new
                {
                    appointmentid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    notuserparentnpersonid = table.Column<int>(type: "integer", nullable: false),
                    notuserparentnpetnotuserparenpetid = table.Column<int>(type: "integer", nullable: true),
                    doctorid = table.Column<int>(type: "integer", nullable: false),
                    timecreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    appointmentdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    appointmentstatussid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_notuserappointments", x => x.appointmentid);
                    table.ForeignKey(
                        name: "fk_notuserappointments_appointmentstatuses_appointmentstatuste~",
                        column: x => x.appointmentstatussid,
                        principalTable: "appointmentstatuses",
                        principalColumn: "appointmentstatussid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_notuserappointments_doctors_doctorid",
                        column: x => x.doctorid,
                        principalTable: "doctors",
                        principalColumn: "doctorid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_notuserappointments_notuserparentnpet_notuserparentnpettemp~",
                        column: x => x.notuserparentnpetnotuserparenpetid,
                        principalTable: "notuserparentnpet",
                        principalColumn: "notuserparenpetid");
                });

            migrationBuilder.CreateTable(
                name: "appointments",
                columns: table => new
                {
                    appointmentid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    petnpersonid = table.Column<int>(type: "integer", nullable: false),
                    doctorid = table.Column<int>(type: "integer", nullable: false),
                    timecreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    appointmentdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    appointmentstatussid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_appointments", x => x.appointmentid);
                    table.ForeignKey(
                        name: "fk_appointments_appointmentstatuses_appointmentstatustempid",
                        column: x => x.appointmentstatussid,
                        principalTable: "appointmentstatuses",
                        principalColumn: "appointmentstatussid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_appointments_doctors_doctorid",
                        column: x => x.doctorid,
                        principalTable: "doctors",
                        principalColumn: "doctorid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_appointments_petsnpersons_petnpersonid",
                        column: x => x.petnpersonid,
                        principalTable: "petsnpersons",
                        principalColumn: "petnpersonid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "appointmentstatuses",
                columns: new[] { "appointmentstatussid", "status" },
                values: new object[,]
                {
                    { 6, "Active Appointment" },
                    { 7, "Expired Appointment" },
                    { 8, "Canceled Appointment" },
                    { 10, "Finished Appointment" }
                });

            migrationBuilder.InsertData(
                table: "balances",
                columns: new[] { "balanceid", "personbalance" },
                values: new object[,]
                {
                    { 6, 150.55m },
                    { 128, 128.25m },
                    { 666, 90.65m }
                });

            migrationBuilder.InsertData(
                table: "breeds",
                columns: new[] { "breedid", "bname" },
                values: new object[,]
                {
                    { 6, "Ragdoll" },
                    { 9, "Appaloosa" }
                });

            migrationBuilder.InsertData(
                table: "city",
                columns: new[] { "cityid", "cname" },
                values: new object[,]
                {
                    { 1, "Adana" },
                    { 2, "Adıyaman" },
                    { 3, "Afyonkarahisar" },
                    { 4, "Ağrı" },
                    { 5, "Amasya" },
                    { 6, "Ankara" },
                    { 7, "Antalya" },
                    { 8, "Artvin" },
                    { 9, "Aydın" },
                    { 10, "Balıkesir" },
                    { 11, "Bilecik" },
                    { 12, "Bingöl" },
                    { 13, "Bitlis" },
                    { 14, "Bolu" },
                    { 15, "Burdur" },
                    { 16, "Bursa" },
                    { 17, "Çanakkale" },
                    { 18, "Çankırı" },
                    { 19, "Çorum" },
                    { 20, "Denizli" },
                    { 21, "Diyarbakır" },
                    { 22, "Edirne" },
                    { 23, "Elazığ" },
                    { 24, "Erzincan" },
                    { 25, "Erzurum" },
                    { 26, "Eskişehir" },
                    { 27, "Gaziantep" },
                    { 28, "Giresun" },
                    { 29, "Gümüşhane" },
                    { 30, "Hakkari" },
                    { 31, "Hatay" },
                    { 32, "Isparta" },
                    { 33, "Mersin" },
                    { 34, "İstanbul" },
                    { 35, "İzmir" },
                    { 36, "Kars" },
                    { 37, "Kastamonu" },
                    { 38, "Kayseri" },
                    { 39, "Kırklareli" },
                    { 40, "Kırşehir" },
                    { 41, "Kocaeli" },
                    { 42, "Konya" },
                    { 43, "Kütahya" },
                    { 44, "Malatya" },
                    { 45, "Manisa" },
                    { 46, "Kahramanmaraş" },
                    { 47, "Mardin" },
                    { 48, "Muğla" },
                    { 49, "Muş" },
                    { 50, "Nevşehir" },
                    { 51, "Niğde" },
                    { 52, "Ordu" },
                    { 53, "Rize" },
                    { 54, "Sakarya" },
                    { 55, "Samsun" },
                    { 56, "Siirt" },
                    { 57, "Sinop" },
                    { 58, "Sivas" },
                    { 59, "Tekirdağ" },
                    { 60, "Tokat" },
                    { 61, "Trabzon" },
                    { 62, "Tunceli" },
                    { 63, "Şanlıurfa" },
                    { 64, "Uşak" },
                    { 65, "Van" },
                    { 66, "Yozgat" },
                    { 67, "Zonguldak" },
                    { 68, "Aksaray" },
                    { 69, "Bayburt" },
                    { 70, "Karaman" },
                    { 71, "Kırıkkale" },
                    { 72, "Batman" },
                    { 73, "Şırnak" },
                    { 74, "Bartın" },
                    { 75, "Ardahan" },
                    { 76, "Iğdır" },
                    { 77, "Yalova" },
                    { 78, "Karabük" },
                    { 79, "Kilis" },
                    { 80, "Osmaniye" },
                    { 81, "Düzce" }
                });

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
                    { 66, "Genderfluid" },
                    { 128, "Female" }
                });

            migrationBuilder.InsertData(
                table: "petgenders",
                columns: new[] { "petgenderid", "gname" },
                values: new object[,]
                {
                    { 6, "Female" },
                    { 9, "Male (neutralized)" }
                });

            migrationBuilder.InsertData(
                table: "pronouns",
                columns: new[] { "prounounid", "pname" },
                values: new object[,]
                {
                    { 6, "They/Them" },
                    { 9, "She/Her" }
                });

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
                values: new object[,]
                {
                    { 6, "Wolf" },
                    { 9, "Horse" }
                });

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
                table: "district",
                columns: new[] { "districtid", "cityid", "dname" },
                values: new object[,]
                {
                    { 1, 1, "Seyhan" },
                    { 2, 1, "Ceyhan" },
                    { 3, 1, "Feke" },
                    { 4, 1, "Karaisalı" },
                    { 5, 1, "Karataş" },
                    { 6, 1, "Kozan" },
                    { 7, 1, "Pozantı" },
                    { 8, 1, "Saimbeyli" },
                    { 9, 1, "Tufanbeyli" },
                    { 10, 1, "Yumurtalık" },
                    { 11, 1, "Yüreğir" },
                    { 12, 1, "Aladağ" },
                    { 13, 1, "İmamoğlu" },
                    { 14, 1, "Sarıçam" },
                    { 15, 1, "Çukurova" },
                    { 16, 2, "Adıyaman Merkez" },
                    { 17, 2, "Besni" },
                    { 18, 2, "Çelikhan" },
                    { 19, 2, "Gerger" },
                    { 20, 2, "Gölbaşı / Adıyaman" },
                    { 21, 2, "Kahta" },
                    { 22, 2, "Samsat" },
                    { 23, 2, "Sincik" },
                    { 24, 2, "Tut" },
                    { 25, 3, "Afyonkarahisar Merkez" },
                    { 26, 3, "Bolvadin" },
                    { 27, 3, "Çay" },
                    { 28, 3, "Dazkırı" },
                    { 29, 3, "Dinar" },
                    { 30, 3, "Emirdağ" },
                    { 31, 3, "İhsaniye" },
                    { 32, 3, "Sandıklı" },
                    { 33, 3, "Sinanpaşa" },
                    { 34, 3, "Sultandağı" },
                    { 35, 3, "Şuhut" },
                    { 36, 3, "Başmakçı" },
                    { 37, 3, "Bayat / Afyonkarahisar" },
                    { 38, 3, "İscehisar" },
                    { 39, 3, "Çobanlar" },
                    { 40, 3, "Evciler" },
                    { 41, 3, "Hocalar" },
                    { 42, 3, "Kızılören" },
                    { 43, 4, "Ağrı Merkez" },
                    { 44, 4, "Diyadin" },
                    { 45, 4, "Doğubayazıt" },
                    { 46, 4, "Eleşkirt" },
                    { 47, 4, "Hamur" },
                    { 48, 4, "Patnos" },
                    { 49, 4, "Taşlıçay" },
                    { 50, 4, "Tutak" },
                    { 51, 5, "Amasya Merkez" },
                    { 52, 5, "Göynücek" },
                    { 53, 5, "Gümüşhacıköy" },
                    { 54, 5, "Merzifon" },
                    { 55, 5, "Suluova" },
                    { 56, 5, "Taşova" },
                    { 57, 5, "Hamamözü" },
                    { 58, 6, "Altındağ" },
                    { 59, 6, "Ayaş" },
                    { 60, 6, "Bala" },
                    { 61, 6, "Beypazarı" },
                    { 62, 6, "Çamlıdere" },
                    { 63, 6, "Çankaya" },
                    { 64, 6, "Çubuk" },
                    { 65, 6, "Elmadağ" },
                    { 66, 6, "Güdül" },
                    { 67, 6, "Haymana" },
                    { 68, 6, "Kalecik" },
                    { 69, 6, "Kızılcahamam" },
                    { 70, 6, "Nallıhan" },
                    { 71, 6, "Polatlı" },
                    { 72, 6, "Şereflikoçhisar" },
                    { 73, 6, "Yenimahalle" },
                    { 74, 6, "Gölbaşı / Ankara" },
                    { 75, 6, "Keçiören" },
                    { 76, 6, "Mamak" },
                    { 77, 6, "Sincan" },
                    { 78, 6, "Kazan" },
                    { 79, 6, "Akyurt" },
                    { 80, 6, "Etimesgut" },
                    { 81, 6, "Evren" },
                    { 82, 6, "Pursaklar" },
                    { 83, 7, "Akseki" },
                    { 84, 7, "Alanya" },
                    { 85, 7, "Elmalı" },
                    { 86, 7, "Finike" },
                    { 87, 7, "Gazipaşa" },
                    { 88, 7, "Gündoğmuş" },
                    { 89, 7, "Kaş" },
                    { 90, 7, "Korkuteli" },
                    { 91, 7, "Kumluca" },
                    { 92, 7, "Manavgat" },
                    { 93, 7, "Serik" },
                    { 94, 7, "Demre" },
                    { 95, 7, "İbradı" },
                    { 96, 7, "Kemer / Antalya" },
                    { 97, 7, "Aksu / Antalya" },
                    { 98, 7, "Döşemealtı" },
                    { 99, 7, "Kepez" },
                    { 100, 7, "Konyaaltı" },
                    { 101, 7, "Muratpaşa" },
                    { 102, 8, "Ardanuç" },
                    { 103, 8, "Arhavi" },
                    { 104, 8, "Artvin Merkez" },
                    { 105, 8, "Borçka" },
                    { 106, 8, "Hopa" },
                    { 107, 8, "Şavşat" },
                    { 108, 8, "Yusufeli" },
                    { 109, 8, "Murgul" },
                    { 110, 9, "Bozdoğan" },
                    { 111, 9, "Çine" },
                    { 112, 9, "Germencik" },
                    { 113, 9, "Karacasu" },
                    { 114, 9, "Koçarlı" },
                    { 115, 9, "Kuşadası" },
                    { 116, 9, "Kuyucak" },
                    { 117, 9, "Nazilli" },
                    { 118, 9, "Söke" },
                    { 119, 9, "Sultanhisar" },
                    { 120, 9, "Yenipazar / Aydın" },
                    { 121, 9, "Buharkent" },
                    { 122, 9, "İncirliova" },
                    { 123, 9, "Karpuzlu" },
                    { 124, 9, "Köşk" },
                    { 125, 9, "Didim" },
                    { 126, 9, "Efeler" },
                    { 127, 10, "Ayvalık" },
                    { 128, 10, "Balya" },
                    { 129, 10, "Bandırma" },
                    { 130, 10, "Bigadiç" },
                    { 131, 10, "Burhaniye" },
                    { 132, 10, "Dursunbey" },
                    { 133, 10, "Edremit / Balıkesir" },
                    { 134, 10, "Erdek" },
                    { 135, 10, "Gönen / Balıkesir" },
                    { 136, 10, "Havran" },
                    { 137, 10, "İvrindi" },
                    { 138, 10, "Kepsut" },
                    { 139, 10, "Manyas" },
                    { 140, 10, "Savaştepe" },
                    { 141, 10, "Sındırgı" },
                    { 142, 10, "Susurluk" },
                    { 143, 10, "Marmara" },
                    { 144, 10, "Gömeç" },
                    { 145, 10, "Altıeylül" },
                    { 146, 10, "Karesi" },
                    { 147, 11, "Bilecik Merkez" },
                    { 148, 11, "Bozüyük" },
                    { 149, 11, "Gölpazarı" },
                    { 150, 11, "Osmaneli" },
                    { 151, 11, "Pazaryeri" },
                    { 152, 11, "Söğüt" },
                    { 153, 11, "Yenipazar / Bilecik" },
                    { 154, 11, "İnhisar" },
                    { 155, 12, "Bingöl Merkez" },
                    { 156, 12, "Genç" },
                    { 157, 12, "Karlıova" },
                    { 158, 12, "Kiğı" },
                    { 159, 12, "Solhan" },
                    { 160, 12, "Adaklı" },
                    { 161, 12, "Yayladere" },
                    { 162, 12, "Yedisu" },
                    { 163, 13, "Adilcevaz" },
                    { 164, 13, "Ahlat" },
                    { 165, 13, "Bitlis Merkez" },
                    { 166, 13, "Hizan" },
                    { 167, 13, "Mutki" },
                    { 168, 13, "Tatvan" },
                    { 169, 13, "Güroymak" },
                    { 170, 14, "Bolu Merkez" },
                    { 171, 14, "Gerede" },
                    { 172, 14, "Göynük" },
                    { 173, 14, "Kıbrıscık" },
                    { 174, 14, "Mengen" },
                    { 175, 14, "Mudurnu" },
                    { 176, 14, "Seben" },
                    { 177, 14, "Dörtdivan" },
                    { 178, 14, "Yeniçağa" },
                    { 179, 15, "Ağlasun" },
                    { 180, 15, "Bucak" },
                    { 181, 15, "Burdur Merkez" },
                    { 182, 15, "Gölhisar" },
                    { 183, 15, "Tefenni" },
                    { 184, 15, "Yeşilova" },
                    { 185, 15, "Karamanlı" },
                    { 186, 15, "Kemer / Burdur" },
                    { 187, 15, "Altınyayla / Burdur" },
                    { 188, 15, "Çavdır" },
                    { 189, 15, "Çeltikçi" },
                    { 190, 16, "Gemlik" },
                    { 191, 16, "İnegöl" },
                    { 192, 16, "İznik" },
                    { 193, 16, "Karacabey" },
                    { 194, 16, "Keles" },
                    { 195, 16, "Mudanya" },
                    { 196, 16, "Mustafakemalpaşa" },
                    { 197, 16, "Orhaneli" },
                    { 198, 16, "Orhangazi" },
                    { 199, 16, "Yenişehir / Bursa" },
                    { 200, 16, "Büyükorhan" },
                    { 201, 16, "Harmancık" },
                    { 202, 16, "Nilüfer" },
                    { 203, 16, "Osmangazi" },
                    { 204, 16, "Yıldırım" },
                    { 205, 16, "Gürsu" },
                    { 206, 16, "Kestel" },
                    { 207, 17, "Ayvacık / Çanakkale" },
                    { 208, 17, "Bayramiç" },
                    { 209, 17, "Biga" },
                    { 210, 17, "Bozcaada" },
                    { 211, 17, "Çan" },
                    { 212, 17, "Çanakkale Merkez" },
                    { 213, 17, "Eceabat" },
                    { 214, 17, "Ezine" },
                    { 215, 17, "Gelibolu" },
                    { 216, 17, "Gökçeada" },
                    { 217, 17, "Lapseki" },
                    { 218, 17, "Yenice / Çanakkale" },
                    { 219, 18, "Çankırı Merkez" },
                    { 220, 18, "Çerkeş" },
                    { 221, 18, "Eldivan" },
                    { 222, 18, "Ilgaz" },
                    { 223, 18, "Kurşunlu" },
                    { 224, 18, "Orta" },
                    { 225, 18, "Şabanözü" },
                    { 226, 18, "Yapraklı" },
                    { 227, 18, "Atkaracalar" },
                    { 228, 18, "Kızılırmak" },
                    { 229, 18, "Bayramören" },
                    { 230, 18, "Korgun" },
                    { 231, 19, "Alaca" },
                    { 232, 19, "Bayat / Çorum" },
                    { 233, 19, "Çorum Merkez" },
                    { 234, 19, "İskilip" },
                    { 235, 19, "Kargı" },
                    { 236, 19, "Mecitözü" },
                    { 237, 19, "Ortaköy / Çorum" },
                    { 238, 19, "Osmancık" },
                    { 239, 19, "Sungurlu" },
                    { 240, 19, "Boğazkale" },
                    { 241, 19, "Uğurludağ" },
                    { 242, 19, "Dodurga" },
                    { 243, 19, "Laçin" },
                    { 244, 19, "Oğuzlar" },
                    { 245, 20, "Acıpayam" },
                    { 246, 20, "Buldan" },
                    { 247, 20, "Çal" },
                    { 248, 20, "Çameli" },
                    { 249, 20, "Çardak" },
                    { 250, 20, "Çivril" },
                    { 251, 20, "Güney" },
                    { 252, 20, "Kale / Denizli" },
                    { 253, 20, "Sarayköy" },
                    { 254, 20, "Tavas" },
                    { 255, 20, "Babadağ" },
                    { 256, 20, "Bekilli" },
                    { 257, 20, "Honaz" },
                    { 258, 20, "Serinhisar" },
                    { 259, 20, "Pamukkale" },
                    { 260, 20, "Baklan" },
                    { 261, 20, "Beyağaç" },
                    { 262, 20, "Bozkurt / Denizli" },
                    { 263, 20, "Merkezefendi" },
                    { 264, 21, "Bismil" },
                    { 265, 21, "Çermik" },
                    { 266, 21, "Çınar" },
                    { 267, 21, "Çüngüş" },
                    { 268, 21, "Dicle" },
                    { 269, 21, "Ergani" },
                    { 270, 21, "Hani" },
                    { 271, 21, "Hazro" },
                    { 272, 21, "Kulp" },
                    { 273, 21, "Lice" },
                    { 274, 21, "Silvan" },
                    { 275, 21, "Eğil" },
                    { 276, 21, "Kocaköy" },
                    { 277, 21, "Bağlar" },
                    { 278, 21, "Kayapınar" },
                    { 279, 21, "Sur" },
                    { 280, 21, "Yenişehir / Diyarbakır" },
                    { 281, 22, "Edirne Merkez" },
                    { 282, 22, "Enez" },
                    { 283, 22, "Havsa" },
                    { 284, 22, "İpsala" },
                    { 285, 22, "Keşan" },
                    { 286, 22, "Lalapaşa" },
                    { 287, 22, "Meriç" },
                    { 288, 22, "Uzunköprü" },
                    { 289, 22, "Süloğlu" },
                    { 290, 23, "Ağın" },
                    { 291, 23, "Baskil" },
                    { 292, 23, "Elazığ Merkez" },
                    { 293, 23, "Karakoçan" },
                    { 294, 23, "Keban" },
                    { 295, 23, "Maden" },
                    { 296, 23, "Palu" },
                    { 297, 23, "Sivrice" },
                    { 298, 23, "Arıcak" },
                    { 299, 23, "Kovancılar" },
                    { 300, 23, "Alacakaya" },
                    { 301, 24, "Çayırlı" },
                    { 302, 24, "Erzincan Merkez" },
                    { 303, 24, "İliç" },
                    { 304, 24, "Kemah" },
                    { 305, 24, "Kemaliye" },
                    { 306, 24, "Refahiye" },
                    { 307, 24, "Tercan" },
                    { 308, 24, "Üzümlü" },
                    { 309, 24, "Otlukbeli" },
                    { 310, 25, "Aşkale" },
                    { 311, 25, "Çat" },
                    { 312, 25, "Hınıs" },
                    { 313, 25, "Horasan" },
                    { 314, 25, "İspir" },
                    { 315, 25, "Karayazı" },
                    { 316, 25, "Narman" },
                    { 317, 25, "Oltu" },
                    { 318, 25, "Olur" },
                    { 319, 25, "Pasinler" },
                    { 320, 25, "Şenkaya" },
                    { 321, 25, "Tekman" },
                    { 322, 25, "Tortum" },
                    { 323, 25, "Karaçoban" },
                    { 324, 25, "Uzundere" },
                    { 325, 25, "Pazaryolu" },
                    { 326, 25, "Aziziye" },
                    { 327, 25, "Köprüköy" },
                    { 328, 25, "Palandöken" },
                    { 329, 25, "Yakutiye" },
                    { 330, 26, "Çifteler" },
                    { 331, 26, "Mahmudiye" },
                    { 332, 26, "Mihalıççık" },
                    { 333, 26, "Sarıcakaya" },
                    { 334, 26, "Seyitgazi" },
                    { 335, 26, "Sivrihisar" },
                    { 336, 26, "Alpu" },
                    { 337, 26, "Beylikova" },
                    { 338, 26, "İnönü" },
                    { 339, 26, "Günyüzü" },
                    { 340, 26, "Han" },
                    { 341, 26, "Mihalgazi" },
                    { 342, 26, "Odunpazarı" },
                    { 343, 26, "Tepebaşı" },
                    { 344, 27, "Araban" },
                    { 345, 27, "İslahiye" },
                    { 346, 27, "Nizip" },
                    { 347, 27, "Oğuzeli" },
                    { 348, 27, "Yavuzeli" },
                    { 349, 27, "Şahinbey" },
                    { 350, 27, "Şehitkamil" },
                    { 351, 27, "Karkamış" },
                    { 352, 27, "Nurdağı" },
                    { 353, 28, "Alucra" },
                    { 354, 28, "Bulancak" },
                    { 355, 28, "Dereli" },
                    { 356, 28, "Espiye" },
                    { 357, 28, "Eynesil" },
                    { 358, 28, "Giresun Merkez" },
                    { 359, 28, "Görele" },
                    { 360, 28, "Keşap" },
                    { 361, 28, "Şebinkarahisar" },
                    { 362, 28, "Tirebolu" },
                    { 363, 28, "Piraziz" },
                    { 364, 28, "Yağlıdere" },
                    { 365, 28, "Çamoluk" },
                    { 366, 28, "Çanakçı" },
                    { 367, 28, "Doğankent" },
                    { 368, 28, "Güce" },
                    { 369, 29, "Gümüşhane Merkez" },
                    { 370, 29, "Kelkit" },
                    { 371, 29, "Şiran" },
                    { 372, 29, "Torul" },
                    { 373, 29, "Köse" },
                    { 374, 29, "Kürtün" },
                    { 375, 30, "Çukurca" },
                    { 376, 30, "Hakkari Merkez" },
                    { 377, 30, "Şemdinli" },
                    { 378, 30, "Yüksekova" },
                    { 379, 31, "Altınözü" },
                    { 380, 31, "Dörtyol" },
                    { 381, 31, "Hassa" },
                    { 382, 31, "İskenderun" },
                    { 383, 31, "Kırıkhan" },
                    { 384, 31, "Reyhanlı" },
                    { 385, 31, "Samandağ" },
                    { 386, 31, "Yayladağı" },
                    { 387, 31, "Erzin" },
                    { 388, 31, "Belen" },
                    { 389, 31, "Kumlu" },
                    { 390, 31, "Antakya" },
                    { 391, 31, "Arsuz" },
                    { 392, 31, "Defne" },
                    { 393, 31, "Payas" },
                    { 394, 32, "Atabey" },
                    { 395, 32, "Eğirdir" },
                    { 396, 32, "Gelendost" },
                    { 397, 32, "Isparta Merkez" },
                    { 398, 32, "Keçiborlu" },
                    { 399, 32, "Senirkent" },
                    { 400, 32, "Sütçüler" },
                    { 401, 32, "Şarkikaraağaç" },
                    { 402, 32, "Uluborlu" },
                    { 403, 32, "Yalvaç" },
                    { 404, 32, "Aksu / Isparta" },
                    { 405, 32, "Gönen / Isparta" },
                    { 406, 32, "Yenişarbademli" },
                    { 407, 33, "Anamur" },
                    { 408, 33, "Erdemli" },
                    { 409, 33, "Gülnar" },
                    { 410, 33, "Mut" },
                    { 411, 33, "Silifke" },
                    { 412, 33, "Tarsus" },
                    { 413, 33, "Aydıncık / Mersin" },
                    { 414, 33, "Bozyazı" },
                    { 415, 33, "Çamlıyayla" },
                    { 416, 33, "Akdeniz" },
                    { 417, 33, "Mezitli" },
                    { 418, 33, "Toroslar" },
                    { 419, 33, "Yenişehir / Mersin" },
                    { 420, 34, "Adalar" },
                    { 421, 34, "Bakırköy" },
                    { 422, 34, "Beşiktaş" },
                    { 423, 34, "Beykoz" },
                    { 424, 34, "Beyoğlu" },
                    { 425, 34, "Çatalca" },
                    { 426, 34, "Eyüp" },
                    { 427, 34, "Fatih" },
                    { 428, 34, "Gaziosmanpaşa" },
                    { 429, 34, "Kadıköy" },
                    { 430, 34, "Kartal" },
                    { 431, 34, "Sarıyer" },
                    { 432, 34, "Silivri" },
                    { 433, 34, "Şile" },
                    { 434, 34, "Şişli" },
                    { 435, 34, "Üsküdar" },
                    { 436, 34, "Zeytinburnu" },
                    { 437, 34, "Büyükçekmece" },
                    { 438, 34, "Kağıthane" },
                    { 439, 34, "Küçükçekmece" },
                    { 440, 34, "Pendik" },
                    { 441, 34, "Ümraniye" },
                    { 442, 34, "Bayrampaşa" },
                    { 443, 34, "Avcılar" },
                    { 444, 34, "Bağcılar" },
                    { 445, 34, "Bahçelievler" },
                    { 446, 34, "Güngören" },
                    { 447, 34, "Maltepe" },
                    { 448, 34, "Sultanbeyli" },
                    { 449, 34, "Tuzla" },
                    { 450, 34, "Esenler" },
                    { 451, 34, "Arnavutköy" },
                    { 452, 34, "Ataşehir" },
                    { 453, 34, "Başakşehir" },
                    { 454, 34, "Beylikdüzü" },
                    { 455, 34, "Çekmeköy" },
                    { 456, 34, "Esenyurt" },
                    { 457, 34, "Sancaktepe" },
                    { 458, 34, "Sultangazi" },
                    { 459, 35, "Aliağa" },
                    { 460, 35, "Bayındır" },
                    { 461, 35, "Bergama" },
                    { 462, 35, "Bornova" },
                    { 463, 35, "Çeşme" },
                    { 464, 35, "Dikili" },
                    { 465, 35, "Foça" },
                    { 466, 35, "Karaburun" },
                    { 467, 35, "Karşıyaka" },
                    { 468, 35, "Kemalpaşa / İzmir" },
                    { 469, 35, "Kınık" },
                    { 470, 35, "Kiraz" },
                    { 471, 35, "Menemen" },
                    { 472, 35, "Ödemiş" },
                    { 473, 35, "Seferihisar" },
                    { 474, 35, "Selçuk" },
                    { 475, 35, "Tire" },
                    { 476, 35, "Torbalı" },
                    { 477, 35, "Urla" },
                    { 478, 35, "Beydağ" },
                    { 479, 35, "Buca" },
                    { 480, 35, "Konak" },
                    { 481, 35, "Menderes" },
                    { 482, 35, "Balçova" },
                    { 483, 35, "Çiğli" },
                    { 484, 35, "Gaziemir" },
                    { 485, 35, "Narlıdere" },
                    { 486, 35, "Güzelbahçe" },
                    { 487, 35, "Bayraklı" },
                    { 488, 35, "Karabağlar" },
                    { 489, 36, "Arpaçay" },
                    { 490, 36, "Digor" },
                    { 491, 36, "Kağızman" },
                    { 492, 36, "Kars Merkez" },
                    { 493, 36, "Sarıkamış" },
                    { 494, 36, "Selim" },
                    { 495, 36, "Susuz" },
                    { 496, 36, "Akyaka" },
                    { 497, 37, "Abana" },
                    { 498, 37, "Araç" },
                    { 499, 37, "Azdavay" },
                    { 500, 37, "Bozkurt / Kastamonu" },
                    { 501, 37, "Cide" },
                    { 502, 37, "Çatalzeytin" },
                    { 503, 37, "Daday" },
                    { 504, 37, "Devrekani" },
                    { 505, 37, "İnebolu" },
                    { 506, 37, "Kastamonu Merkez" },
                    { 507, 37, "Küre" },
                    { 508, 37, "Taşköprü" },
                    { 509, 37, "Tosya" },
                    { 510, 37, "İhsangazi" },
                    { 511, 37, "Pınarbaşı / Kastamonu" },
                    { 512, 37, "Şenpazar" },
                    { 513, 37, "Ağlı" },
                    { 514, 37, "Doğanyurt" },
                    { 515, 37, "Hanönü" },
                    { 516, 37, "Seydiler" },
                    { 517, 38, "Bünyan" },
                    { 518, 38, "Develi" },
                    { 519, 38, "Felahiye" },
                    { 520, 38, "İncesu" },
                    { 521, 38, "Pınarbaşı / Kayseri" },
                    { 522, 38, "Sarıoğlan" },
                    { 523, 38, "Sarız" },
                    { 524, 38, "Tomarza" },
                    { 525, 38, "Yahyalı" },
                    { 526, 38, "Yeşilhisar" },
                    { 527, 38, "Akkışla" },
                    { 528, 38, "Talas" },
                    { 529, 38, "Kocasinan" },
                    { 530, 38, "Melikgazi" },
                    { 531, 38, "Hacılar" },
                    { 532, 38, "Özvatan" },
                    { 533, 39, "Babaeski" },
                    { 534, 39, "Demirköy" },
                    { 535, 39, "Kırklareli Merkez" },
                    { 536, 39, "Kofçaz" },
                    { 537, 39, "Lüleburgaz" },
                    { 538, 39, "Pehlivanköy" },
                    { 539, 39, "Pınarhisar" },
                    { 540, 39, "Vize" },
                    { 541, 40, "Çiçekdağı" },
                    { 542, 40, "Kaman" },
                    { 543, 40, "Kırşehir Merkez" },
                    { 544, 40, "Mucur" },
                    { 545, 40, "Akpınar" },
                    { 546, 40, "Akçakent" },
                    { 547, 40, "Boztepe" },
                    { 548, 41, "Gebze" },
                    { 549, 41, "Gölcük" },
                    { 550, 41, "Kandıra" },
                    { 551, 41, "Karamürsel" },
                    { 552, 41, "Körfez" },
                    { 553, 41, "Derince" },
                    { 554, 41, "Başiskele" },
                    { 555, 41, "Çayırova" },
                    { 556, 41, "Darıca" },
                    { 557, 41, "Dilovası" },
                    { 558, 41, "İzmit" },
                    { 559, 41, "Kartepe" },
                    { 560, 42, "Akşehir" },
                    { 561, 42, "Beyşehir" },
                    { 562, 42, "Bozkır" },
                    { 563, 42, "Cihanbeyli" },
                    { 564, 42, "Çumra" },
                    { 565, 42, "Doğanhisar" },
                    { 566, 42, "Ereğli / Konya" },
                    { 567, 42, "Hadim" },
                    { 568, 42, "Ilgın" },
                    { 569, 42, "Kadınhanı" },
                    { 570, 42, "Karapınar" },
                    { 571, 42, "Kulu" },
                    { 572, 42, "Sarayönü" },
                    { 573, 42, "Seydişehir" },
                    { 574, 42, "Yunak" },
                    { 575, 42, "Akören" },
                    { 576, 42, "Altınekin" },
                    { 577, 42, "Derebucak" },
                    { 578, 42, "Hüyük" },
                    { 579, 42, "Karatay" },
                    { 580, 42, "Meram" },
                    { 581, 42, "Selçuklu" },
                    { 582, 42, "Taşkent" },
                    { 583, 42, "Ahırlı" },
                    { 584, 42, "Çeltik" },
                    { 585, 42, "Derbent" },
                    { 586, 42, "Emirgazi" },
                    { 587, 42, "Güneysınır" },
                    { 588, 42, "Halkapınar" },
                    { 589, 42, "Tuzlukçu" },
                    { 590, 42, "Yalıhüyük" },
                    { 591, 43, "Altıntaş" },
                    { 592, 43, "Domaniç" },
                    { 593, 43, "Emet" },
                    { 594, 43, "Gediz" },
                    { 595, 43, "Kütahya Merkez" },
                    { 596, 43, "Simav" },
                    { 597, 43, "Tavşanlı" },
                    { 598, 43, "Aslanapa" },
                    { 599, 43, "Dumlupınar" },
                    { 600, 43, "Hisarcık" },
                    { 601, 43, "Şaphane" },
                    { 602, 43, "Çavdarhisar" },
                    { 603, 43, "Pazarlar" },
                    { 604, 44, "Akçadağ" },
                    { 605, 44, "Arapgir" },
                    { 606, 44, "Arguvan" },
                    { 607, 44, "Darende" },
                    { 608, 44, "Doğanşehir" },
                    { 609, 44, "Hekimhan" },
                    { 610, 44, "Pütürge" },
                    { 611, 44, "Yeşilyurt / Malatya" },
                    { 612, 44, "Battalgazi" },
                    { 613, 44, "Doğanyol" },
                    { 614, 44, "Kale / Malatya" },
                    { 615, 44, "Kuluncak" },
                    { 616, 44, "Yazıhan" },
                    { 617, 45, "Akhisar" },
                    { 618, 45, "Alaşehir" },
                    { 619, 45, "Demirci" },
                    { 620, 45, "Gördes" },
                    { 621, 45, "Kırkağaç" },
                    { 622, 45, "Kula" },
                    { 623, 45, "Salihli" },
                    { 624, 45, "Sarıgöl" },
                    { 625, 45, "Saruhanlı" },
                    { 626, 45, "Selendi" },
                    { 627, 45, "Soma" },
                    { 628, 45, "Turgutlu" },
                    { 629, 45, "Ahmetli" },
                    { 630, 45, "Gölmarmara" },
                    { 631, 45, "Köprübaşı / Manisa" },
                    { 632, 45, "Şehzadeler" },
                    { 633, 45, "Yunusemre" },
                    { 634, 46, "Afşin" },
                    { 635, 46, "Andırın" },
                    { 636, 46, "Elbistan" },
                    { 637, 46, "Göksun" },
                    { 638, 46, "Pazarcık" },
                    { 639, 46, "Türkoğlu" },
                    { 640, 46, "Çağlayancerit" },
                    { 641, 46, "Ekinözü" },
                    { 642, 46, "Nurhak" },
                    { 643, 46, "Dulkadiroğlu" },
                    { 644, 46, "Onikişubat" },
                    { 645, 47, "Derik" },
                    { 646, 47, "Kızıltepe" },
                    { 647, 47, "Mazıdağı" },
                    { 648, 47, "Midyat" },
                    { 649, 47, "Nusaybin" },
                    { 650, 47, "Ömerli" },
                    { 651, 47, "Savur" },
                    { 652, 47, "Dargeçit" },
                    { 653, 47, "Yeşilli" },
                    { 654, 47, "Artuklu" },
                    { 655, 48, "Bodrum" },
                    { 656, 48, "Datça" },
                    { 657, 48, "Fethiye" },
                    { 658, 48, "Köyceğiz" },
                    { 659, 48, "Marmaris" },
                    { 660, 48, "Milas" },
                    { 661, 48, "Ula" },
                    { 662, 48, "Yatağan" },
                    { 663, 48, "Dalaman" },
                    { 664, 48, "Ortaca" },
                    { 665, 48, "Kavaklıdere" },
                    { 666, 48, "Menteşe" },
                    { 667, 48, "Seydikemer" },
                    { 668, 49, "Bulanık" },
                    { 669, 49, "Malazgirt" },
                    { 670, 49, "Muş Merkez" },
                    { 671, 49, "Varto" },
                    { 672, 49, "Hasköy" },
                    { 673, 49, "Korkut" },
                    { 674, 50, "Avanos" },
                    { 675, 50, "Derinkuyu" },
                    { 676, 50, "Gülşehir" },
                    { 677, 50, "Hacıbektaş" },
                    { 678, 50, "Kozaklı" },
                    { 679, 50, "Nevşehir Merkez" },
                    { 680, 50, "Ürgüp" },
                    { 681, 50, "Acıgöl" },
                    { 682, 51, "Bor" },
                    { 683, 51, "Çamardı" },
                    { 684, 51, "Niğde Merkez" },
                    { 685, 51, "Ulukışla" },
                    { 686, 51, "Altunhisar" },
                    { 687, 51, "Çiftlik" },
                    { 688, 52, "Akkuş" },
                    { 689, 52, "Aybastı" },
                    { 690, 52, "Fatsa" },
                    { 691, 52, "Gölköy" },
                    { 692, 52, "Korgan" },
                    { 693, 52, "Kumru" },
                    { 694, 52, "Mesudiye" },
                    { 695, 52, "Perşembe" },
                    { 696, 52, "Ulubey / Ordu" },
                    { 697, 52, "Ünye" },
                    { 698, 52, "Gülyalı" },
                    { 699, 52, "Gürgentepe" },
                    { 700, 52, "Çamaş" },
                    { 701, 52, "Çatalpınar" },
                    { 702, 52, "Çaybaşı" },
                    { 703, 52, "İkizce" },
                    { 704, 52, "Kabadüz" },
                    { 705, 52, "Kabataş" },
                    { 706, 52, "Altınordu" },
                    { 707, 53, "Ardeşen" },
                    { 708, 53, "Çamlıhemşin" },
                    { 709, 53, "Çayeli" },
                    { 710, 53, "Fındıklı" },
                    { 711, 53, "İkizdere" },
                    { 712, 53, "Kalkandere" },
                    { 713, 53, "Pazar / Rize" },
                    { 714, 53, "Rize Merkez" },
                    { 715, 53, "Güneysu" },
                    { 716, 53, "Derepazarı" },
                    { 717, 53, "Hemşin" },
                    { 718, 53, "İyidere" },
                    { 719, 54, "Akyazı" },
                    { 720, 54, "Geyve" },
                    { 721, 54, "Hendek" },
                    { 722, 54, "Karasu" },
                    { 723, 54, "Kaynarca" },
                    { 724, 54, "Sapanca" },
                    { 725, 54, "Kocaali" },
                    { 726, 54, "Pamukova" },
                    { 727, 54, "Taraklı" },
                    { 728, 54, "Ferizli" },
                    { 729, 54, "Karapürçek" },
                    { 730, 54, "Söğütlü" },
                    { 731, 54, "Adapazarı" },
                    { 732, 54, "Arifiye" },
                    { 733, 54, "Erenler" },
                    { 734, 54, "Serdivan" },
                    { 735, 55, "Alaçam" },
                    { 736, 55, "Bafra" },
                    { 737, 55, "Çarşamba" },
                    { 738, 55, "Havza" },
                    { 739, 55, "Kavak" },
                    { 740, 55, "Ladik" },
                    { 741, 55, "Terme" },
                    { 742, 55, "Vezirköprü" },
                    { 743, 55, "Asarcık" },
                    { 744, 55, "43604" },
                    { 745, 55, "Salıpazarı" },
                    { 746, 55, "Tekkeköy" },
                    { 747, 55, "Ayvacık / Samsun" },
                    { 748, 55, "Yakakent" },
                    { 749, 55, "Atakum" },
                    { 750, 55, "Canik" },
                    { 751, 55, "İlkadım" },
                    { 752, 56, "Baykan" },
                    { 753, 56, "Eruh" },
                    { 754, 56, "Kurtalan" },
                    { 755, 56, "Pervari" },
                    { 756, 56, "Siirt Merkez" },
                    { 757, 56, "Şirvan" },
                    { 758, 56, "Tillo" },
                    { 759, 57, "Ayancık" },
                    { 760, 57, "Boyabat" },
                    { 761, 57, "Durağan" },
                    { 762, 57, "Erfelek" },
                    { 763, 57, "Gerze" },
                    { 764, 57, "Sinop Merkez" },
                    { 765, 57, "Türkeli" },
                    { 766, 57, "Dikmen" },
                    { 767, 57, "Saraydüzü" },
                    { 768, 58, "Divriği" },
                    { 769, 58, "Gemerek" },
                    { 770, 58, "Gürün" },
                    { 771, 58, "Hafik" },
                    { 772, 58, "İmranlı" },
                    { 773, 58, "Kangal" },
                    { 774, 58, "Koyulhisar" },
                    { 775, 58, "Sivas Merkez" },
                    { 776, 58, "Suşehri" },
                    { 777, 58, "Şarkışla" },
                    { 778, 58, "Yıldızeli" },
                    { 779, 58, "Zara" },
                    { 780, 58, "Akıncılar" },
                    { 781, 58, "Altınyayla / Sivas" },
                    { 782, 58, "Doğanşar" },
                    { 783, 58, "Gölova" },
                    { 784, 58, "Ulaş" },
                    { 785, 59, "Çerkezköy" },
                    { 786, 59, "Çorlu" },
                    { 787, 59, "Hayrabolu" },
                    { 788, 59, "Malkara" },
                    { 789, 59, "Muratlı" },
                    { 790, 59, "Saray / Tekirdağ" },
                    { 791, 59, "Şarköy" },
                    { 792, 59, "Marmaraereğlisi" },
                    { 793, 59, "Ergene" },
                    { 794, 59, "Kapaklı" },
                    { 795, 59, "Süleymanpaşa" },
                    { 796, 60, "Almus" },
                    { 797, 60, "Artova" },
                    { 798, 60, "Erbaa" },
                    { 799, 60, "Niksar" },
                    { 800, 60, "Reşadiye" },
                    { 801, 60, "Tokat Merkez" },
                    { 802, 60, "Turhal" },
                    { 803, 60, "Zile" },
                    { 804, 60, "Pazar / Tokat" },
                    { 805, 60, "Yeşilyurt / Tokat" },
                    { 806, 60, "Başçiftlik" },
                    { 807, 60, "Sulusaray" },
                    { 808, 61, "Akçaabat" },
                    { 809, 61, "Araklı" },
                    { 810, 61, "Arsin" },
                    { 811, 61, "Çaykara" },
                    { 812, 61, "Maçka" },
                    { 813, 61, "Of" },
                    { 814, 61, "Sürmene" },
                    { 815, 61, "Tonya" },
                    { 816, 61, "Vakfıkebir" },
                    { 817, 61, "Yomra" },
                    { 818, 61, "Beşikdüzü" },
                    { 819, 61, "Şalpazarı" },
                    { 820, 61, "Çarşıbaşı" },
                    { 821, 61, "Dernekpazarı" },
                    { 822, 61, "Düzköy" },
                    { 823, 61, "Hayrat" },
                    { 824, 61, "Köprübaşı / Trabzon" },
                    { 825, 61, "Ortahisar" },
                    { 826, 62, "Çemişgezek" },
                    { 827, 62, "Hozat" },
                    { 828, 62, "Mazgirt" },
                    { 829, 62, "Nazımiye" },
                    { 830, 62, "Ovacık / Tunceli" },
                    { 831, 62, "Pertek" },
                    { 832, 62, "Pülümür" },
                    { 833, 62, "Tunceli Merkez" },
                    { 834, 63, "Akçakale" },
                    { 835, 63, "Birecik" },
                    { 836, 63, "Bozova" },
                    { 837, 63, "Ceylanpınar" },
                    { 838, 63, "Halfeti" },
                    { 839, 63, "Hilvan" },
                    { 840, 63, "Siverek" },
                    { 841, 63, "Suruç" },
                    { 842, 63, "Viranşehir" },
                    { 843, 63, "Harran" },
                    { 844, 63, "Eyyübiye" },
                    { 845, 63, "Haliliye" },
                    { 846, 63, "Karaköprü" },
                    { 847, 64, "Banaz" },
                    { 848, 64, "Eşme" },
                    { 849, 64, "Karahallı" },
                    { 850, 64, "Sivaslı" },
                    { 851, 64, "Ulubey / Uşak" },
                    { 852, 64, "Uşak Merkez" },
                    { 853, 65, "Başkale" },
                    { 854, 65, "Çatak" },
                    { 855, 65, "Erciş" },
                    { 856, 65, "Gevaş" },
                    { 857, 65, "Gürpınar" },
                    { 858, 65, "Muradiye" },
                    { 859, 65, "Özalp" },
                    { 860, 65, "Bahçesaray" },
                    { 861, 65, "Çaldıran" },
                    { 862, 65, "Edremit / Van" },
                    { 863, 65, "Saray / Van" },
                    { 864, 65, "İpekyolu" },
                    { 865, 65, "Tuşba" },
                    { 866, 66, "Akdağmadeni" },
                    { 867, 66, "Boğazlıyan" },
                    { 868, 66, "Çayıralan" },
                    { 869, 66, "Çekerek" },
                    { 870, 66, "Sarıkaya" },
                    { 871, 66, "Sorgun" },
                    { 872, 66, "Şefaatli" },
                    { 873, 66, "Yerköy" },
                    { 874, 66, "Yozgat Merkez" },
                    { 875, 66, "Aydıncık / Yozgat" },
                    { 876, 66, "Çandır" },
                    { 877, 66, "Kadışehri" },
                    { 878, 66, "Saraykent" },
                    { 879, 66, "Yenifakılı" },
                    { 880, 67, "Çaycuma" },
                    { 881, 67, "Devrek" },
                    { 882, 67, "Ereğli / Zonguldak" },
                    { 883, 67, "Zonguldak Merkez" },
                    { 884, 67, "Alaplı" },
                    { 885, 67, "Gökçebey" },
                    { 886, 67, "Kilimli" },
                    { 887, 67, "Kozlu" },
                    { 888, 68, "Aksaray Merkez" },
                    { 889, 68, "Ortaköy / Aksaray" },
                    { 890, 68, "Ağaçören" },
                    { 891, 68, "Güzelyurt" },
                    { 892, 68, "Sarıyahşi" },
                    { 893, 68, "Eskil" },
                    { 894, 68, "Gülağaç" },
                    { 895, 69, "Bayburt Merkez" },
                    { 896, 69, "Aydıntepe" },
                    { 897, 69, "Demirözü" },
                    { 898, 70, "Ermenek" },
                    { 899, 70, "Karaman Merkez" },
                    { 900, 70, "Ayrancı" },
                    { 901, 70, "Kazımkarabekir" },
                    { 902, 70, "Başyayla" },
                    { 903, 70, "Sarıveliler" },
                    { 904, 71, "Delice" },
                    { 905, 71, "Keskin" },
                    { 906, 71, "Kırıkkale Merkez" },
                    { 907, 71, "Sulakyurt" },
                    { 908, 71, "Bahşili" },
                    { 909, 71, "Balışeyh" },
                    { 910, 71, "Çelebi" },
                    { 911, 71, "Karakeçili" },
                    { 912, 71, "Yahşihan" },
                    { 913, 72, "Batman Merkez" },
                    { 914, 72, "Beşiri" },
                    { 915, 72, "Gercüş" },
                    { 916, 72, "Kozluk" },
                    { 917, 72, "Sason" },
                    { 918, 72, "Hasankeyf" },
                    { 919, 73, "Beytüşşebap" },
                    { 920, 73, "Cizre" },
                    { 921, 73, "İdil" },
                    { 922, 73, "Silopi" },
                    { 923, 73, "Şırnak Merkez" },
                    { 924, 73, "Uludere" },
                    { 925, 73, "Güçlükonak" },
                    { 926, 74, "Bartın Merkez" },
                    { 927, 74, "Kurucaşile" },
                    { 928, 74, "Ulus" },
                    { 929, 74, "Amasra" },
                    { 930, 75, "Ardahan Merkez" },
                    { 931, 75, "Çıldır" },
                    { 932, 75, "Göle" },
                    { 933, 75, "Hanak" },
                    { 934, 75, "Posof" },
                    { 935, 75, "Damal" },
                    { 936, 76, "Aralık" },
                    { 937, 76, "Iğdır Merkez" },
                    { 938, 76, "Tuzluca" },
                    { 939, 76, "Karakoyunlu" },
                    { 940, 77, "Yalova Merkez" },
                    { 941, 77, "Altınova" },
                    { 942, 77, "Armutlu" },
                    { 943, 77, "Çınarcık" },
                    { 944, 77, "Çiftlikköy" },
                    { 945, 77, "Termal" },
                    { 946, 78, "Eflani" },
                    { 947, 78, "Eskipazar" },
                    { 948, 78, "Karabük Merkez" },
                    { 949, 78, "Ovacık / Karabük" },
                    { 950, 78, "Safranbolu" },
                    { 951, 78, "Yenice / Karabük" },
                    { 952, 79, "Kilis Merkez" },
                    { 953, 79, "Elbeyli" },
                    { 954, 79, "Musabeyli" },
                    { 955, 79, "Polateli" },
                    { 956, 80, "Bahçe" },
                    { 957, 80, "Kadirli" },
                    { 958, 80, "Osmaniye Merkez" },
                    { 959, 80, "Düziçi" },
                    { 960, 80, "Hasanbeyli" },
                    { 961, 80, "Sumbas" },
                    { 962, 80, "Toprakkale" },
                    { 963, 81, "Akçakoca" },
                    { 964, 81, "Düzce Merkez" },
                    { 965, 81, "Yığılca" },
                    { 966, 81, "Cumayeri" },
                    { 967, 81, "Gölyaka" },
                    { 968, 81, "Çilimli" },
                    { 969, 81, "Gümüşova" },
                    { 970, 81, "Kaynaşlı" }
                });

            migrationBuilder.InsertData(
                table: "patientinformations",
                columns: new[] { "patientinformationid", "eatingstatusid", "energystatusid", "ilnesssesinthepast", "informationaboutpatient", "peeingstatusid" },
                values: new object[,]
                {
                    { 6, 2, 1, "Sif is a 3-year-old wolf who had a case of mange a year ago, which was treated with medicated baths and topical ointments. She also developed an ear infection a few months ago, which was treated with antibiotics and ear drops. In the past, Sif has also had some minor digestive issues that we've been able to resolve with diet and supplement changes.", "My wolf Sif has been eating fine and her energy levels are good, but she has been having trouble with her peeing. She's been going more frequently and sometimes it seems like it's painful for her. I'm really concerned because she's usually such a healthy wolf.", 3 },
                    { 9, 2, 2, "orrent is a chestnut brown horse with a strong and majestic presence. However, a few months ago, he fell ill and experienced difficulty breathing and a persistent cough. The vet diagnosed him with a respiratory infection and prescribed medication and rest. Thankfully, Torrent made a full recovery and is now back to his old self.", "Hi there, I'm the owner of a horse named Torrent. He's been feeling a bit under the weather lately and has had some difficulty breathing and a persistent cough. I'm really worried about him and would like to get him checked out by a veterinarian as soon as possible.Could you please let me know if you have any availability to see Torrent in the next few days? I'm very concerned about his health and want to make sure he gets the care he needs.Thank you for your attention to this matter. I appreciate any help you can provide in getting Torrent back to good health.", 2 }
                });

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
                    { 128, "anastacia@gmail.com", "anastacia123456", 666 },
                    { 666, "patches@gmail.com", "patches123456", 666 }
                });

            migrationBuilder.InsertData(
                table: "addresses",
                columns: new[] { "addressid", "addressdetails", "districtid" },
                values: new object[,]
                {
                    { 6, "Block 5, after Boo's shop", 34 },
                    { 7, "Block 6, after Foo's shop", 40 },
                    { 9, "Block 6, after Coo's shop", 30 },
                    { 12, "Block 7, after Too's shop", 30 }
                });

            migrationBuilder.InsertData(
                table: "notuserparentspet",
                columns: new[] { "animalid", "breedid", "dob", "name", "patientinformationid", "petgenderid", "specieid" },
                values: new object[] { 9, 9, new DateTime(2011, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Torrent", 9, 9, 9 });

            migrationBuilder.InsertData(
                table: "pets",
                columns: new[] { "animalid", "adoptinfoid", "breedid", "dob", "isadoptable", "name", "patientinformationid", "patientİnformationpatientinformationid", "petgenderid", "specieid" },
                values: new object[] { 6, 6, 6, new DateTime(2022, 12, 31, 2, 0, 4, 361, DateTimeKind.Local).AddTicks(500), true, "Sif", 6, null, 6, 6 });

            migrationBuilder.InsertData(
                table: "adoptinfos",
                columns: new[] { "adoptinfoid", "adopttext" },
                values: new object[] { 6, "So cute" });

            migrationBuilder.InsertData(
                table: "doctors",
                columns: new[] { "doctorid", "addressid", "balanceid", "dob", "doctortitleid", "firstname", "humangenderid", "lastname", "middlename", "phonenumber", "pronounid", "schoolid", "userid" },
                values: new object[,]
                {
                    { 6, 7, 666, new DateTime(1978, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Patches", 66, "Whisper", null, "05434561275", 6, null, 666 },
                    { 9, 12, 128, new DateTime(1980, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Anastacia", 128, "Catarina", "Ciaran", "05341299154", 9, null, 128 }
                });

            migrationBuilder.InsertData(
                table: "notuserparents",
                columns: new[] { "notuserparentid", "addressid", "email", "firstname", "lastname", "middlename", "phonenumber" },
                values: new object[] { 9, 9, "GaelSlv@hotmail.com", "Gael", "Siegward", "Oscar", "05421238573" });

            migrationBuilder.InsertData(
                table: "petparents",
                columns: new[] { "petparentid", "addressid", "balanceid", "dob", "firstname", "humangenderid", "lastname", "middlename", "phonenumber", "pronounid", "userid" },
                values: new object[] { 6, 6, 6, new DateTime(1999, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Artorias", 6, "Astora", "Solaire", "058745683324", 6, 6 });

            migrationBuilder.InsertData(
                table: "doctorinformations",
                columns: new[] { "doctorid", "doctorinformationtext" },
                values: new object[,]
                {
                    { 6, "Hi, I am Dr. Patches, a veterinarian with over 10 years of experience in the field. I received my Doctor of Veterinary Medicine degree from the University of California, Davis and have since worked at a variety of clinics, caring for all types of animals and their petparents. My specialty is in small animal medicine, but I am well-versed in treating all kinds of creatures, from cats and dogs to birds and reptiles. I am passionate about helping animals and their owners, and take pride in being able to diagnose and treat a wide range of conditions. In my free time, I enjoy volunteering at local animal shelters and spending time with my own pets, which include a rescue dog and two cats. I believe that effective communication with petparents is crucial in providing the best care for their beloved animals." },
                    { 9, "As a veterinarian, I am constantly learning and growing in my profession. I am passionate about providing the best care possible to my patients, and am dedicated to staying up-to-date on the latest advaances in veterinary medicine. I understand that pets are more than just animals to their parents - they are members of the family, and I treat each one with the same care and respect I would any other family member. I take the time to listen to my clients and understand their concerns, and work with them to develop a personalized treatment plan that meets the needs of both the animal and the parent. One of the things I enjoy most about being a veterinarian is the opportunity to build long-term relationships with my patients and their parents. I love seeing my patients grow and thrive under my care, and take great pride in being able to help them live happy and healthy lives." }
                });

            migrationBuilder.InsertData(
                table: "notuserappointments",
                columns: new[] { "appointmentid", "appointmentdate", "appointmentstatussid", "doctorid", "notuserparentnpersonid", "notuserparentnpetnotuserparenpetid", "timecreated" },
                values: new object[] { 6, new DateTime(2022, 12, 21, 2, 0, 4, 361, DateTimeKind.Local).AddTicks(1681), 8, 9, 9, null, new DateTime(2022, 11, 21, 2, 0, 4, 361, DateTimeKind.Local).AddTicks(1667) });

            migrationBuilder.InsertData(
                table: "notuserparentnpet",
                columns: new[] { "notuserparenpetid", "animalid", "notuserparentid", "notuserparentspetanimalid" },
                values: new object[] { 9, 9, 9, null });

            migrationBuilder.InsertData(
                table: "petsnpersons",
                columns: new[] { "petnpersonid", "animalid", "petparentid" },
                values: new object[] { 6, 6, 6 });

            migrationBuilder.InsertData(
                table: "appointments",
                columns: new[] { "appointmentid", "appointmentdate", "appointmentstatussid", "doctorid", "petnpersonid", "timecreated" },
                values: new object[] { 6, new DateTime(2023, 1, 30, 2, 0, 4, 361, DateTimeKind.Local).AddTicks(1404), 6, 6, 6, new DateTime(2022, 12, 31, 2, 0, 4, 361, DateTimeKind.Local).AddTicks(1401) });

            migrationBuilder.CreateIndex(
                name: "ix_addresses_districtid",
                table: "addresses",
                column: "districtid");

            migrationBuilder.CreateIndex(
                name: "ix_appointments_appointmentstatussid",
                table: "appointments",
                column: "appointmentstatussid");

            migrationBuilder.CreateIndex(
                name: "ix_appointments_doctorid",
                table: "appointments",
                column: "doctorid");

            migrationBuilder.CreateIndex(
                name: "ix_appointments_petnpersonid",
                table: "appointments",
                column: "petnpersonid");

            migrationBuilder.CreateIndex(
                name: "ix_district_cityid",
                table: "district",
                column: "cityid");

            migrationBuilder.CreateIndex(
                name: "ix_doctors_addressid",
                table: "doctors",
                column: "addressid");

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
                name: "ix_notuserappointments_appointmentstatussid",
                table: "notuserappointments",
                column: "appointmentstatussid");

            migrationBuilder.CreateIndex(
                name: "ix_notuserappointments_doctorid",
                table: "notuserappointments",
                column: "doctorid");

            migrationBuilder.CreateIndex(
                name: "ix_notuserappointments_notuserparentnpetnotuserparenpetid",
                table: "notuserappointments",
                column: "notuserparentnpetnotuserparenpetid");

            migrationBuilder.CreateIndex(
                name: "ix_notuserparentnpet_notuserparentid",
                table: "notuserparentnpet",
                column: "notuserparentid");

            migrationBuilder.CreateIndex(
                name: "ix_notuserparentnpet_notuserparentspetanimalid",
                table: "notuserparentnpet",
                column: "notuserparentspetanimalid");

            migrationBuilder.CreateIndex(
                name: "ix_notuserparents_addressid",
                table: "notuserparents",
                column: "addressid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_notuserparentspet_breedid",
                table: "notuserparentspet",
                column: "breedid");

            migrationBuilder.CreateIndex(
                name: "ix_notuserparentspet_patientinformationid",
                table: "notuserparentspet",
                column: "patientinformationid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_notuserparentspet_petgenderid",
                table: "notuserparentspet",
                column: "petgenderid");

            migrationBuilder.CreateIndex(
                name: "ix_notuserparentspet_specieid",
                table: "notuserparentspet",
                column: "specieid");

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
                name: "ix_petparents_addressid",
                table: "petparents",
                column: "addressid",
                unique: true);

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
                name: "ix_pets_patientinformationid",
                table: "pets",
                column: "patientinformationid",
                unique: true);

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "adoptinfos");

            migrationBuilder.DropTable(
                name: "appointments");

            migrationBuilder.DropTable(
                name: "doctorinformations");

            migrationBuilder.DropTable(
                name: "doctorschools");

            migrationBuilder.DropTable(
                name: "notuserappointments");

            migrationBuilder.DropTable(
                name: "petsnpersons");

            migrationBuilder.DropTable(
                name: "appointmentstatuses");

            migrationBuilder.DropTable(
                name: "doctors");

            migrationBuilder.DropTable(
                name: "notuserparentnpet");

            migrationBuilder.DropTable(
                name: "petparents");

            migrationBuilder.DropTable(
                name: "pets");

            migrationBuilder.DropTable(
                name: "doctortitles");

            migrationBuilder.DropTable(
                name: "school");

            migrationBuilder.DropTable(
                name: "notuserparents");

            migrationBuilder.DropTable(
                name: "notuserparentspet");

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
                name: "addresses");

            migrationBuilder.DropTable(
                name: "breeds");

            migrationBuilder.DropTable(
                name: "patientinformations");

            migrationBuilder.DropTable(
                name: "petgenders");

            migrationBuilder.DropTable(
                name: "species");

            migrationBuilder.DropTable(
                name: "rolees");

            migrationBuilder.DropTable(
                name: "district");

            migrationBuilder.DropTable(
                name: "statuslevels");

            migrationBuilder.DropTable(
                name: "city");
        }
    }
}
