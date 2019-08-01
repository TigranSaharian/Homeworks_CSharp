using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FantasyFootbal.Models.Tournoment
{
    /// <summary>
    /// This class describes Header properties of each tournament.
    /// </summary>
    [Table("TourTitle")]
    public class TournamentHeader
    {
        // The ID of tournament header.
        [Key]
        [Column("id")]
        public int Id { get; set; }

        // The name or title of tournament.
        [Required]
        [Column("title")]
        public string Title { get; set; }

        // The budget of tournament
        [Required]
        public string Balance { get; set; }

        // The price for participation of tournament
        [Required]
        public string Price { get; set; }
    }
}
