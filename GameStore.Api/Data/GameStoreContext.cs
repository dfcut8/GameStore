using GameStore.Api.Games;
using GameStore.Api.Genres;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Data;

public class GameStoreContext(DbContextOptions<GameStoreContext> ops) : DbContext(ops)
{
    public DbSet<GameModel> Games => Set<GameModel>();
    public DbSet<Genre> Genres => Set<Genre>();
}
