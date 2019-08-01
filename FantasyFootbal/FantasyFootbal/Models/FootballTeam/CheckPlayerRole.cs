using FantasyFootbal.Models.Tournoment;

namespace FantasyFootbal.Models.FootballTeam
{
    public class CheckPlayerRole
    {
        public static string GetRole(string role)
        {
            switch (role)
            {
                case "Gk":
                    return Roles.Goalkeeper.ToString();
                case "Def":
                    return Roles.Defender.ToString();
                case "Mid":
                    return Roles.Midfielder.ToString();
                case "For":
                    return Roles.Forward.ToString();
                case "All":
                    return null;
                default:
                    return null;
            }

        }
    }
}
