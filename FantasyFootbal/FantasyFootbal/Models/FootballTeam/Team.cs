using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FantasyFootbal.Models.FootballTeam
{
    /// <summary>
    /// This class describes all the properties of each football team.
    /// </summary>
    [Table("football_team")]
    public class Team
    {
        // The ID of Team
        public int Id { get; set; }

        // The name of team
        public string TeamName { get; set; }
    }
}
