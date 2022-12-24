using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SmileyMeow.Migrations
{
    /// <inheritdoc />
    public partial class Doctortitleadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "doctortitleid",
                table: "doctors",
                type: "integer",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctorid", "petnpersonid" },
                keyValues: new object[] { 6, 6 },
                columns: new[] { "appointmentdate", "timecreated" },
                values: new object[] { new DateTime(2023, 1, 23, 17, 24, 44, 629, DateTimeKind.Local).AddTicks(3155), new DateTime(2022, 12, 24, 17, 24, 44, 629, DateTimeKind.Local).AddTicks(3152) });

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "doctorid",
                keyValue: 6,
                column: "doctortitleid",
                value: 6);

            migrationBuilder.InsertData(
                table: "doctortitles",
                columns: new[] { "doctortitleid", "tfullform", "tshortform" },
                values: new object[] { 6, "Vetenerian", "Dr." });

            migrationBuilder.UpdateData(
                table: "pets",
                keyColumn: "animalid",
                keyValue: 6,
                column: "dob",
                value: new DateTime(2022, 12, 24, 17, 24, 44, 629, DateTimeKind.Local).AddTicks(2373));

            migrationBuilder.CreateIndex(
                name: "ix_doctors_doctortitleid",
                table: "doctors",
                column: "doctortitleid");

            migrationBuilder.AddForeignKey(
                name: "fk_doctors_doctortitles_doctortitleid",
                table: "doctors",
                column: "doctortitleid",
                principalTable: "doctortitles",
                principalColumn: "doctortitleid",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_doctors_doctortitles_doctortitleid",
                table: "doctors");

            migrationBuilder.DropTable(
                name: "doctortitles");

            migrationBuilder.DropIndex(
                name: "ix_doctors_doctortitleid",
                table: "doctors");

            migrationBuilder.DropColumn(
                name: "doctortitleid",
                table: "doctors");

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctorid", "petnpersonid" },
                keyValues: new object[] { 6, 6 },
                columns: new[] { "appointmentdate", "timecreated" },
                values: new object[] { new DateTime(2023, 1, 20, 19, 54, 13, 645, DateTimeKind.Local).AddTicks(897), new DateTime(2022, 12, 21, 19, 54, 13, 645, DateTimeKind.Local).AddTicks(894) });

            migrationBuilder.UpdateData(
                table: "pets",
                keyColumn: "animalid",
                keyValue: 6,
                column: "dob",
                value: new DateTime(2022, 12, 21, 19, 54, 13, 644, DateTimeKind.Local).AddTicks(9963));
        }
    }
}
