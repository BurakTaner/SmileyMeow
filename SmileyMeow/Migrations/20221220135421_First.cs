using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SmileyMeow.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "adoptinfos",
                columns: table => new
                {
                    animalid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    adopttext = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_adoptinfos", x => x.animalid);
                });

            migrationBuilder.CreateTable(
                name: "appointments",
                columns: table => new
                {
                    petnpersonid = table.Column<int>(type: "integer", nullable: false),
                    doctorid = table.Column<int>(type: "integer", nullable: false),
                    timecreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    appointmentdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_appointments", x => new { x.petnpersonid, x.doctorid });
                });

            migrationBuilder.CreateTable(
                name: "balances",
                columns: table => new
                {
                    personid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    personbalance = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_balances", x => x.personid);
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
                    passwordrepeat = table.Column<string>(type: "text", nullable: true),
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
                    description = table.Column<string>(type: "text", nullable: true)
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
                name: "doctors",
                columns: table => new
                {
                    doctorid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    firstname = table.Column<string>(type: "text", nullable: true),
                    middlename = table.Column<string>(type: "text", nullable: true),
                    lastname = table.Column<string>(type: "text", nullable: true),
                    dob = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    address = table.Column<string>(type: "text", nullable: true),
                    phonenumber = table.Column<string>(type: "text", nullable: true),
                    userid = table.Column<int>(type: "integer", nullable: false),
                    userrid = table.Column<int>(type: "integer", nullable: true),
                    balanceid = table.Column<int>(type: "integer", nullable: false),
                    schoolid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_doctors", x => x.doctorid);
                    table.ForeignKey(
                        name: "fk_doctors_balances_balanceid",
                        column: x => x.balanceid,
                        principalTable: "balances",
                        principalColumn: "personid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_doctors_school_schoolid",
                        column: x => x.schoolid,
                        principalTable: "school",
                        principalColumn: "schoolid");
                    table.ForeignKey(
                        name: "fk_doctors_userrs_userrid",
                        column: x => x.userrid,
                        principalTable: "userrs",
                        principalColumn: "userrid");
                });

            migrationBuilder.CreateTable(
                name: "pets",
                columns: table => new
                {
                    animalid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    dob = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    petgenderid = table.Column<int>(type: "integer", nullable: false),
                    specieid = table.Column<int>(type: "integer", nullable: false),
                    breedid = table.Column<int>(type: "integer", nullable: false),
                    patientİnformationpatientinformationid = table.Column<int>(type: "integer", nullable: true),
                    adoptioninfoanimalid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_pets", x => x.animalid);
                    table.ForeignKey(
                        name: "fk_pets_adoptinfos_adoptioninfotempid",
                        column: x => x.adoptioninfoanimalid,
                        principalTable: "adoptinfos",
                        principalColumn: "animalid");
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
                name: "petparents",
                columns: table => new
                {
                    petparentid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    firstname = table.Column<string>(type: "text", nullable: true),
                    middlename = table.Column<string>(type: "text", nullable: true),
                    lastname = table.Column<string>(type: "text", nullable: true),
                    dob = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    address = table.Column<string>(type: "text", nullable: true),
                    phonenumber = table.Column<string>(type: "text", nullable: true),
                    userid = table.Column<int>(type: "integer", nullable: false),
                    userrid = table.Column<int>(type: "integer", nullable: true),
                    balanceid = table.Column<int>(type: "integer", nullable: false),
                    petanimalid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_petparents", x => x.petparentid);
                    table.ForeignKey(
                        name: "fk_petparents_balances_balanceid",
                        column: x => x.balanceid,
                        principalTable: "balances",
                        principalColumn: "personid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_petparents_pets_pettempid",
                        column: x => x.petanimalid,
                        principalTable: "pets",
                        principalColumn: "animalid");
                    table.ForeignKey(
                        name: "fk_petparents_userrs_userrid",
                        column: x => x.userrid,
                        principalTable: "userrs",
                        principalColumn: "userrid");
                });

            migrationBuilder.CreateIndex(
                name: "ix_doctors_balanceid",
                table: "doctors",
                column: "balanceid");

            migrationBuilder.CreateIndex(
                name: "ix_doctors_schoolid",
                table: "doctors",
                column: "schoolid");

            migrationBuilder.CreateIndex(
                name: "ix_doctors_userrid",
                table: "doctors",
                column: "userrid");

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
                name: "ix_petparents_petanimalid",
                table: "petparents",
                column: "petanimalid");

            migrationBuilder.CreateIndex(
                name: "ix_petparents_userrid",
                table: "petparents",
                column: "userrid");

            migrationBuilder.CreateIndex(
                name: "ix_pets_adoptioninfoanimalid",
                table: "pets",
                column: "adoptioninfoanimalid");

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
                name: "appointments");

            migrationBuilder.DropTable(
                name: "doctors");

            migrationBuilder.DropTable(
                name: "doctorschools");

            migrationBuilder.DropTable(
                name: "petparents");

            migrationBuilder.DropTable(
                name: "petsnpersons");

            migrationBuilder.DropTable(
                name: "school");

            migrationBuilder.DropTable(
                name: "balances");

            migrationBuilder.DropTable(
                name: "pets");

            migrationBuilder.DropTable(
                name: "userrs");

            migrationBuilder.DropTable(
                name: "schooltype");

            migrationBuilder.DropTable(
                name: "adoptinfos");

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
                name: "statuslevels");
        }
    }
}
