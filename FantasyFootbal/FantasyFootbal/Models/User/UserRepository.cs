namespace FantasyFootbal.Models.User
{
    public class UserRepository : IUserRepository<User>
    {
        // Create UserContext class
        private readonly UserContext Context;

        // Constractor
        public UserRepository(UserContext Context)
        {
            this.Context = Context;
        }

        // Creating a new user and saving changes in the database.
        public void CreateUser(User user)
        {
            Context.Users.Add(user);
            Context.SaveChanges();
        }
    }
}
