using Swapi.Api.Modules;
using Swapi.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<StarWarsDbContext>();
builder.Services.AddHttpClient();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGroup("Root").RootModule().WithTags("Root");
app.MapGroup("Characters").CharactersModule().WithTags("Character");
app.MapGroup("Films").FilmsModule().WithTags("Film");
app.MapGroup("Planets").PlanetsModule().WithTags("Planet");
app.MapGroup("Starships").StarshipsModule().WithTags("Starship");

app.Run();
