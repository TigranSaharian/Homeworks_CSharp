using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace FantasyFootbal.Models.Tournoment
{
    public class TournamentDetailsManage
    {
        private readonly string Text;

        public TournamentDetailsManage(string Text)
        {
            this.Text = Text;
        }

        public List<TournamentDetails> GetTournamentDetails()
        {

            List<TournamentDetails> TournamentList = new List<TournamentDetails>();

            using (SqlConnection connection = new SqlConnection(Text))
            {
                SqlCommand sqlCommand = new SqlCommand();

                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "sp_getTournamentDetail";
                sqlCommand.Connection = connection;

                connection.Open();

                SqlDataReader dataReader = sqlCommand.ExecuteReader();

                while (dataReader.Read())
                {
                    TournamentDetails tournamentDetails = new TournamentDetails();

                    tournamentDetails.Id = Convert.ToInt32(dataReader[0]);
                    tournamentDetails.Title = Convert.ToString(dataReader[1]);
                    tournamentDetails.Balance = Convert.ToInt32(dataReader[2]);
                    tournamentDetails.Price = Convert.ToInt32(dataReader[3]);
                    tournamentDetails.CountOf = Convert.ToInt32(dataReader[4]);
                    tournamentDetails.StartDate = Convert.ToString(dataReader[5]);
                    TournamentList.Add(tournamentDetails);
                }
            }
            return TournamentList;
        }
    }
}
