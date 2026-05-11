namespace GameStore.Api.Dtos;

public record GameData(int Id, string Name, string Genre, decimal Price, DateOnly ReleaseDate);
