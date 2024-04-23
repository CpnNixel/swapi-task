using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Swapi.Data;

namespace Swapi.Api.Modules;

public static partial class Modules
{
    //Search Fields:
    //
    // name
    // model

    public static RouteGroupBuilder StarshipsModule(this RouteGroupBuilder group)
    {
        group.MapGet(
            "/search/{nameOrModel}",
            Results<Ok<IEnumerable<Starship>>, NotFound> (
                StarWarsDbContext context,
                string nameOrModel
            ) =>
            {
                var res = context
                    .Starships.Include(f => f.Films)
                    .Where(starship =>
                        starship.Name.ToLower().Contains(nameOrModel.ToLower())
                        || starship.Name.ToLower().Contains(nameOrModel.ToLower())
                    )
                    .AsNoTracking()
                    .ToList();

                return !res.Any()
                    ? TypedResults.NotFound()
                    : TypedResults.Ok<IEnumerable<Starship>>(res);
            }
        );

        return group;
    }
}
