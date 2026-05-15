using System.Xml.Linq;
using GameStore.Api.Data;
using GameStore.Api.Games;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Endpoints;

public static class GameEndpoints
{
    private const string GetGameByIdEndpointName = "GetGameById";

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
                            new GameDetailsDto(
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
            async (CreateGameDto data, GameStoreContext dbCtx) =>
            {
                GameModel game = new()
                {
                    Name = data.Name,
                    GenreId = data.GenreId,
                    Price = data.Price,
                    ReleaseDate = data.ReleaseDate,
                };
                dbCtx.Add(game);
                await dbCtx.SaveChangesAsync();

                GameDetailsDto gameDetailsData = new(
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
            async (int id, UpdateGameDto data, GameStoreContext dbCtx) =>
            {
                var game = await dbCtx.Games.FindAsync(id);
                if (game is null)
                {
                    return Results.NotFound();
                }

                game.Name = data.Name;
                game.Price = data.Price;
                game.ReleaseDate = data.ReleaseDate;
                game.GenreId = data.GenreId;

                await dbCtx.SaveChangesAsync();

                return Results.NoContent();
            }
        );

        group.MapDelete(
            "/{id}",
            async (int id, GameStoreContext dbCtx) =>
            {
                var game = await dbCtx.Games.FindAsync(id);
                if (game is null)
                {
                    return Results.NotFound();
                }
                dbCtx.Games.Remove(game);
                return Results.NoContent();
            }
        );
    }
}
