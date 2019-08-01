using FantasyFootbal.Models.FootballTeam;
using FantasyFootbal.Models.Tournoment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FantasySportAdminPage.Models
{
    public class UserTeamFill
    {
        private string text;
        public UserTeamFill(string text)
        {
            this.text = text;
        }
        public List<FillModel> FillTeam(int id)
        {
            //configuration["ConnectionStrings:FSConnection"]
            CreateFootballClubViaAutocomplete adonetiPah = new CreateFootballClubViaAutocomplete(text);

            List<PlayersAutocompleteModel> allTeams = adonetiPah.GetPlayers(id);

            List<PlayersAutocompleteModel> GK = new List<PlayersAutocompleteModel>();
            List<PlayersAutocompleteModel> DF = new List<PlayersAutocompleteModel>();
            List<PlayersAutocompleteModel> MD = new List<PlayersAutocompleteModel>();
            List<PlayersAutocompleteModel> FW = new List<PlayersAutocompleteModel>();


            for (int i = 0; i < allTeams.Count; i++)
            {

                switch (allTeams[i].Position.ToString())
                {
                    case "Goalkeeper":
                        GK.Add(new PlayersAutocompleteModel() { Name = allTeams[i].Name, Position = allTeams[i].Position, PlayerId = allTeams[i].PlayerId, TeamId = allTeams[i].TeamId, Price = allTeams[i].Price });
                        break;
                    case "Defender":
                        DF.Add(new PlayersAutocompleteModel() { Name = allTeams[i].Name, Position = allTeams[i].Position, PlayerId = allTeams[i].PlayerId, TeamId = allTeams[i].TeamId, Price = allTeams[i].Price });
                        break;
                    case "Midfielder":
                        MD.Add(new PlayersAutocompleteModel() { Name = allTeams[i].Name, Position = allTeams[i].Position, PlayerId = allTeams[i].PlayerId, TeamId = allTeams[i].TeamId, Price = allTeams[i].Price });
                        break;
                    case "Forward":
                        FW.Add(new PlayersAutocompleteModel() { Name = allTeams[i].Name, Position = allTeams[i].Position, PlayerId = allTeams[i].PlayerId, TeamId = allTeams[i].TeamId, Price = allTeams[i].Price });
                        break;
                }
            }
            Random rd = new Random();
            string[] combinations = { "541", "532", "523", "451", "442", "433", "352", "343" };



            int teamSum = 0;
            UserFootballClub userTeam = new UserFootballClub();
            int cnt = 0;
            do
            {
                userTeam.MyTeam.Clear();
                teamSum = 0;
                int index = rd.Next(0, 8);
                string comb = combinations[index];
                userTeam.MyTeam.Add(GK[rd.Next(0, GK.Count)]);
                for (int i = 0; i < Convert.ToInt32(comb[0].ToString()); i++)
                {
                    userTeam.MyTeam.Add(DF[rd.Next(0, DF.Count)]);
                }
                for (int i = 0; i < Convert.ToInt32(comb[1].ToString()); i++)
                {
                    userTeam.MyTeam.Add(MD[rd.Next(0, MD.Count)]);
                }
                for (int i = 0; i < Convert.ToInt32(comb[2].ToString()); i++)
                {
                    userTeam.MyTeam.Add(FW[rd.Next(0, FW.Count)]);
                }
                teamSum = userTeam.GetSum();
                cnt++;
                if (cnt > 1000000)
                {
                    userTeam.MyTeam.Clear();

                    break;
                }
            } while ((teamSum > 100000 && teamSum < 800000) && userTeam.Check() == true);     //Autocomplete

            var result = (from t in userTeam.MyTeam select new { Name = t.Name, Position = t.Position });
            List<FillModel> list = new List<FillModel>();

            foreach (var item in result)
            {
                FillModel fillModel = new FillModel() { Name = item.Name, Position = item.Position };
                list.Add(fillModel);
            }
            return list;
        }


    }
}
