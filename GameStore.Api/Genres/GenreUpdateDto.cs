using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.Genres;

public record GenreUpdateDto([Required] [MaxLength(24)] string Name);
