using GameStore.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Genres;

public static class GenreEndpoints
{
    private const string GetGenreByIdEndpointName = "GetGenreById";

    public static void MapGenreEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/genres");
        group.MapGet("/", async (GameStoreContext dbCtx) => await dbCtx.Genres.ToListAsync());

        group
            .MapGet(
                "/{id}",
                async (GameStoreContext dbCtx, int id) =>
                {
                    var genre = await dbCtx.Genres.FindAsync(id);
                    if (genre is null)
                    {
                        return Results.NotFound();
                    }
                    return Results.Ok(new GenreDto(Id: genre.Id, Name: genre.Name));
                }
            )
            .WithName(GetGenreByIdEndpointName);

        group.MapPost(
            "/",
            async (GameStoreContext dbCtx, GenreCreateDto data) =>
            {
                var genre = new GenreModel { Name = data.Name };
                await dbCtx.Genres.AddAsync(genre);
                await dbCtx.SaveChangesAsync();
                GenreDto genreDetails = new(Id: genre.Id, Name: genre.Name);
                return Results.CreatedAtRoute(
                    GetGenreByIdEndpointName,
                    new { id = genreDetails.Id },
                    genreDetails
                );
            }
        );
    }
}
