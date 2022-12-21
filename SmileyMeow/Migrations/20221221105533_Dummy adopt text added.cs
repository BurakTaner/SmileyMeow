using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmileyMeow.Migrations
{
    /// <inheritdoc />
    public partial class Dummyadopttextadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "adoptinfos",
                columns: new[] { "animalid", "adopttext" },
                values: new object[] { 6, "So cute" });

            migrationBuilder.UpdateData(
                table: "pets",
                keyColumn: "animalid",
                keyValue: 6,
                column: "dob",
                value: new DateTime(2022, 12, 21, 13, 55, 32, 819, DateTimeKind.Local).AddTicks(7489));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "adoptinfos",
                keyColumn: "animalid",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "pets",
                keyColumn: "animalid",
                keyValue: 6,
                column: "dob",
                value: new DateTime(2022, 12, 21, 1, 21, 33, 575, DateTimeKind.Local).AddTicks(2271));
        }
    }
}
