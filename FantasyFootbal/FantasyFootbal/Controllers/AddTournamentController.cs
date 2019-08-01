using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using FantasyFootbal.Models.Tournoment;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FantasyFootbal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddTournamentController : ControllerBase
    {
        readonly TournamentContext context;

        public AddTournamentController(TournamentContext context)
        {
            this.context = context;
        }

        [Route("AddTour")]
        [HttpPost]
        public void AddTour([FromBody] TournamentNavModel tourNavModel)
        {
            var resultParameter = new SqlParameter("@id", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };

            var recordsAffected = context.Database.ExecuteSqlCommand("sp_AddTurTitile @id out, @title, @balance, @price ", resultParameter,
                  new SqlParameter("@title", tourNavModel.TourHeader.Title),
                  new SqlParameter("@balance", tourNavModel.TourHeader.Balance),
                  new SqlParameter("@price", tourNavModel.TourHeader.Price)
            );

            int y = (int)resultParameter.Value;
            foreach (var item in tourNavModel.TourModel)
            {
                context.Database.ExecuteSqlCommand("sp_turnamentTbl @id, @team1, @startdate, @team2",

                  new SqlParameter("@id", (int)resultParameter.Value),
                  new SqlParameter("@team1", item.Team_1),
                  new SqlParameter("@startdate", item.StartDate),
                  new SqlParameter("@team2", item.Team_2));
            }
        }
    }
}