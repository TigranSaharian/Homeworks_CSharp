using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FantasyFootbal.Models.Tournoment
{
    /// <summary>
    /// This class describes body properties of each tournament.
    /// </summary>
    [Table("turnamentTbl")]
    public class TournamentModel
    {
        // Default Id of tournament
        public int Id { get; set; }

        // The tournament Id
        public int TourId { get; set; }

        // The name of the first football team participating in the tournament.
        [Required]
        public string Team_1 { get; set; }

        // The start date of the tournament
        [Required]
        public string StartDate { get; set; }

        // The name of the second football team participating in the tournament.
        [Required]
        public string Team_2 { get; set; }
    }
}
