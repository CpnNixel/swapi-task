using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using SWapi.Data;
using SWapi.Data.Models;

namespace SWapi.Api.Modules;

public static partial class Modules
{
    // Search Fields:
    //
    // title
    public static RouteGroupBuilder FilmsModule(this RouteGroupBuilder group)
    {
        group
            .MapGet(
                "/search/{title}",
                async (StarWarsDbContext context, string title) =>
                {
                    //Todo: move to services

                    var res = await context
                        .Films.Include(f => f.Starships)
                        .Include(f => f.Persons)
                        .Include(f => f.Planets)
                        .Where(f => f.Title.ToLower().Contains(title.ToLower()))
                        .AsNoTracking()
                        .ToListAsync();

                    return !res.Any() ? Results.NotFound() : Results.Ok<IEnumerable<Film>>(res);
                }
            )
            .Produces<Ok<IEnumerable<Film>>>()
            .Produces(StatusCodes.Status404NotFound);

        return group;
    }
}
