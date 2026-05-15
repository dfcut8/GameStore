using System.Xml.Linq;
using GameStore.Api.Data;
using GameStore.Api.Dtos;
using GameStore.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Endpoints;

public static class GamesEndpoints
{
    private const string GetGameByIdEndpointName = "GetGameById";
    private static readonly List<GameSummaryDto> games =
    [
        new(1, "Street Fighter II", "Fighting", 19.99M, new DateOnly(2022, 11, 30)),
        new(2, "Final Fantasy II", "JRPG", 39.99M, new DateOnly(1989, 06, 25)),
        new(3, "Batman", "Beat em up", 29.99M, new DateOnly(1983, 03, 01)),
    ];

    public static void MapGamesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/games");
        group.MapGet(
            "/",
            async (GameStoreContext dbCtx) =>
                await dbCtx
                    .Games.Include(game => game.Genre)
                    .Select(game => new GameSummaryDto(
                        game.Id,
                        game.Name,
                        game.Genre!.Name,
                        game.Price,
                        game.ReleaseDate
                    ))
                    .ToListAsync()
        );

        group
            .MapGet(
                "/{id}",
                async (int id, GameStoreContext dbCtx) =>
                {
                    var game = await dbCtx.Games.FindAsync(id);
                    return game is null
                        ? Results.NotFound()
                        : Results.Ok(
                            new GameDetailsData(
                                Id: game.Id,
                                Name: game.Name,
                                GenreId: game.GenreId,
                                Price: game.Price,
                                ReleaseDate: game.ReleaseDate
                            )
                        );
                }
            )
            .WithName(GetGameByIdEndpointName);

        group.MapPost(
            "/",
            async (CreateGameData data, GameStoreContext dbCtx) =>
            {
                Game game = new()
                {
                    Name = data.Name,
                    GenreId = data.GenreId,
                    Price = data.Price,
                    ReleaseDate = data.ReleaseDate,
                };
                dbCtx.Add(game);
                await dbCtx.SaveChangesAsync();

                GameDetailsData gameDetailsData = new(
                    Id: game.Id,
                    Name: game.Name,
                    GenreId: game.GenreId,
                    Price: game.Price,
                    ReleaseDate: game.ReleaseDate
                );

                return Results.CreatedAtRoute(
                    GetGameByIdEndpointName,
                    new { id = gameDetailsData.Id },
                    gameDetailsData
                );
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
                GameSummaryDto g = new(id, data.Name, data.Genre, data.Price, data.ReleaseDate);
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
