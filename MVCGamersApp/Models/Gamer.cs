namespace MVCGamersApp.Models;

// Gamer.cs
// This model represents a gamer (or user) in our app.

public class Gamer
{
    // Primary key for the Gamer model.
    public int Id { get; set; }
        
    // The game's username.
    public string Username { get; set; }
        
    // The game's email address.
    public string Email { get; set; }
        
    // Navigation property: a gamer can play many games.
    public List<GamerPlays> GamerPlays { get; set; } = new List<GamerPlays>();
}