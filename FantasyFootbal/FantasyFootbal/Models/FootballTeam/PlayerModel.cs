namespace FantasyFootbal.Models.FootballTeam
{
    /// <summary>
    /// This class describes all properties of each player.
    /// </summary>
    public class PlayerModel
    {
        // Team id
        public int TeamId { get; set; }

        // Player Id
        public int PlayerId { get; set; }

        // Position of player
        public string Position { get; set; }

        // Player
        public string Player { get; set; }
    }
}
