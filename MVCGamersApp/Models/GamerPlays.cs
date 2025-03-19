namespace MVCGamersApp.Models;

// GamerPlays.cs
// This model represents the relationship between a Gamer and a Game.
// It allows us to capture additional information (like HoursPlayed)
// about the association between a gamer and the game they play.
public class GamerPlays
{
    // Foreign key for the Gamer.
    public int GamerId { get; set; }
        
    // Navigation property to access the associated Gamer.
    public Gamer Gamer { get; set; }
        
    // Foreign key for the Game.
    public int GameId { get; set; }
        
    // Navigation property to access the associated Game.
    public Game Game { get; set; }
        
    // Additional property to store how many hours the gamer has played this game.
    public int HoursPlayed { get; set; }
}