using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FantasyFootbal.Models.Tournoment
{
    /// <summary>
    /// This class describes the all properties of each tournament.
    /// </summary>
    public class TournamentDetails
    {
        // The ID of the Tournament
        public int Id { get; set; }

        // The name or title of tournament. For example LaLiga, World Cup etc.
        public string Title { get; set; }

        // The price for participation of tournament
        public int Price { get; set; }

        // The budget of tournament
        public int Balance { get; set; }

        // es chgitem inch a
        public int CountOf { get; set; }

        // The start date of the tournament
        public string StartDate { get; set; }
    }
}
