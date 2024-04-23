using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Swapi.Data;

namespace Swapi.Api.Modules;

public static partial class Modules
{
    // Search Fields:
    //
    // name

    public static RouteGroupBuilder PlanetsModule(this RouteGroupBuilder group)
    {
        group.MapGet(
            "/search/{name}",
            Results<Ok<IEnumerable<Planet>>, NotFound> (StarWarsDbContext context, string name) =>
            {
                var res = context
                    .Planets.Include(f => f.Films)
                    .Include(f => f.People)
                    .Where(planet => planet.Name.ToLower().Contains(name.ToLower()))
                    .AsNoTracking()
                    .ToList();

                return !res.Any()
                    ? TypedResults.NotFound()
                    : TypedResults.Ok<IEnumerable<Planet>>(res);
            }
        );

        return group;
    }
}
