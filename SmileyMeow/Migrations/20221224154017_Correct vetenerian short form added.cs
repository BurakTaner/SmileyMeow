using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmileyMeow.Migrations
{
    /// <inheritdoc />
    public partial class Correctvetenerianshortformadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctorid", "petnpersonid" },
                keyValues: new object[] { 6, 6 },
                columns: new[] { "appointmentdate", "timecreated" },
                values: new object[] { new DateTime(2023, 1, 23, 18, 40, 16, 211, DateTimeKind.Local).AddTicks(7583), new DateTime(2022, 12, 24, 18, 40, 16, 211, DateTimeKind.Local).AddTicks(7579) });

            migrationBuilder.UpdateData(
                table: "doctortitles",
                keyColumn: "doctortitleid",
                keyValue: 6,
                column: "tshortform",
                value: "DVM");

            migrationBuilder.UpdateData(
                table: "pets",
                keyColumn: "animalid",
                keyValue: 6,
                column: "dob",
                value: new DateTime(2022, 12, 24, 18, 40, 16, 211, DateTimeKind.Local).AddTicks(6673));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctorid", "petnpersonid" },
                keyValues: new object[] { 6, 6 },
                columns: new[] { "appointmentdate", "timecreated" },
                values: new object[] { new DateTime(2023, 1, 23, 17, 24, 44, 629, DateTimeKind.Local).AddTicks(3155), new DateTime(2022, 12, 24, 17, 24, 44, 629, DateTimeKind.Local).AddTicks(3152) });

            migrationBuilder.UpdateData(
                table: "doctortitles",
                keyColumn: "doctortitleid",
                keyValue: 6,
                column: "tshortform",
                value: "Dr.");

            migrationBuilder.UpdateData(
                table: "pets",
                keyColumn: "animalid",
                keyValue: 6,
                column: "dob",
                value: new DateTime(2022, 12, 24, 17, 24, 44, 629, DateTimeKind.Local).AddTicks(2373));
        }
    }
}
