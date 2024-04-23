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
    "/Character/{id}",
    async (StarWarsDbContext context, int id) =>
    {
        return await context.People.Include(p => p.Films).FirstOrDefaultAsync(p => p.Id == id);
    }
);

app.Run();
