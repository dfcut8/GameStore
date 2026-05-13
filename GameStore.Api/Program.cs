using GameStore.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/", () => "Game Store API.");

app.MapGamesEndpoints();

app.Run();
