using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using SWapi.Data;
using SWapi.Data.Models;

namespace SWapi.Api.Modules;

public static partial class Modules
{
    // Search Fields:
    //
    // name

    public static RouteGroupBuilder PlanetsModule(this RouteGroupBuilder group)
    {
        group
            .MapGet(
                "/search/{name}",
                async (StarWarsDbContext context, string name) =>
                {
                    //Todo: move to services

                    var res = await context
                        .Planets.Include(f => f.Films)
                        .Include(f => f.People)
                        .Where(planet => planet.Name.ToLower().Contains(name.ToLower()))
                        .AsNoTracking()
                        .ToListAsync();

                    return !res.Any() ? Results.NotFound() : Results.Ok<IEnumerable<Planet>>(res);
                }
            )
            .Produces<Ok<IEnumerable<Planet>>>()
            .Produces(StatusCodes.Status404NotFound);

        return group;
    }
}
