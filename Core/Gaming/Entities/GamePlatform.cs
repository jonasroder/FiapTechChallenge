namespace Core.Gaming.Entities;
public class GamePlatform
{
    public int Id { get; protected set; }
    public required string Name { get; set; } 
    public int GameId { get; set; }
    public Game Game { get; set; } = null!;
}
