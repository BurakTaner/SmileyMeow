using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmileyMeow.Migrations
{
    /// <inheritdoc />
    public partial class Dummydataaddedforallmodels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "passwordrepeat",
                table: "userrs");

            migrationBuilder.RenameColumn(
                name: "personid",
                table: "balances",
                newName: "balanceid");

            migrationBuilder.AddColumn<int>(
                name: "humangenderid",
                table: "petparents",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "humangenderid",
                table: "doctors",
                type: "integer",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.InsertData(
                table: "appointments",
                columns: new[] { "doctorid", "petnpersonid", "appointmentdate", "timecreated" },
                values: new object[] { 6, 6, new DateTime(2023, 1, 20, 19, 54, 13, 645, DateTimeKind.Local).AddTicks(897), new DateTime(2022, 12, 21, 19, 54, 13, 645, DateTimeKind.Local).AddTicks(894) });

            migrationBuilder.InsertData(
                table: "balances",
                columns: new[] { "balanceid", "personbalance" },
                values: new object[,]
                {
                    { 6, 150.55m },
                    { 666, 90.65m }
                });

            migrationBuilder.InsertData(
                table: "doctorschools",
                columns: new[] { "doctorid", "schoolid" },
                values: new object[] { 6, 6 });

            migrationBuilder.InsertData(
                table: "humangender",
                columns: new[] { "humangenderid", "gname" },
                values: new object[,]
                {
                    { 6, "Non-Binary" },
                    { 66, "Genderfluid" }
                });

            migrationBuilder.UpdateData(
                table: "pets",
                keyColumn: "animalid",
                keyValue: 6,
                column: "dob",
                value: new DateTime(2022, 12, 21, 19, 54, 13, 644, DateTimeKind.Local).AddTicks(9963));

            migrationBuilder.InsertData(
                table: "petsnpersons",
                columns: new[] { "petnpersonid", "animalid", "petparentid" },
                values: new object[] { 6, 6, 6 });

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
                table: "doctors",
                columns: new[] { "doctorid", "balanceid", "dob", "firstname", "humangenderid", "lastname", "middlename", "phonenumber", "schoolid", "userid", "userrid" },
                values: new object[] { 6, 666, new DateTime(1978, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Patches", 66, "Whisper", null, "05434561275", null, 666, null });

            migrationBuilder.InsertData(
                table: "petparents",
                columns: new[] { "petparentid", "balanceid", "dob", "firstname", "humangenderid", "lastname", "middlename", "petanimalid", "phonenumber", "userid", "userrid" },
                values: new object[] { 6, 6, new DateTime(1999, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Artorias", 6, "Astora", "Solaire", null, null, 6, null });

            migrationBuilder.InsertData(
                table: "school",
                columns: new[] { "schoolid", "name", "schooltypeid" },
                values: new object[] { 6, "Harvard", 6 });

            migrationBuilder.InsertData(
                table: "userrs",
                columns: new[] { "userrid", "email", "password", "roleeid" },
                values: new object[,]
                {
                    { 6, "artorias@gmail.com", "sif123456", 6 },
                    { 666, "patches@gmail.com", "patches123456", 666 }
                });

            migrationBuilder.CreateIndex(
                name: "ix_petparents_humangenderid",
                table: "petparents",
                column: "humangenderid");

            migrationBuilder.CreateIndex(
                name: "ix_doctors_humangenderid",
                table: "doctors",
                column: "humangenderid");

            migrationBuilder.AddForeignKey(
                name: "fk_doctors_humangender_humangenderid",
                table: "doctors",
                column: "humangenderid",
                principalTable: "humangender",
                principalColumn: "humangenderid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_petparents_humangender_humangenderid",
                table: "petparents",
                column: "humangenderid",
                principalTable: "humangender",
                principalColumn: "humangenderid",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_doctors_humangender_humangenderid",
                table: "doctors");

            migrationBuilder.DropForeignKey(
                name: "fk_petparents_humangender_humangenderid",
                table: "petparents");

            migrationBuilder.DropTable(
                name: "humangender");

            migrationBuilder.DropIndex(
                name: "ix_petparents_humangenderid",
                table: "petparents");

            migrationBuilder.DropIndex(
                name: "ix_doctors_humangenderid",
                table: "doctors");

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumns: new[] { "doctorid", "petnpersonid" },
                keyValues: new object[] { 6, 6 });

            migrationBuilder.DeleteData(
                table: "doctors",
                keyColumn: "doctorid",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "doctorschools",
                keyColumns: new[] { "doctorid", "schoolid" },
                keyValues: new object[] { 6, 6 });

            migrationBuilder.DeleteData(
                table: "petparents",
                keyColumn: "petparentid",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "petsnpersons",
                keyColumn: "petnpersonid",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "school",
                keyColumn: "schoolid",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "userrs",
                keyColumn: "userrid",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "userrs",
                keyColumn: "userrid",
                keyValue: 666);

            migrationBuilder.DeleteData(
                table: "balances",
                keyColumn: "balanceid",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "balances",
                keyColumn: "balanceid",
                keyValue: 666);

            migrationBuilder.DeleteData(
                table: "rolees",
                keyColumn: "roleeid",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "rolees",
                keyColumn: "roleeid",
                keyValue: 666);

            migrationBuilder.DeleteData(
                table: "schooltype",
                keyColumn: "schooltypeid",
                keyValue: 6);

            migrationBuilder.DropColumn(
                name: "humangenderid",
                table: "petparents");

            migrationBuilder.DropColumn(
                name: "humangenderid",
                table: "doctors");

            migrationBuilder.RenameColumn(
                name: "balanceid",
                table: "balances",
                newName: "personid");

            migrationBuilder.AddColumn<string>(
                name: "passwordrepeat",
                table: "userrs",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "pets",
                keyColumn: "animalid",
                keyValue: 6,
                column: "dob",
                value: new DateTime(2022, 12, 21, 16, 38, 27, 374, DateTimeKind.Local).AddTicks(9541));
        }
    }
}
