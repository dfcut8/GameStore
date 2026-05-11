using GameStore.Api.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Game Store API.");

List<GameData> games = new()
{
    new(1, "Street Fighter II", "Fighting", 19.99M, new DateOnly(2022, 11, 30)),
    new(2, "Final Fantasy II", "JRPG", 39.99M, new DateOnly(1989, 06, 25)),
    new(3, "Batman", "Beat em up", 29.99M, new DateOnly(1983, 03, 01)),
};

app.MapGet(
    "/games",
    () =>
    {
        return games;
    }
);

app.Run();
