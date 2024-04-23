using Microsoft.AspNetCore.RateLimiting;
using SWapi.Api.Modules;
using SWapi.Data;
using SWapi.Services;
using SWapi.Services.Interfaces;

const string corsPolicyName = "ApiCorsPolicy";
const string rateLimiterPolicyName = "TokenBucket";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<StarWarsDbContext>();
builder.Services.AddHttpClient();

builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
    options.AddPolicy(
        corsPolicyName,
        policyBuilder =>
        {
            policyBuilder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        }
    )
);

builder.Services.AddRateLimiter(options =>
{
    options.AddTokenBucketLimiter(
        rateLimiterPolicyName,
        opt =>
        {
            opt.TokenLimit = 10_000;
            opt.TokensPerPeriod = 10_000;
            opt.ReplenishmentPeriod = TimeSpan.FromDays(1);
        }
    );
});

var app = builder.Build();

app.UseCors(corsPolicyName);
app.UseRateLimiter();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGroup("api/root")
    .RootModule()
    .WithName("Root")
    .RequireRateLimiting(rateLimiterPolicyName);

app.MapGroup("api/characters").CharactersModule().WithTags("Character");
app.MapGroup("api/Films").FilmsModule().WithTags("Film");
app.MapGroup("api/planets").PlanetsModule().WithTags("Planet");
app.MapGroup("api/Starships").StarshipsModule().WithTags("Starship");

app.Run();
