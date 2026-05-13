namespace GameStore.Api.Dtos;

public record UpdateGameData(string Name, string Genre, decimal Price, DateOnly releaseDate);
