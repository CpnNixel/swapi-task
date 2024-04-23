using Microsoft.EntityFrameworkCore;
using Swapi.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<StarWarsDbContext>();
builder.Services.AddHttpClient();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet(
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

app.MapGet(
    "/Character/{id}",
    async (StarWarsDbContext context, int id) =>
    {
        return await context.People.Include(p => p.Films).FirstOrDefaultAsync(p => p.Id == id);
    }
);

app.Run();
