using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.Genres;

public record GenreDto([Required] int Id, [Required] [MaxLength(24)] string Name);
