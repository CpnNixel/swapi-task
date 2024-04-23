using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Swapi.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Films",
                columns: new[]
                {
                    "Id",
                    "Director",
                    "Episode",
                    "OpeningCrawl",
                    "Producer",
                    "ReleaseDate",
                    "Title"
                },
                values: new object[,]
                {
                    {
                        1,
                        "George Lucas",
                        4,
                        "It is a period of civil war...",
                        "Gary Kurtz, Rick McCallum",
                        "1977-05-25",
                        "A New Hope"
                    },
                    {
                        2,
                        "Irvin Kershner",
                        5,
                        "It is a dark time for the Rebellion...",
                        "Gary Kurtz, Rick McCallum",
                        "1980-05-21",
                        "The Empire Strikes Back"
                    }
                }
            );

            migrationBuilder.InsertData(
                table: "People",
                columns: new[]
                {
                    "Id",
                    "BirthYear",
                    "EyeColor",
                    "Gender",
                    "HairColor",
                    "Height",
                    "HomeWorldId",
                    "Mass",
                    "Name",
                    "SkinColor"
                },
                values: new object[,]
                {
                    {
                        1,
                        "19BBY",
                        "Blue",
                        "Male",
                        "Blond",
                        "172",
                        null,
                        "77",
                        "Luke Skywalker",
                        "Fair"
                    },
                    {
                        2,
                        "19BBY",
                        "Brown",
                        "Female",
                        "Brown",
                        "150",
                        null,
                        "49",
                        "Leia Organa",
                        "Light"
                    }
                }
            );

            migrationBuilder.InsertData(
                table: "Planets",
                columns: new[]
                {
                    "Id",
                    "Climate",
                    "Diameter",
                    "Gravity",
                    "Name",
                    "OrbitalPeriod",
                    "Population",
                    "RotationSpeed",
                    "SurfaceWater",
                    "Terrain"
                },
                values: new object[,]
                {
                    {
                        1,
                        "Arid",
                        "10465",
                        "1 standard",
                        "Tatooine",
                        "304",
                        "200000",
                        "23",
                        "1",
                        "Desert"
                    },
                    {
                        2,
                        "Frozen",
                        "7200",
                        "1.1 standard",
                        "Hoth",
                        "549",
                        "unknown",
                        "23",
                        "100",
                        "Tundra, Ice caves, Mountain ranges"
                    }
                }
            );

            migrationBuilder.InsertData(
                table: "Starships",
                columns: new[]
                {
                    "Id",
                    "CargoCapacity",
                    "Consumables",
                    "CostInCredits",
                    "Crew",
                    "HyperDriveRating",
                    "Length",
                    "Manufacturer",
                    "MaxAtmospheringSpeed",
                    "Megalights",
                    "Model",
                    "Name",
                    "Passengers",
                    "StarshipClass"
                },
                values: new object[,]
                {
                    {
                        1,
                        "110",
                        "1 week",
                        "149999",
                        "1",
                        "1.0",
                        "12.5",
                        "Incom Corporation, Koensayr Manufacturing",
                        "1050",
                        "100",
                        "T-65 X-wing",
                        "X-wing Starfighter",
                        "0",
                        "Starfighter"
                    },
                    {
                        2,
                        "3000000",
                        "1 year",
                        "3500000",
                        "30-165",
                        "2.0",
                        "150",
                        "Corellian Engineering Corporation",
                        "950",
                        "60",
                        "CR90 corvette",
                        "CR90 corvette",
                        "600",
                        "Corvette"
                    }
                }
            );

            migrationBuilder.InsertData(
                table: "FilmPlanet",
                columns: new[] { "Id", "FilmId", "PlanetId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 }
                }
            );

            migrationBuilder.InsertData(
                table: "FilmStarship",
                columns: new[] { "Id", "FilmId", "StarshipId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 }
                }
            );

            migrationBuilder.InsertData(
                table: "PersonFilm",
                columns: new[] { "Id", "FilmId", "PersonId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 1, 2 }
                }
            );

            migrationBuilder.InsertData(
                table: "PersonPlanet",
                columns: new[] { "Id", "PersonId", "PlanetId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 }
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(table: "FilmPlanet", keyColumn: "Id", keyValue: 1);

            migrationBuilder.DeleteData(table: "FilmPlanet", keyColumn: "Id", keyValue: 2);

            migrationBuilder.DeleteData(table: "FilmStarship", keyColumn: "Id", keyValue: 1);

            migrationBuilder.DeleteData(table: "FilmStarship", keyColumn: "Id", keyValue: 2);

            migrationBuilder.DeleteData(table: "PersonFilm", keyColumn: "Id", keyValue: 1);

            migrationBuilder.DeleteData(table: "PersonFilm", keyColumn: "Id", keyValue: 2);

            migrationBuilder.DeleteData(table: "PersonFilm", keyColumn: "Id", keyValue: 3);

            migrationBuilder.DeleteData(table: "PersonPlanet", keyColumn: "Id", keyValue: 1);

            migrationBuilder.DeleteData(table: "PersonPlanet", keyColumn: "Id", keyValue: 2);

            migrationBuilder.DeleteData(table: "Films", keyColumn: "Id", keyValue: 1);

            migrationBuilder.DeleteData(table: "Films", keyColumn: "Id", keyValue: 2);

            migrationBuilder.DeleteData(table: "People", keyColumn: "Id", keyValue: 1);

            migrationBuilder.DeleteData(table: "People", keyColumn: "Id", keyValue: 2);

            migrationBuilder.DeleteData(table: "Planets", keyColumn: "Id", keyValue: 1);

            migrationBuilder.DeleteData(table: "Planets", keyColumn: "Id", keyValue: 2);

            migrationBuilder.DeleteData(table: "Starships", keyColumn: "Id", keyValue: 1);

            migrationBuilder.DeleteData(table: "Starships", keyColumn: "Id", keyValue: 2);
        }
    }
}
