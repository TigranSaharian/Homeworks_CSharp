using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace FantasyFootbal.Models.FootballTeam
{
    public class CreateFootballClubViaAutocomplete
    {
        private readonly string Text;

        // Constructor
        public CreateFootballClubViaAutocomplete(string Text)
        {
            this.Text = Text;
        }

        // Create a players list, which getting a id of player and after autocomplete pool all players(11 player) to list
        public List<PlayersAutocompleteModel> GetPlayers(int Id)
        {

            List<PlayersAutocompleteModel> playersList = new List<PlayersAutocompleteModel>();

            using (SqlConnection connection = new SqlConnection(Text))
            {
                SqlCommand sqlCommand = new SqlCommand();

                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "sp_getMembersPositions";
                sqlCommand.Parameters.Add(new SqlParameter("@id", Id));
                sqlCommand.Connection = connection;

                connection.Open();

                SqlDataReader dataReader = sqlCommand.ExecuteReader();

                while (dataReader.Read())
                {
                    PlayersAutocompleteModel playersAutocomplete = new PlayersAutocompleteModel();

                    playersAutocomplete.Name = Convert.ToString(dataReader[0]);
                    playersAutocomplete.Position = Convert.ToString(dataReader[1]);
                    playersAutocomplete.PlayerId = Convert.ToInt32(dataReader[2]);
                    playersAutocomplete.TeamId = Convert.ToInt32(dataReader[3]);
                    playersAutocomplete.Price = Convert.ToInt32(dataReader[4]);
                    playersList.Add(playersAutocomplete);

                }
                connection.Close();
            }
            return playersList;
        }
    }
}
