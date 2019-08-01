using FantasyFootbal.Models.FootballTeam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FantasyFootbal.Models.Tournoment
{
    public class UserFootballClub
    {
        // Creating the list of players
        public List<PlayersAutocompleteModel> MyTeam { get; set; }

        // Contractor
        public UserFootballClub()
        {
            MyTeam = new List<PlayersAutocompleteModel>();
        }

        // Get sum price of the players of each virtual footbal club, the sum count of players in each club are 11
        public int GetSum()
        {
            int Sum = 0;

            foreach (var player in MyTeam)
            {
                Sum += player.Price;
            }
            return Sum;
        }

        // With those function, we check the composition of the club so that the player do not repeat.
        public bool Check()
        {
            for (int i = 0; i < 10; i++)
            {
                int count = 0;
                for (int j = 0; j < 11; j++)
                {
                    if(MyTeam[i].TeamId == MyTeam[j].TeamId)
                    {
                        count++;
                    }
                    if(MyTeam[i].TeamId == MyTeam[j].TeamId && MyTeam[i].PlayerId == MyTeam[j].PlayerId)
                    {
                        return true;
                    }
                }
                if(count > 1)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
