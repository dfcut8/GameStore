using GameStore.Api.Genres;

namespace GameStore.Api.Games;

public class GameModel
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public GenreModel? Genre { get; set; }
    public int GenreId { get; set; }
    public decimal Price { get; set; }
    public DateOnly ReleaseDate { get; set; }
}
