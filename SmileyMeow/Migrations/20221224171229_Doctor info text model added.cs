using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmileyMeow.Migrations
{
    /// <inheritdoc />
    public partial class Doctorinfotextmodeladded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctorid", "petnpersonid" },
                keyValues: new object[] { 6, 6 },
                columns: new[] { "appointmentdate", "timecreated" },
                values: new object[] { new DateTime(2023, 1, 23, 20, 12, 28, 704, DateTimeKind.Local).AddTicks(3943), new DateTime(2022, 12, 24, 20, 12, 28, 704, DateTimeKind.Local).AddTicks(3940) });

            migrationBuilder.InsertData(
                table: "doctorinfos",
                columns: new[] { "doctorid", "doctorinformation" },
                values: new object[] { 6, "Hi, I am Dr. Patches, a veterinarian with over 10 years of experience in the field. I received my Doctor of Veterinary Medicine degree from the University of California, Davis and have since worked at a variety of clinics, caring for all types of animals and their petparents. My specialty is in small animal medicine, but I am well-versed in treating all kinds of creatures, from cats and dogs to birds and reptiles. I am passionate about helping animals and their owners, and take pride in being able to diagnose and treat a wide range of conditions. In my free time, I enjoy volunteering at local animal shelters and spending time with my own pets, which include a rescue dog and two cats. I believe that effective communication with petparents is crucial in providing the best care for their beloved animals." });

            migrationBuilder.UpdateData(
                table: "pets",
                keyColumn: "animalid",
                keyValue: 6,
                column: "dob",
                value: new DateTime(2022, 12, 24, 20, 12, 28, 704, DateTimeKind.Local).AddTicks(3075));

            migrationBuilder.UpdateData(
                table: "school",
                keyColumn: "schoolid",
                keyValue: 6,
                column: "name",
                value: "University of California, Davis");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "doctorinfos");

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctorid", "petnpersonid" },
                keyValues: new object[] { 6, 6 },
                columns: new[] { "appointmentdate", "timecreated" },
                values: new object[] { new DateTime(2023, 1, 23, 18, 40, 16, 211, DateTimeKind.Local).AddTicks(7583), new DateTime(2022, 12, 24, 18, 40, 16, 211, DateTimeKind.Local).AddTicks(7579) });

            migrationBuilder.UpdateData(
                table: "pets",
                keyColumn: "animalid",
                keyValue: 6,
                column: "dob",
                value: new DateTime(2022, 12, 24, 18, 40, 16, 211, DateTimeKind.Local).AddTicks(6673));

            migrationBuilder.UpdateData(
                table: "school",
                keyColumn: "schoolid",
                keyValue: 6,
                column: "name",
                value: "Harvard");
        }
    }
}
