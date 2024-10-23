using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Journey",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Origin = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Destination = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Price = table.Column<float>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Journey", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Flight",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Origin = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Destination = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Price = table.Column<float>(type: "float", nullable: false),
                    JourneyId = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flight", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flight_Journey_JourneyId",
                        column: x => x.JourneyId,
                        principalTable: "Journey",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Transport",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FlightCarrier = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FlightNumber = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FlightId = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transport_Flight_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flight",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Journey",
                columns: new[] { "Id", "Destination", "Origin", "Price" },
                values: new object[,]
                {
                    { "49f733c5-4b65-4390-bc60-ec7c3471e028", "MED", "CAL", 1500f },
                    { "9c9b5d14-e22b-4a4d-9792-f28e255e2a0d", "BTA", "BGA", 1000f },
                    { "b6ec5b59-2c9a-4df8-9072-1a9e23d9a1c5", "STA", "MED", 4000f },
                    { "d5a6a21c-023d-42ed-b98b-22d3a728f226", "MED", "BGA", 1000f },
                    { "f0ebc49f-8e0a-4a3b-b3ed-7e14285be7a3", "CTG", "BTA", 2000f }
                });

            migrationBuilder.InsertData(
                table: "Flight",
                columns: new[] { "Id", "Destination", "JourneyId", "Origin", "Price" },
                values: new object[,]
                {
                    { "097577c4-db87-4e10-a794-8382f2ed0484", "CTG", "9c9b5d14-e22b-4a4d-9792-f28e255e2a0d", "MED", 1000f },
                    { "0e8677a0-04ae-4fb3-9765-309a71c7624c", "STA", "b6ec5b59-2c9a-4df8-9072-1a9e23d9a1c5", "MED", 4000f },
                    { "5d1391ea-faf9-4663-b74d-94e54843d52d", "CTG", "f0ebc49f-8e0a-4a3b-b3ed-7e14285be7a3", "BTA", 2000f },
                    { "770202d7-08ba-49e8-ab66-8855be4007e9", "BTA", "9c9b5d14-e22b-4a4d-9792-f28e255e2a0d", "BGA", 1000f },
                    { "a24a3289-30a5-4ec8-bd07-034051c76259", "MED", "d5a6a21c-023d-42ed-b98b-22d3a728f226", "BGA", 1000f },
                    { "a73e31d5-7516-4374-968c-c69ccaf00ee9", "MED", "49f733c5-4b65-4390-bc60-ec7c3471e028", "BTA", 1000f },
                    { "b179ec78-f0cf-4bed-9139-7027300d72bf", "CTG", "f0ebc49f-8e0a-4a3b-b3ed-7e14285be7a3", "CAL", 1000f },
                    { "e4efad61-b061-4fbf-aec8-4cd623536f95", "MED", "49f733c5-4b65-4390-bc60-ec7c3471e028", "CAL", 1500f }
                });

            migrationBuilder.InsertData(
                table: "Transport",
                columns: new[] { "Id", "FlightCarrier", "FlightId", "FlightNumber" },
                values: new object[,]
                {
                    { "0b4a1620-3827-45fb-b621-dd3a8116550b", "AV", "e4efad61-b061-4fbf-aec8-4cd623536f95", "8090" },
                    { "0c5e7a1f-29c8-4340-832e-a1b277433f8c", "AV", "5d1391ea-faf9-4663-b74d-94e54843d52d", "8030" },
                    { "41936778-333e-443f-b260-002577b8e467", "AV", "770202d7-08ba-49e8-ab66-8855be4007e9", "8070" },
                    { "46753d9b-2560-4b13-a51a-f6aa2ab8c732", "AV", "a24a3289-30a5-4ec8-bd07-034051c76259", "8060" },
                    { "7d838ddc-1873-4697-92c9-79f13da906bd", "AV", "770202d7-08ba-49e8-ab66-8855be4007e9", "8020" },
                    { "a2d1de37-cfde-4b0b-989a-6c772d7452e2", "AV", "5d1391ea-faf9-4663-b74d-94e54843d52d", "8080" },
                    { "b02120b6-651d-4084-aa1c-47c86aed61c5", "AV", "e4efad61-b061-4fbf-aec8-4cd623536f95", "8040" },
                    { "e966a315-594e-41da-a00f-67c8fe48a906", "AV", "0e8677a0-04ae-4fb3-9765-309a71c7624c", "8050" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flight_JourneyId",
                table: "Flight",
                column: "JourneyId");

            migrationBuilder.CreateIndex(
                name: "IX_Transport_FlightId",
                table: "Transport",
                column: "FlightId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transport");

            migrationBuilder.DropTable(
                name: "Flight");

            migrationBuilder.DropTable(
                name: "Journey");
        }
    }
}
