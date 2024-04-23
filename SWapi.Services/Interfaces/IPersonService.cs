using SWapi.Data.Models;

namespace SWapi.Services.Interfaces;

public interface IPersonService
{
    Task<Person> GetById(int id);

    Task<IEnumerable<Person>> GetByName(string name);

    Task UpdatePerson(int id, Person person);

    Task<Person> CreatePerson(Person person);
}
