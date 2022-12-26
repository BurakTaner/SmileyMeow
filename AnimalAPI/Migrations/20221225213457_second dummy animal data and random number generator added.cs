using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnimalAPI.Migrations
{
    /// <inheritdoc />
    public partial class seconddummyanimaldataandrandomnumbergeneratoradded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "animalinfos",
                keyColumn: "animalinfoid",
                keyValue: 6,
                column: "animalinformation",
                value: "The Shire is a British breed of draught horse. It is usually black, bay, or grey. It is a tall breed, and Shires have at various times held world records both for the largest horse and for the tallest horse. The Shire has a great capacity for weight-pulling; it was used for farm work, to tow barges at a time when the canal system was the principal means of goods transport, and as a cart-horse for road transport. One traditional use was for pulling brewer's drays for delivery of beer, and some are still used in this way; others are used for forestry, for riding and for commercial promotion.");

            migrationBuilder.InsertData(
                table: "animalinfos",
                columns: new[] { "animalinfoid", "animalinformation" },
                values: new object[] { 7, "The Maine Coon is a large domesticated cat breed. It is one of the oldest natural breeds in North America. The breed originated in the U.S. state of Maine, where it is the official state cat.The breed was popular in cat shows in the late 19th century, but its existence became threatened when long-haired breeds from overseas were introduced in the early 20th century. The Maine Coon has since made a comeback and is now the third most popular pedigreed cat breed in the world." });

            migrationBuilder.UpdateData(
                table: "breeds",
                keyColumn: "breedid",
                keyValue: 6,
                column: "bname",
                value: "Shire Horse");

            migrationBuilder.InsertData(
                table: "breeds",
                columns: new[] { "breedid", "bname" },
                values: new object[] { 7, "Maine Coon" });

            migrationBuilder.InsertData(
                table: "species",
                columns: new[] { "specieid", "sname" },
                values: new object[] { 7, "Cat" });

            migrationBuilder.InsertData(
                table: "animals",
                columns: new[] { "animalid", "animalinfoid", "breedid", "specieid" },
                values: new object[] { 7, 7, 7, 7 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "animals",
                keyColumn: "animalid",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "animalinfos",
                keyColumn: "animalinfoid",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "breeds",
                keyColumn: "breedid",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "species",
                keyColumn: "specieid",
                keyValue: 7);

            migrationBuilder.UpdateData(
                table: "animalinfos",
                keyColumn: "animalinfoid",
                keyValue: 6,
                column: "animalinformation",
                value: "Torrent is a majestic wild horse of the Mangalarga Marchador species, native to the rolling grasslands of Brazil. With a sleek coat and well-muscled body, this animal is a formidable sight as it roams freely through its natural habitat. Known for their intelligence and endurance, the Mangalarga Marchador is a hardy breed that has adapted to survive in a range of environments. This individual is no exception, with a strong and agile body that allows it to navigate the varied terrain of its home. Whether galloping across open fields or navigating rocky cliffs, this animal is a true symbol of the power and beauty of nature.");

            migrationBuilder.UpdateData(
                table: "breeds",
                keyColumn: "breedid",
                keyValue: 6,
                column: "bname",
                value: "Mangalarga Marchador");
        }
    }
}
