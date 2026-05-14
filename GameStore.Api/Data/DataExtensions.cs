using GameStore.Api.Models;
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
                        if (!ctx.Set<Genre>().Any())
                        {
                            ctx.Set<Genre>()
                                .AddRange(
                                    new Genre { Name = "JRPG" },
                                    new Genre { Name = "TRPG" },
                                    new Genre { Name = "Racing" },
                                    new Genre { Name = "Action" },
                                    new Genre { Name = "Horror" },
                                    new Genre { Name = "Shoot Em Up!" },
                                    new Genre { Name = "Sports" },
                                    new Genre { Name = "2D Platformer" },
                                    new Genre { Name = "Quest" }
                                );
                            ctx.SaveChanges();
                        }
                    }
                )
        );
    }
}
