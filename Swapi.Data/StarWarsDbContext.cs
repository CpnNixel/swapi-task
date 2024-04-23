using Microsoft.EntityFrameworkCore;
using Swapi.Data.SeedData;

namespace Swapi.Data;

public class StarWarsDbContext : DbContext
{
    public DbSet<Person> People { get; set; }
    public DbSet<Film> Films { get; set; }
    public DbSet<Planet> Planets { get; set; }
    public DbSet<Starship> Starships { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("DataSource=starwars.db;Cache=Shared");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PersonConfiguration());
        modelBuilder.ApplyConfiguration(new FilmConfiguration());
        modelBuilder.ApplyConfiguration(new PersonFilmConfiguration());
        modelBuilder.ApplyConfiguration(new PersonPlanetConfiguration());
        modelBuilder.ApplyConfiguration(new FilmPlanetConfiguration());
        modelBuilder.ApplyConfiguration(new FilmStarshipConfiguration());
        modelBuilder.ApplyConfiguration(new PlanetConfiguration());
        modelBuilder.ApplyConfiguration(new StarshipConfiguration());
    }
}
