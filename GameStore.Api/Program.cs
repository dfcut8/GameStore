using GameStore.Api.Dtos;

const string GetGameByIdEndpointName = "GetGameById";

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

app.MapGet(
        "/games/{id}",
        (int id) =>
        {
            return games.FirstOrDefault(g => g.Id == id);
        }
    )
    .WithName(GetGameByIdEndpointName);

app.MapPost(
    "/games",
    (CreateGameData data) =>
    {
        GameData game = new(games.Count + 1, data.Name, data.Genre, data.Price, data.ReleaseDate);
        games.Add(game);
        return Results.CreatedAtRoute(GetGameByIdEndpointName, new { id = game.Id }, game);
    }
);

app.MapPut(
    "/games/{id}",
    (int id, UpdateGameData data) =>
    {
        var current = games.FirstOrDefault(g => g.Id == id);
        if (current == null)
            return Results.NotFound();
        games.Remove(current);
        GameData g = new(id, data.Name, data.Genre, data.Price, data.releaseDate);
        games.Add(g);
        return Results.NoContent();
    }
);

app.Run();
