using System.Runtime.CompilerServices;
using GameStore.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Genres;

public static class GenreEndpoints
{
    const string EndpointPattern = "genres";

    public static void AddGenreEndpoints(this WebApplication app)
    {
        app.MapGet(
            EndpointPattern,
            async (GameStoreContext dbCtx) => await dbCtx.Genres.ToListAsync()
        );
    }
}
