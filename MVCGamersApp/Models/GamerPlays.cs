
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCGamersApp.Models;

// GamerPlays.cs
// This model represents the relationship between a Gamer and a Game.
// It allows us to capture additional information (like HoursPlayed)
// about the association between a gamer and the game they play.
public class GamerPlays
{
    
    [Key] // Primary key for the GamerPlays model.
    public int Id { get; set; }
    
    // Foreign key for the Gamer.
    [ForeignKey("Gamer")]
    public int GamerId { get; set; }
        
    // Navigation property to access the associated Gamer.
    public Gamer Gamer { get; set; }
        
    // Foreign key for the Game.
    [ForeignKey("Game")]
    public int GameId { get; set; }
        
    // Navigation property to access the associated Game.
    public Game Game { get; set; }
        
    // Additional property to store how many hours the gamer has played this game.
    public int HoursPlayed { get; set; }
}