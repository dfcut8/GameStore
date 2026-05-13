using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.Dtos;

public record UpdateGameData(
    [Required] [StringLength(maximumLength: 50, MinimumLength = 3)] string Name,
    [Required] [StringLength(maximumLength: 24, MinimumLength = 3)] string Genre,
    [Required] [Range(minimum: 0.10, maximum: 1000.00)] decimal Price,
    [Range(
        typeof(DateOnly),
        "1980-01-01",
        "9999-12-31",
        ErrorMessage = "Date should be not older than 1980."
    )]
        DateOnly ReleaseDate
);
