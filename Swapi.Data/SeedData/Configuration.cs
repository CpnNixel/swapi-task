using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Swapi.Data.SeedData;

public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.HasData(
            new Person
            {
                Id = 1,
                Name = "Luke Skywalker",
                BirthYear = "19BBY",
                EyeColor = "Blue",
                Gender = "Male",
                HairColor = "Blond",
                Height = "172",
                Mass = "77",
                SkinColor = "Fair"
            },
            new Person
            {
                Id = 2,
                Name = "Leia Organa",
                BirthYear = "19BBY",
                EyeColor = "Brown",
                Gender = "Female",
                HairColor = "Brown",
                Height = "150",
                Mass = "49",
                SkinColor = "Light"
            }
        );
    }
}

public class FilmConfiguration : IEntityTypeConfiguration<Film>
{
    public void Configure(EntityTypeBuilder<Film> builder)
    {
        builder.HasData(
            new Film
            {
                Id = 1,
                Title = "A New Hope",
                Episode = 4,
                OpeningCrawl = "It is a period of civil war...",
                Director = "George Lucas",
                Producer = "Gary Kurtz, Rick McCallum",
                ReleaseDate = "1977-05-25"
            },
            new Film
            {
                Id = 2,
                Title = "The Empire Strikes Back",
                Episode = 5,
                OpeningCrawl = "It is a dark time for the Rebellion...",
                Director = "Irvin Kershner",
                Producer = "Gary Kurtz, Rick McCallum",
                ReleaseDate = "1980-05-21"
            }
        );
    }
}

public class PersonFilmConfiguration : IEntityTypeConfiguration<PersonFilm>
{
    public void Configure(EntityTypeBuilder<PersonFilm> builder)
    {
        builder.HasData(
            new PersonFilm
            {
                Id = 1,
                PersonId = 1,
                FilmId = 1
            },
            new PersonFilm
            {
                Id = 2,
                PersonId = 1,
                FilmId = 2
            },
            new PersonFilm
            {
                Id = 3,
                PersonId = 2,
                FilmId = 1
            }
        );
    }
}

public class PersonPlanetConfiguration : IEntityTypeConfiguration<PersonPlanet>
{
    public void Configure(EntityTypeBuilder<PersonPlanet> builder)
    {
        builder.HasData(
            new PersonPlanet
            {
                Id = 1,
                PersonId = 1,
                PlanetId = 1
            },
            new PersonPlanet
            {
                Id = 2,
                PersonId = 2,
                PlanetId = 1
            }
        );
    }
}

public class FilmPlanetConfiguration : IEntityTypeConfiguration<FilmPlanet>
{
    public void Configure(EntityTypeBuilder<FilmPlanet> builder)
    {
        builder.HasData(
            new FilmPlanet
            {
                Id = 1,
                FilmId = 1,
                PlanetId = 1
            },
            new FilmPlanet
            {
                Id = 2,
                FilmId = 2,
                PlanetId = 2
            }
        );
    }
}

public class FilmStarshipConfiguration : IEntityTypeConfiguration<FilmStarship>
{
    public void Configure(EntityTypeBuilder<FilmStarship> builder)
    {
        builder.HasData(
            new FilmStarship
            {
                Id = 1,
                FilmId = 1,
                StarshipId = 1
            },
            new FilmStarship
            {
                Id = 2,
                FilmId = 2,
                StarshipId = 2
            }
        );
    }
}

public class PlanetConfiguration : IEntityTypeConfiguration<Planet>
{
    public void Configure(EntityTypeBuilder<Planet> builder)
    {
        builder.HasData(
            new Planet
            {
                Id = 1,
                Name = "Tatooine",
                Diameter = "10465",
                RotationSpeed = "23",
                OrbitalPeriod = "304",
                Gravity = "1 standard",
                Population = "200000",
                Climate = "Arid",
                Terrain = "Desert",
                SurfaceWater = "1",
            },
            new Planet
            {
                Id = 2,
                Name = "Hoth",
                Diameter = "7200",
                RotationSpeed = "23",
                OrbitalPeriod = "549",
                Gravity = "1.1 standard",
                Population = "unknown",
                Climate = "Frozen",
                Terrain = "Tundra, Ice caves, Mountain ranges",
                SurfaceWater = "100",
            }
        );
    }
}

public class StarshipConfiguration : IEntityTypeConfiguration<Starship>
{
    public void Configure(EntityTypeBuilder<Starship> builder)
    {
        builder.HasData(
            new Starship
            {
                Id = 1,
                Model = "T-65 X-wing",
                Name = "X-wing Starfighter",
                StarshipClass = "Starfighter",
                Manufacturer = "Incom Corporation, Koensayr Manufacturing",
                CostInCredits = "149999",
                Length = "12.5",
                Crew = "1",
                Passengers = "0",
                MaxAtmospheringSpeed = "1050",
                HyperDriveRating = "1.0",
                Megalights = "100",
                CargoCapacity = "110",
                Consumables = "1 week"
            },
            new Starship
            {
                Id = 2,
                Model = "CR90 corvette",
                Name = "CR90 corvette",
                StarshipClass = "Corvette",
                Manufacturer = "Corellian Engineering Corporation",
                CostInCredits = "3500000",
                Length = "150",
                Crew = "30-165",
                Passengers = "600",
                MaxAtmospheringSpeed = "950",
                HyperDriveRating = "2.0",
                Megalights = "60",
                CargoCapacity = "3000000",
                Consumables = "1 year"
            }
        );
    }
}
