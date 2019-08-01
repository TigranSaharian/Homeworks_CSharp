using Microsoft.EntityFrameworkCore;

namespace FantasyFootbal.Models.User
{
    // Using DbContext class from Entity Framework API. It is a bridge between our entity classes and the database.
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> option) : base(option)
        {
            Database.EnsureCreated();
        }

        // Set connection between User class and databas
        public DbSet<User> Users { get; set; }
    }
}
