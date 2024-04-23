using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Swapi.Data;

namespace Swapi.Api.Modules;

public static partial class Modules
{
    public static RouteGroupBuilder CharactersModule(this RouteGroupBuilder group)
    {
        group.MapGet(
            "/{id}",
            async (StarWarsDbContext context, int id) =>
            {
                return await context
                    .People.Include(p => p.Films)
                    .FirstOrDefaultAsync(p => p.Id == id);
            }
        );

        group.MapGet(
            "/search/{name}",
            Results<Ok<IEnumerable<Person>>, NotFound> (StarWarsDbContext context, string name) =>
            {
                var res = context
                    .People.Include(p => p.Films)
                    .Where(f => f.Name.ToLower().Contains(name.ToLower()))
                    .AsNoTracking()
                    .ToList();

                return !res.Any()
                    ? TypedResults.NotFound()
                    : TypedResults.Ok<IEnumerable<Person>>(res);
            }
        );
        return group;
    }
}
