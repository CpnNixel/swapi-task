using Microsoft.AspNetCore.RateLimiting;
using Swapi.Api.Modules;
using Swapi.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<StarWarsDbContext>();
builder.Services.AddHttpClient();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
    options.AddPolicy(
        "ApiCorsPolicy",
        policyBuilder =>
        {
            policyBuilder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        }
    )
);

builder.Services.AddRateLimiter(options =>
{
    options.AddTokenBucketLimiter(
        "TokenBucket",
        opt =>
        {
            opt.TokenLimit = 10_000;
            opt.TokensPerPeriod = 10_000;
            opt.ReplenishmentPeriod = TimeSpan.FromDays(1);
        }
    );
});

var app = builder.Build();

app.UseCors("ApiCorsPolicy");
app.UseRateLimiter();
app.UseSwagger();
app.UseSwaggerUI();

app.MapGroup("Root").RootModule().WithName("Root")
    .RequireRateLimiting("TokenBucket");

app.MapGroup("Characters").CharactersModule().WithTags("Character");
app.MapGroup("Films").FilmsModule().WithTags("Film");
app.MapGroup("Planets").PlanetsModule().WithTags("Planet");
app.MapGroup("Starships").StarshipsModule().WithTags("Starship");

app.Run();
