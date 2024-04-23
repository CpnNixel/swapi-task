using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Swapi.Data;

namespace Swapi.Api.Modules;

public static partial class Modules
{
    // Search Fields:
    //
    // title
    public static RouteGroupBuilder FilmsModule(this RouteGroupBuilder group)
    {
        group.MapGet(
            "/search/{title}",
            Results<Ok<IEnumerable<Film>>, NotFound> (StarWarsDbContext context, string title) =>
            {
                var res = context
                    .Films.Include(f => f.Starships)
                    .Include(f => f.Persons)
                    .Include(f => f.Planets)
                    .Where(f => f.Title.ToLower().Contains(title.ToLower()))
                    .AsNoTracking()
                    .ToList();

                return !res.Any()
                    ? TypedResults.NotFound()
                    : TypedResults.Ok<IEnumerable<Film>>(res);
            }
        );

        return group;
    }
}
