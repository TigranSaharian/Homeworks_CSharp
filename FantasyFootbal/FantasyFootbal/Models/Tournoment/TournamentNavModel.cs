using System.Collections.Generic;

namespace FantasyFootbal.Models.Tournoment
{
    /// <summary>
    /// Create Tournament 
    /// </summary>
    public class TournamentNavModel
    {
        // we need to create a list TournamentModel, because each tournament includes 10 paired teams
        public List<TournamentModel> TourModel { get; set; }

        // And each tournament has a name(title),a price and one balance
        public TournamentHeader TourHeader { get; set; }
    }
}
