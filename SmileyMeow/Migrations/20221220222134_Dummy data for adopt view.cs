using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmileyMeow.Migrations
{
    /// <inheritdoc />
    public partial class Dummydataforadoptview : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "dob",
                table: "pets",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "dob",
                table: "petparents",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "dob",
                table: "doctors",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "timecreated",
                table: "appointments",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "appointmentdate",
                table: "appointments",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.InsertData(
                table: "breeds",
                columns: new[] { "breedid", "bname" },
                values: new object[] { 6, "Ragdoll" });

            migrationBuilder.InsertData(
                table: "petgenders",
                columns: new[] { "petgenderid", "gname" },
                values: new object[] { 6, "Female" });

            migrationBuilder.InsertData(
                table: "species",
                columns: new[] { "specieid", "sname" },
                values: new object[] { 6, "Wolf" });

            migrationBuilder.InsertData(
                table: "pets",
                columns: new[] { "animalid", "adoptioninfoanimalid", "breedid", "dob", "isadoptable", "name", "patientİnformationpatientinformationid", "petgenderid", "specieid" },
                values: new object[] { 6, null, 6, new DateTime(2022, 12, 21, 1, 21, 33, 575, DateTimeKind.Local).AddTicks(2271), true, "Sif", null, 6, 6 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "pets",
                keyColumn: "animalid",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "breeds",
                keyColumn: "breedid",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "petgenders",
                keyColumn: "petgenderid",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "species",
                keyColumn: "specieid",
                keyValue: 6);

            migrationBuilder.AlterColumn<DateTime>(
                name: "dob",
                table: "pets",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "dob",
                table: "petparents",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "dob",
                table: "doctors",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "timecreated",
                table: "appointments",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "appointmentdate",
                table: "appointments",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");
        }
    }
}
