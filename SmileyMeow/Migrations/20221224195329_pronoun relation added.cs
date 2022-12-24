using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmileyMeow.Migrations
{
    /// <inheritdoc />
    public partial class pronounrelationadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_doctors_pronoun_pronounid",
                table: "doctors");

            migrationBuilder.DropForeignKey(
                name: "fk_petparents_pronoun_pronounid",
                table: "petparents");

            migrationBuilder.DropIndex(
                name: "ix_petparents_pronounid",
                table: "petparents");

            migrationBuilder.DropIndex(
                name: "ix_doctors_pronounid",
                table: "doctors");

            migrationBuilder.DropPrimaryKey(
                name: "pk_pronoun",
                table: "pronoun");

            migrationBuilder.RenameTable(
                name: "pronoun",
                newName: "pronouns");

            migrationBuilder.AddPrimaryKey(
                name: "pk_pronouns",
                table: "pronouns",
                column: "prounounid");

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctorid", "petnpersonid" },
                keyValues: new object[] { 6, 6 },
                columns: new[] { "appointmentdate", "timecreated" },
                values: new object[] { new DateTime(2023, 1, 23, 22, 53, 27, 814, DateTimeKind.Local).AddTicks(2808), new DateTime(2022, 12, 24, 22, 53, 27, 814, DateTimeKind.Local).AddTicks(2804) });

            migrationBuilder.UpdateData(
                table: "pets",
                keyColumn: "animalid",
                keyValue: 6,
                column: "dob",
                value: new DateTime(2022, 12, 24, 22, 53, 27, 814, DateTimeKind.Local).AddTicks(2061));

            migrationBuilder.CreateIndex(
                name: "ix_petparents_pronounid",
                table: "petparents",
                column: "pronounid");

            migrationBuilder.CreateIndex(
                name: "ix_doctors_pronounid",
                table: "doctors",
                column: "pronounid");

            migrationBuilder.AddForeignKey(
                name: "fk_doctors_pronouns_pronounid",
                table: "doctors",
                column: "pronounid",
                principalTable: "pronouns",
                principalColumn: "prounounid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_petparents_pronouns_pronounid",
                table: "petparents",
                column: "pronounid",
                principalTable: "pronouns",
                principalColumn: "prounounid",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_doctors_pronouns_pronounid",
                table: "doctors");

            migrationBuilder.DropForeignKey(
                name: "fk_petparents_pronouns_pronounid",
                table: "petparents");

            migrationBuilder.DropIndex(
                name: "ix_petparents_pronounid",
                table: "petparents");

            migrationBuilder.DropIndex(
                name: "ix_doctors_pronounid",
                table: "doctors");

            migrationBuilder.DropPrimaryKey(
                name: "pk_pronouns",
                table: "pronouns");

            migrationBuilder.RenameTable(
                name: "pronouns",
                newName: "pronoun");

            migrationBuilder.AddPrimaryKey(
                name: "pk_pronoun",
                table: "pronoun",
                column: "prounounid");

            migrationBuilder.UpdateData(
                table: "appointments",
                keyColumns: new[] { "doctorid", "petnpersonid" },
                keyValues: new object[] { 6, 6 },
                columns: new[] { "appointmentdate", "timecreated" },
                values: new object[] { new DateTime(2023, 1, 23, 22, 22, 47, 833, DateTimeKind.Local).AddTicks(5327), new DateTime(2022, 12, 24, 22, 22, 47, 833, DateTimeKind.Local).AddTicks(5324) });

            migrationBuilder.UpdateData(
                table: "pets",
                keyColumn: "animalid",
                keyValue: 6,
                column: "dob",
                value: new DateTime(2022, 12, 24, 20, 12, 28, 704, DateTimeKind.Local).AddTicks(3075));

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
    }
}
