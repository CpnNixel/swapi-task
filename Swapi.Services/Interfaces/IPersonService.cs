using Swapi.Data.Models;

namespace Swapi.Services.Interfaces;

public interface IPersonService
{
    Task<Person> GetById(int id);

    Task<IEnumerable<Person>> FindByName(string name);

    Task UpdatePerson(int id, Person person);

    Task<Person> CreatePerson(Person person);
}
