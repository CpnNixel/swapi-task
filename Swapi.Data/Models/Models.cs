namespace Swapi.Data.Models;

public class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string BirthYear { get; set; }
    public string EyeColor { get; set; }
    public string Gender { get; set; }
    public string HairColor { get; set; }
    public string Height { get; set; }
    public string Mass { get; set; }
    public string SkinColor { get; set; }

    public Planet? HomeWorld { get; set; }
    public ICollection<PersonFilm> Films { get; set; } = [];
}

public class PersonFilm
{
    public int Id { get; set; }
    public int PersonId { get; set; }
    public int FilmId { get; set; }
}

public class PersonPlanet
{
    public int Id { get; set; }
    public int PersonId { get; set; }
    public int PlanetId { get; set; }
}

public class Film
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int Episode { get; set; }
    public string OpeningCrawl { get; set; }
    public string Director { get; set; }
    public string Producer { get; set; }
    public string ReleaseDate { get; set; }
    public ICollection<PersonFilm> Persons { get; set; } = [];
    public ICollection<FilmPlanet> Planets { get; set; } = [];
    public ICollection<FilmStarship> Starships { get; set; } = [];
}

public class FilmPlanet
{
    public int Id { get; set; }
    public int FilmId { get; set; }
    public int PlanetId { get; set; }
}

public class FilmStarship
{
    public int Id { get; set; }
    public int FilmId { get; set; }
    public int StarshipId { get; set; }
}

public record Planet
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Diameter { get; set; }
    public string RotationSpeed { get; set; }
    public string OrbitalPeriod { get; set; }
    public string Gravity { get; set; }
    public string Population { get; set; }
    public string Climate { get; set; }
    public string Terrain { get; set; }
    public string SurfaceWater { get; set; }
    public ICollection<PersonPlanet> People { get; set; } = [];
    public ICollection<FilmPlanet> Films { get; set; } = [];
}

public class Starship
{
    public int Id { get; set; }
    public string Model { get; set; }
    public string Name { get; set; }
    public string StarshipClass { get; set; }
    public string Manufacturer { get; set; }
    public string CostInCredits { get; set; }
    public string Length { get; set; }
    public string Crew { get; set; }
    public string Passengers { get; set; }
    public string MaxAtmospheringSpeed { get; set; }
    public string HyperDriveRating { get; set; }
    public string Megalights { get; set; }
    public string CargoCapacity { get; set; }
    public string Consumables { get; set; }
    public ICollection<FilmStarship> Films { get; set; } = [];
}
