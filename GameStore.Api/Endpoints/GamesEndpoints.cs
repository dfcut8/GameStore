using GameStore.Api.Dtos;

namespace GameStore.Api.Endpoints;

public static class GamesEndpoints
{
    private const string GetGameByIdEndpointName = "GetGameById";
    private static readonly List<GameData> games = new()
    {
        new(1, "Street Fighter II", "Fighting", 19.99M, new DateOnly(2022, 11, 30)),
        new(2, "Final Fantasy II", "JRPG", 39.99M, new DateOnly(1989, 06, 25)),
        new(3, "Batman", "Beat em up", 29.99M, new DateOnly(1983, 03, 01)),
    };

    public static void MapGamesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/games");
        group.MapGet(
            "/",
            () =>
            {
                return games;
            }
        );

        group
            .MapGet(
                "/{id}",
                (int id) =>
                {
                    return games.FirstOrDefault(g => g.Id == id);
                }
            )
            .WithName(GetGameByIdEndpointName);

        group.MapPost(
            "/",
            (CreateGameData data) =>
            {
                GameData game = new(
                    games.Count + 1,
                    data.Name,
                    data.Genre,
                    data.Price,
                    data.ReleaseDate
                );
                games.Add(game);
                return Results.CreatedAtRoute(GetGameByIdEndpointName, new { id = game.Id }, game);
            }
        );

        group.MapPut(
            "/{id}",
            (int id, UpdateGameData data) =>
            {
                var current = games.FirstOrDefault(g => g.Id == id);
                if (current is null)
                    return Results.NotFound();
                games.Remove(current);
                GameData g = new(id, data.Name, data.Genre, data.Price, data.ReleaseDate);
                games.Add(g);
                return Results.NoContent();
            }
        );

        group.MapDelete(
            "/{id}",
            (int id) =>
            {
                var current = games.FirstOrDefault(g => g.Id == id);
                if (current is null)
                    return Results.NotFound();
                games.Remove(current);
                return Results.NoContent();
            }
        );
    }
}
