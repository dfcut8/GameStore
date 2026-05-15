using GameStore.Api.Data;
using GameStore.Api.Games;
using GameStore.Api.Genres;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidation();

builder.AddGameStoreDb();

var app = builder.Build();

app.MapGet("/", () => "Game Store API.");

app.MapGamesEndpoints();
app.MapGenreEndpoints();

app.MigrateDb();

app.Run();
