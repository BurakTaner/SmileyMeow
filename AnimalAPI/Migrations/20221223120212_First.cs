using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AnimalAPI.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "animals",
                columns: table => new
                {
                    animalid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    specieid = table.Column<int>(type: "integer", nullable: false),
                    breedid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_animals", x => x.animalid);
                    table.ForeignKey(
                        name: "fk_animals_breeds_breedid",
                        column: x => x.breedid,
                        principalTable: "breeds",
                        principalColumn: "breedid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_animals_species_specieid",
                        column: x => x.specieid,
                        principalTable: "species",
                        principalColumn: "specieid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "breeds",
                columns: new[] { "breedid", "bname" },
                values: new object[] { 6, "Mangalarga Marchador" });

            migrationBuilder.InsertData(
                table: "species",
                columns: new[] { "specieid", "sname" },
                values: new object[] { 6, "Horse" });

            migrationBuilder.InsertData(
                table: "animals",
                columns: new[] { "animalid", "breedid", "name", "specieid" },
                values: new object[] { 6, 6, "Torrent", 6 });

            migrationBuilder.CreateIndex(
                name: "ix_animals_breedid",
                table: "animals",
                column: "breedid");

            migrationBuilder.CreateIndex(
                name: "ix_animals_specieid",
                table: "animals",
                column: "specieid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "animals");

            migrationBuilder.DropTable(
                name: "breeds");

            migrationBuilder.DropTable(
                name: "species");
        }
    }
}
