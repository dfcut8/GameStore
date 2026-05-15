using GameStore.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Genres;

public static class GenreEndpoints
{
    public static void MapGenreEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/genres");
        group.MapGet("/", async (GameStoreContext dbCtx) => await dbCtx.Genres.ToListAsync());

        group.MapGet(
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
        );
    }
}
