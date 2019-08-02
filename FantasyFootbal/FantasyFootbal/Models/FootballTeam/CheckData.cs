using FantasyFootbal.Models.FootballTeam;
using FantasyFootbal.Models.Tournoment;
using FantasyFootbal.Models.User;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace FantasyFootbal.Models
{
    public class CheckData
    {
        // Try to add team to database, and otherwise we get a exeption with json messsage
        public bool AddAutocompleteTeam(List<Player> players, TournamentContext tournamentContext, int TeamId)
        {
            bool flag = true;
            try
            {
                // Add players
                foreach (var item in players)
                {
                    tournamentContext.Database.ExecuteSqlCommand("AddPlayer @user, @player, @id",
                     new SqlParameter("@user", "testUsr"),
                     new SqlParameter("@player", item.FootballPlayer),
                     new SqlParameter("@id", TeamId));
                }
            }
            catch (SqlException e)
            {
                flag = false;
            }

            finally { }

            return flag;
        }

        // Reset password 
        public bool ResetPassword(string email, UserContext userContext)
        {
            bool flag = true;

            try
            {
                var resultParameter = new SqlParameter("@tmpUrl", SqlDbType.VarChar, 150)
                {
                    Direction = ParameterDirection.Output
                };

                var resultParameter2 = new SqlParameter("@SendEmail", SqlDbType.VarChar, 150)
                {
                    Direction = ParameterDirection.Output
                };


                var recordsAffected = userContext.Database.ExecuteSqlCommand("sp_changePass @Email ,@tmpUrl  out, @SendEmail out ",
                      new SqlParameter("@Email", email),
                      resultParameter,
                      resultParameter2
                  );
                RestorePassword restorePassword = new RestorePassword();
                restorePassword.SendEmail(resultParameter2.Value.ToString(), resultParameter.Value.ToString());
            }
            catch (System.Exception)
            {
                flag = false;
            }
            finally { }
            return flag;
        }
    }
}
