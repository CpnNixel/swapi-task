namespace SWapi.Api.Modules;

public static partial class Modules
{
    public static RouteGroupBuilder RootModule(this RouteGroupBuilder group)
    {
        group.MapGet(
            "/",
            (HttpRequest request) =>
            {
                var baseUrl = $"{request.Scheme}://{request.Host}";

                return Results.Ok(
                    new
                    {
                        films = $"{baseUrl}/api/films/",
                        people = $"{baseUrl}/api/people/",
                        planets = $"{baseUrl}/api/planets/",
                        species = $"{baseUrl}/api/species/",
                        starships = $"{baseUrl}/api/starships/",
                    }
                );
            }
        );

        return group;
    }
}
