using Microsoft.EntityFrameworkCore;
using Swapi.Data;
using Swapi.Data.Models;
using Swapi.Services.Interfaces;

namespace Swapi.Services;

public class PersonService(StarWarsDbContext context) : IPersonService
{
    public async Task<Person> GetById(int id)
    {
        return await context.People.Include(p => p.Films).FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Person>> FindByName(string name)
    {
        return await context
            .People.Include(p => p.Films)
            .Where(f => f.Name.ToLower().Contains(name.ToLower()))
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task UpdatePerson(int id, Person person)
    {
        var existingPerson = await context.People.FindAsync(id);
        //_logger.log
        _ =
            existingPerson
            ?? throw new InvalidOperationException($"Person with ID {id} not found.");

        existingPerson.Name = person.Name;
        existingPerson.BirthYear = person.BirthYear;
        existingPerson.EyeColor = person.EyeColor;
        existingPerson.Gender = person.Gender;
        existingPerson.HairColor = person.HairColor;
        existingPerson.Height = person.Height;
        existingPerson.Mass = person.Mass;
        existingPerson.SkinColor = person.SkinColor;
        existingPerson.HomeWorld = person.HomeWorld;
        await context.SaveChangesAsync();
    }

    public async Task<Person> CreatePerson(Person person)
    {
        var newPerson = new Person
        {
            Name = person.Name,
            BirthYear = person.BirthYear,
            EyeColor = person.EyeColor,
            Gender = person.Gender,
            HairColor = person.HairColor,
            Height = person.Height,
            Mass = person.Mass,
            SkinColor = person.SkinColor,
            HomeWorld = person.HomeWorld
        };

        context.People.Add(newPerson);
        await context.SaveChangesAsync();

        return newPerson;
    }
}
