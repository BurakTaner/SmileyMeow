using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SmileyMeow.Migrations
{
    /// <inheritdoc />
    public partial class Pronounadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "pronounid",
                table: "petparents",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "pronounid",
                table: "doctors",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "doctorinfo",
                columns: table => new
                {
                    doctorid = table.Column<int>(type: "integer", nullable: false),
                    doctorinformation = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_doctorinfo", x => x.doctorid);
                    table.ForeignKey(
                        name: "fk_doctorinfo_doctors_doctorid",
                        column: x => x.doctorid,
                        principalTable: "doctors",
                        principalColumn: "doctorid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pronoun",
                columns: table => new
                {
                    prounounid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    pname = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_pronoun", x => x.prounounid);
                });

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctorid", "petnpersonid" },
                keyValues: new object[] { 6, 6 },
                columns: new[] { "appointmentdate", "timecreated" },
                values: new object[] { new DateTime(2023, 1, 23, 22, 22, 47, 833, DateTimeKind.Local).AddTicks(5327), new DateTime(2022, 12, 24, 22, 22, 47, 833, DateTimeKind.Local).AddTicks(5324) });

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "doctorid",
                keyValue: 6,
                column: "pronounid",
                value: 6);

            migrationBuilder.UpdateData(
                table: "petparents",
                keyColumn: "petparentid",
                keyValue: 6,
                column: "pronounid",
                value: 6);

            migrationBuilder.UpdateData(
                table: "pets",
                keyColumn: "animalid",
                keyValue: 6,
                column: "dob",
                value: new DateTime(2022, 12, 24, 22, 22, 47, 833, DateTimeKind.Local).AddTicks(4520));

            migrationBuilder.InsertData(
                table: "pronoun",
                columns: new[] { "prounounid", "pname" },
                values: new object[] { 6, "They/Them" });

            migrationBuilder.CreateIndex(
                name: "ix_petparents_pronounid",
                table: "petparents",
                column: "pronounid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_doctors_pronounid",
                table: "doctors",
                column: "pronounid",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "fk_doctors_pronoun_pronounid",
                table: "doctors",
                column: "pronounid",
                principalTable: "pronoun",
                principalColumn: "prounounid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_petparents_pronoun_pronounid",
                table: "petparents",
                column: "pronounid",
                principalTable: "pronoun",
                principalColumn: "prounounid",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_doctors_pronoun_pronounid",
                table: "doctors");

            migrationBuilder.DropForeignKey(
                name: "fk_petparents_pronoun_pronounid",
                table: "petparents");

            migrationBuilder.DropTable(
                name: "doctorinfo");

            migrationBuilder.DropTable(
                name: "pronoun");

            migrationBuilder.DropIndex(
                name: "ix_petparents_pronounid",
                table: "petparents");

            migrationBuilder.DropIndex(
                name: "ix_doctors_pronounid",
                table: "doctors");

            migrationBuilder.DropColumn(
                name: "pronounid",
                table: "petparents");

            migrationBuilder.DropColumn(
                name: "pronounid",
                table: "doctors");

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
        }
    }
}
