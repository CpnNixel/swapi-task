using Microsoft.EntityFrameworkCore;
using Swapi.Data.Models;
using Swapi.Data.SeedData;

namespace Swapi.Data;

public class StarWarsDbContext : DbContext
{
    public StarWarsDbContext(DbContextOptions options)
        : base(options) { }

    public StarWarsDbContext() { }

    public virtual DbSet<Person> People { get; set; }
    public virtual DbSet<Film> Films { get; set; }
    public virtual DbSet<Planet> Planets { get; set; }
    public virtual DbSet<Starship> Starships { get; set; }

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
