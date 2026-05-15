using GameStore.Api.Genres;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Data;

public static class DataExtensions
{
    public static void MigrateDb(this WebApplication app)
    {
        using IServiceScope scope = app.Services.CreateScope();
        GameStoreContext dbContext = scope.ServiceProvider.GetRequiredService<GameStoreContext>();
        dbContext.Database.Migrate();
    }

    public static void AddGameStoreDb(this WebApplicationBuilder builder)
    {
        var connString = builder.Configuration.GetConnectionString("GameStore");

        builder.Services.AddSqlite<GameStoreContext>(
            connString,
            optionsAction: ops =>
                ops.UseSeeding(
                    (ctx, _) =>
                    {
                        if (!ctx.Set<GenreModel>().Any())
                        {
                            ctx.Set<GenreModel>()
                                .AddRange(
                                    new GenreModel { Name = "JRPG" },
                                    new GenreModel { Name = "TRPG" },
                                    new GenreModel { Name = "Racing" },
                                    new GenreModel { Name = "Action" },
                                    new GenreModel { Name = "Horror" },
                                    new GenreModel { Name = "Shoot Em Up!" },
                                    new GenreModel { Name = "Sports" },
                                    new GenreModel { Name = "2D Platformer" },
                                    new GenreModel { Name = "Quest" }
                                );
                            ctx.SaveChanges();
                        }
                    }
                )
        );
    }
}
