namespace FantasyFootbal.Models.User
{
    /// <summary>
    /// Create a new user
    /// </summary>
    /// <typeparam name="T"></typeparam>
    interface IUserRepository<T>
    {
        void CreateUser(T user);
    }
}
