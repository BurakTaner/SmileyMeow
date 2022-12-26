using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AnimalAPI.Migrations
{
    /// <inheritdoc />
    public partial class animalınfoadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "name",
                table: "animals");

            migrationBuilder.AddColumn<int>(
                name: "animalinfoid",
                table: "animals",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "animalinfos",
                columns: table => new
                {
                    animalinfoid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    animalinformation = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_animalinfos", x => x.animalinfoid);
                });

            migrationBuilder.InsertData(
                table: "animalinfos",
                columns: new[] { "animalinfoid", "animalinformation" },
                values: new object[] { 6, "Torrent is a majestic wild horse of the Mangalarga Marchador species, native to the rolling grasslands of Brazil. With a sleek coat and well-muscled body, this animal is a formidable sight as it roams freely through its natural habitat. Known for their intelligence and endurance, the Mangalarga Marchador is a hardy breed that has adapted to survive in a range of environments. This individual is no exception, with a strong and agile body that allows it to navigate the varied terrain of its home. Whether galloping across open fields or navigating rocky cliffs, this animal is a true symbol of the power and beauty of nature." });

            migrationBuilder.UpdateData(
                table: "animals",
                keyColumn: "animalid",
                keyValue: 6,
                column: "animalinfoid",
                value: 6);

            migrationBuilder.CreateIndex(
                name: "ix_animals_animalinfoid",
                table: "animals",
                column: "animalinfoid");

            migrationBuilder.AddForeignKey(
                name: "fk_animals_animalinfos_animalinfoid",
                table: "animals",
                column: "animalinfoid",
                principalTable: "animalinfos",
                principalColumn: "animalinfoid",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_animals_animalinfos_animalinfoid",
                table: "animals");

            migrationBuilder.DropTable(
                name: "animalinfos");

            migrationBuilder.DropIndex(
                name: "ix_animals_animalinfoid",
                table: "animals");

            migrationBuilder.DropColumn(
                name: "animalinfoid",
                table: "animals");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "animals",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "animals",
                keyColumn: "animalid",
                keyValue: 6,
                column: "name",
                value: "Torrent");
        }
    }
}
