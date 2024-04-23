using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Swapi.Data;
using Swapi.Data.Models;

namespace Swapi.Api.Modules;

public static partial class Modules
{
    // Search Fields:
    //
    // name
    // model

    public static RouteGroupBuilder StarshipsModule(this RouteGroupBuilder group)
    {
        group
            .MapGet(
                "/search/{nameOrModel}",
                async (StarWarsDbContext context, string nameOrModel) =>
                {
                    //Todo: move to services

                    var res = await context
                        .Starships.Include(f => f.Films)
                        .Where(starship =>
                            starship.Name.ToLower().Contains(nameOrModel.ToLower())
                            || starship.Name.ToLower().Contains(nameOrModel.ToLower())
                        )
                        .AsNoTracking()
                        .ToListAsync();

                    return !res.Any() ? Results.NotFound() : Results.Ok<IEnumerable<Starship>>(res);
                }
            )
            .Produces<Ok<IEnumerable<Starship>>>()
            .Produces(StatusCodes.Status404NotFound);

        return group;
    }
}
