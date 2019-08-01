using FantasyFootbal.Models.FootballTeam;
using Microsoft.EntityFrameworkCore;

namespace FantasyFootbal.Models.Tournoment
{
    // Using DbContext class from Entity Framework API. It is a bridge between our entity classes and the database.
    public class TournamentContext : DbContext
    {
        public TournamentContext(DbContextOptions<TournamentContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        // Set connection between Team class and databas
        public DbSet<Team> Teams { get; set; }

        // Set connection between TournamentHeader class and databas
        public DbSet<TournamentHeader> TournamentHeaders { get; set; }

        // Set connection between TournamentBody class and databas
        public DbSet<TournamentModel> TournamentModels { get; set; }
    }
}
