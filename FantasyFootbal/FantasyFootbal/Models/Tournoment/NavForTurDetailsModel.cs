using FantasyFootbal.Models.FootballTeam;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace FantasyFootbal.Models.Tournoment
{
    public class NavForTurDetailsModel
    {
        public SelectList Teams { get; set; }
        public List<PlayerModel> Players { get; set; }
        public TournamentDetails TournamentDetails { get; set; }
        public List<TournamentModel> Matches { get; set; }

        public string GetRole(string role)
        {
            switch (role)
            {
                case "Gk":
                    return Roles.Goalkeeper.ToString();
                case "DF":
                    return Roles.Defender.ToString();
                case "MF":
                    return Roles.Midfielder.ToString();
                case "FW":
                    return Roles.Forward.ToString();
                case "All":
                    return null;
                default:
                    return null;
            }
        }
    }
}
