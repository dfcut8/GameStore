namespace GameStore.Api.Dtos;

public record CreateGameData(string Name, string Genre, decimal Price, DateOnly ReleaseDate);
