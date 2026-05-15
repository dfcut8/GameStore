using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.Genres;

public record GenreCreateDto([Required] [MaxLength(24)] string Name);
