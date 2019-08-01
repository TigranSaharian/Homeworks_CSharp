using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FantasyFootbal.Models.FootballTeam
{
    /// <summary>
    /// This is the class in which all the properties of the player that are needed to create a football club.
    /// </summary>
    public class PlayersAutocompleteModel 
    {
        // The Name of player
        public string Name { get; set; }

        // Position of player
        public string Position { get; set; }

        // The player id
        public int PlayerId { get; set; }

        // The ID of the team the player is playing in
        public int TeamId { get; set; }

        // The price of player
        public int Price { get; set; }
    }
}
