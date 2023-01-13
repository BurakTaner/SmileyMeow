using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AnimalAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    specieid = table.Column<int>(type: "integer", nullable: false),
                    breedid = table.Column<int>(type: "integer", nullable: false),
                    animalinfoid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_animals", x => x.animalid);
                    table.ForeignKey(
                        name: "fk_animals_animalinfos_animalinfoid",
                        column: x => x.animalinfoid,
                        principalTable: "animalinfos",
                        principalColumn: "animalinfoid",
                        onDelete: ReferentialAction.Cascade);
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
                table: "animalinfos",
                columns: new[] { "animalinfoid", "animalinformation" },
                values: new object[,]
                {
                    { 6, "The Shire is a British breed of draught horse. It is usually black, bay, or grey. It is a tall breed, and Shires have at various times held world records both for the largest horse and for the tallest horse. The Shire has a great capacity for weight-pulling; it was used for farm work, to tow barges at a time when the canal system was the principal means of goods transport, and as a cart-horse for road transport. One traditional use was for pulling brewer's drays for delivery of beer, and some are still used in this way; others are used for forestry, for riding and for commercial promotion." },
                    { 7, "The Maine Coon is a large domesticated cat breed. It is one of the oldest natural breeds in North America. The breed originated in the U.S. state of Maine, where it is the official state cat.The breed was popular in cat shows in the late 19th century, but its existence became threatened when long-haired breeds from overseas were introduced in the early 20th century. The Maine Coon has since made a comeback and is now the third most popular pedigreed cat breed in the world." },
                    { 8, "The axolotl (/æksəlɒtəl/; from Classical Nahuatl: āxōlōtl, Ambystoma mexicanum, is a paedomorphic salamander closely related to the tiger salamander.Axolotls are unusual among amphibians in that they reach adulthood without undergoing metamorphosis. Instead of taking to the land, adults remain aquatic and gilled. The species was originally found in several lakes underlying what is now Mexico City, such as Lake Xochimilco and Lake Chalco.[1] These lakes were drained by Spanish settlers after the conquest of the Aztec Empire, leading to the destruction of much of the axolotl’s natural habitat." },
                    { 9, "The American Rabbit is a breed of rabbit, recognized by the American Rabbit Breeders Association (ARBA) in 1917. By the ARBA standard, American rabbits have a mandolin body shape. It has also been noted for a good 'sweet' temperament and good mothering abilities. As with all domestic rabbits, the American breed is of the species Oryctolagus cuniculus, the European wild rabbit. The American Rabbit was originally accepted into the ARBA as a 'Blue' rabbit, and historically has been characterized as having the deepest, darkest fur of all blue or grey rabbits. The color at its best is 'uniform rich, dark slate-blue, free from white hairs, sandy or rust color" }
                });

            migrationBuilder.InsertData(
                table: "breeds",
                columns: new[] { "breedid", "bname" },
                values: new object[,]
                {
                    { 6, "Shire Horse" },
                    { 7, "Maine Coon" },
                    { 8, "American Rabbit" },
                    { 9, "Axolot" }
                });

            migrationBuilder.InsertData(
                table: "species",
                columns: new[] { "specieid", "sname" },
                values: new object[,]
                {
                    { 6, "Horse" },
                    { 7, "Cat" },
                    { 8, "Rabbit" },
                    { 9, "Salamander" }
                });

            migrationBuilder.InsertData(
                table: "animals",
                columns: new[] { "animalid", "animalinfoid", "breedid", "specieid" },
                values: new object[,]
                {
                    { 6, 6, 6, 6 },
                    { 7, 7, 7, 7 },
                    { 8, 8, 9, 9 },
                    { 9, 9, 8, 8 }
                });

            migrationBuilder.CreateIndex(
                name: "ix_animals_animalinfoid",
                table: "animals",
                column: "animalinfoid");

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
                name: "animalinfos");

            migrationBuilder.DropTable(
                name: "breeds");

            migrationBuilder.DropTable(
                name: "species");
        }
    }
}
