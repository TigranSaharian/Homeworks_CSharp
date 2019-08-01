using FantasyFootbal.Models.FootballTeam;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace FantasyFootbal.Models.Tournoment
{
    public class NavForTurDetailsManage
    {
        private readonly string Text;

        // Contructor
        public NavForTurDetailsManage(string Text)
        {
            this.Text = Text;
        }

        public List<Team> GetTeams(int id)
        {
            List<Team> TeamList = new List<Team>();

            using (SqlConnection connection = new SqlConnection(Text))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "sp_GetTournametsTeams";
                sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;
                sqlCommand.Connection = connection;
                connection.Open();

                SqlDataReader dataReader = sqlCommand.ExecuteReader();

                while (dataReader.Read())
                {
                    Team team = new Team();
                    team.Id = Convert.ToInt32(dataReader[0]);
                    team.TeamName = Convert.ToString(dataReader[1]);
                    TeamList.Add(team);
                }
            }
            return TeamList;
        }

        public List<PlayerModel> GetPlayers(int id, string team = null, string role = null)
        {

            List<PlayerModel> PlayerLst = new List<PlayerModel>();

            using (SqlConnection connection = new SqlConnection(Text))
            {
                SqlCommand sqlCommand = new SqlCommand();

                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "sp_GetMembers";
                sqlCommand.Connection = connection;
                sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;
                sqlCommand.Parameters.Add("@teamName", SqlDbType.NChar).Value = team;
                sqlCommand.Parameters.Add("@role", SqlDbType.NChar).Value = role;

                connection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    PlayerModel PlayerDetail = new PlayerModel();

                    PlayerDetail.PlayerId = Convert.ToInt32(reader[0]);
                    PlayerDetail.Player = Convert.ToString(reader[1]);
                    PlayerDetail.Position = Convert.ToString(reader[2]);
                    PlayerDetail.TeamId = Convert.ToInt32(reader[3]);
                    PlayerLst.Add(PlayerDetail);
                }
            }
            return PlayerLst;
        }

        public List<TournamentModel> GetMatchDetails(int id)
        {

            List<TournamentModel> MatchList = new List<TournamentModel>();

            using (SqlConnection connection = new SqlConnection(Text))
            {
                SqlCommand sqlCommand = new SqlCommand();

                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "GetTurMatchDetails";
                sqlCommand.Connection = connection;
                sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;

                connection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    TournamentModel TurMatche = new TournamentModel();

                    TurMatche.Id = Convert.ToInt32(reader[0]);
                    TurMatche.TourId = Convert.ToInt32(reader[1]);
                    TurMatche.Team_1 = Convert.ToString(reader[2]);
                    TurMatche.StartDate = Convert.ToString(reader[3]);
                    TurMatche.Team_2 = Convert.ToString(reader[4]);
                    
                    MatchList.Add(TurMatche);
                }
            }
            return MatchList;
        }

        public TournamentDetails GetTurDet(int id)
        {
            TournamentDetails TourDetail = new TournamentDetails();

            using (SqlConnection connection = new SqlConnection(Text))
            {
                SqlCommand sqlCommand = new SqlCommand();

                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = "sp_getTournamentDetail";
                sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;

                connection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    TourDetail.Id = Convert.ToInt32(reader[0]);
                    TourDetail.Title = Convert.ToString(reader[1]);
                    TourDetail.Balance = Convert.ToInt32(reader[2]);
                    TourDetail.Price = Convert.ToInt32(reader[3]);
                    TourDetail.CountOf = Convert.ToInt32(reader[4]);
                    TourDetail.StartDate = Convert.ToString(reader[5]);
                }
            }
            return TourDetail;
        }
    }
}
