namespace MVCGamersApp.Models;

// Game.cs
// This model represents a video game in our app.

public class Game
{
    
    public int Id { get; set; } // Primary key for the Game model.

    
    public string Name { get; set; } // Name of the game.

    
    public string Genre { get; set; } // Genre of the game (e.g., Action, Adventure, RPG).

    // Navigation property: a game can be played by many gamers.
    // We're using a List to store related GamerPlays records.
    public List<GamerPlays> GamerPlays { get; set; } = new List<GamerPlays>();
}