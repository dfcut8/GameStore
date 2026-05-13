using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.Dtos;

public record CreateGameData(
    [Required] string Name,
    [Required] string Genre,
    [Required] decimal Price,
    [Required] DateOnly ReleaseDate
);
