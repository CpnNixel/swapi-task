using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SWapi.Data.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Films",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Episode = table.Column<int>(type: "INTEGER", nullable: false),
                    OpeningCrawl = table.Column<string>(type: "TEXT", nullable: false),
                    Director = table.Column<string>(type: "TEXT", nullable: false),
                    Producer = table.Column<string>(type: "TEXT", nullable: false),
                    ReleaseDate = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Films", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "Planets",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Diameter = table.Column<string>(type: "TEXT", nullable: false),
                    RotationSpeed = table.Column<string>(type: "TEXT", nullable: false),
                    OrbitalPeriod = table.Column<string>(type: "TEXT", nullable: false),
                    Gravity = table.Column<string>(type: "TEXT", nullable: false),
                    Population = table.Column<string>(type: "TEXT", nullable: false),
                    Climate = table.Column<string>(type: "TEXT", nullable: false),
                    Terrain = table.Column<string>(type: "TEXT", nullable: false),
                    SurfaceWater = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planets", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "Starships",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Model = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    StarshipClass = table.Column<string>(type: "TEXT", nullable: false),
                    Manufacturer = table.Column<string>(type: "TEXT", nullable: false),
                    CostInCredits = table.Column<string>(type: "TEXT", nullable: false),
                    Length = table.Column<string>(type: "TEXT", nullable: false),
                    Crew = table.Column<string>(type: "TEXT", nullable: false),
                    Passengers = table.Column<string>(type: "TEXT", nullable: false),
                    MaxAtmospheringSpeed = table.Column<string>(type: "TEXT", nullable: false),
                    HyperDriveRating = table.Column<string>(type: "TEXT", nullable: false),
                    Megalights = table.Column<string>(type: "TEXT", nullable: false),
                    CargoCapacity = table.Column<string>(type: "TEXT", nullable: false),
                    Consumables = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Starships", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "FilmPlanet",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FilmId = table.Column<int>(type: "INTEGER", nullable: false),
                    PlanetId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmPlanet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FilmPlanet_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_FilmPlanet_Planets_PlanetId",
                        column: x => x.PlanetId,
                        principalTable: "Planets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    BirthYear = table.Column<string>(type: "TEXT", nullable: false),
                    EyeColor = table.Column<string>(type: "TEXT", nullable: false),
                    Gender = table.Column<string>(type: "TEXT", nullable: false),
                    HairColor = table.Column<string>(type: "TEXT", nullable: false),
                    Height = table.Column<string>(type: "TEXT", nullable: false),
                    Mass = table.Column<string>(type: "TEXT", nullable: false),
                    SkinColor = table.Column<string>(type: "TEXT", nullable: false),
                    HomeWorldId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                    table.ForeignKey(
                        name: "FK_People_Planets_HomeWorldId",
                        column: x => x.HomeWorldId,
                        principalTable: "Planets",
                        principalColumn: "Id"
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "PersonPlanet",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PersonId = table.Column<int>(type: "INTEGER", nullable: false),
                    PlanetId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonPlanet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonPlanet_Planets_PlanetId",
                        column: x => x.PlanetId,
                        principalTable: "Planets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "FilmStarship",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FilmId = table.Column<int>(type: "INTEGER", nullable: false),
                    StarshipId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmStarship", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FilmStarship_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_FilmStarship_Starships_StarshipId",
                        column: x => x.StarshipId,
                        principalTable: "Starships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "PersonFilm",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PersonId = table.Column<int>(type: "INTEGER", nullable: false),
                    FilmId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonFilm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonFilm_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_PersonFilm_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateIndex(
                name: "IX_FilmPlanet_FilmId",
                table: "FilmPlanet",
                column: "FilmId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_FilmPlanet_PlanetId",
                table: "FilmPlanet",
                column: "PlanetId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_FilmStarship_FilmId",
                table: "FilmStarship",
                column: "FilmId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_FilmStarship_StarshipId",
                table: "FilmStarship",
                column: "StarshipId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_People_HomeWorldId",
                table: "People",
                column: "HomeWorldId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_PersonFilm_FilmId",
                table: "PersonFilm",
                column: "FilmId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_PersonFilm_PersonId",
                table: "PersonFilm",
                column: "PersonId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_PersonPlanet_PlanetId",
                table: "PersonPlanet",
                column: "PlanetId"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "FilmPlanet");

            migrationBuilder.DropTable(name: "FilmStarship");

            migrationBuilder.DropTable(name: "PersonFilm");

            migrationBuilder.DropTable(name: "PersonPlanet");

            migrationBuilder.DropTable(name: "Starships");

            migrationBuilder.DropTable(name: "Films");

            migrationBuilder.DropTable(name: "People");

            migrationBuilder.DropTable(name: "Planets");
        }
    }
}
