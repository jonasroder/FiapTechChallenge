using Core.SharedKernel.Entity;

namespace Core.Gaming.Entities;

public class Game : EntityBase
{
    public required string Title { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public decimal? Rating { get; set; }
    public DateTime ReleaseDate { get; set; }
    public bool IsAvailable { get; set; } = true;

    public ICollection<GamePlatform> Platforms { get; set; } = new List<GamePlatform>();
    public ICollection<GameGenre> Genres { get; set; } = new List<GameGenre>();
}
