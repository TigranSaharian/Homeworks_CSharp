using FantasyFootbal.Models;
using FantasyFootbal.Models.FootballTeam;
using FantasyFootbal.Models.Tournoment;
using FantasyFootbal.Models.User;
using FantasySportAdminPage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace FantasyFootbal.Controllers
{
    public class HomeController : Controller
    {
        // 
        public static string EmailSet;
        //
        public static int TeamId;
        // Connection to tournament data
        private readonly TournamentContext tournamentContext;
        // Connection to users data
        private readonly UserContext userContext;
        //
        private readonly IConfiguration configuration;

        // Constructor
        public HomeController(TournamentContext tournamentContext, UserContext userContext, IConfiguration configuration)
        {
            this.tournamentContext = tournamentContext;
            this.userContext = userContext;
            this.configuration = configuration;
        }

        // Get all teams through autocomplete ajax request
        [HttpPost]
        public JsonResult Autocomplete(string Prefix)
        {
            var result = (from a in tournamentContext.Teams
                          where a.TeamName.Contains(Prefix)
                          select new
                          {
                              teamName = a.TeamName,
                              teamId = a.Id
                          }).ToList();

            return Json(result);
        }

        // after collecting the virtual footbal club we add it in the database
        [HttpPost]
        public IActionResult AddPlayers([FromBody]List<Player> player)
        {
            foreach (var item in player)
            {
                tournamentContext.Database.ExecuteSqlCommand("AddPlayer @user, @player, @id",
                 new SqlParameter("@user", "testUsr"),
                 new SqlParameter("@player", item.FootballPlayer),
                 new SqlParameter("@id", TeamId));
            }
            return View();
        }

        #region Reset password
        // Action to reset password view
        public IActionResult ResetPassword()
        {
            return View();
        }

        // The method which organizes the password recovery process
        [HttpPost]
        public IActionResult ResetPassword(string email)
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

            return View();
        }

        // Getting new password
        [HttpGet]
        public IActionResult NewPassword(string password)
        {

            EmailSet = null;

            var resultParameter = new SqlParameter("@email", SqlDbType.VarChar, 150)
            {
                Direction = ParameterDirection.Output
            };

            var recordsAffected = userContext.Database.ExecuteSqlCommand("sp_GetEmailForReset @param ,@email  out ",
                  new SqlParameter("@param", password), resultParameter);

            EmailSet = resultParameter.Value.ToString();

            return View();
        }

        // Creating a new password and hashing it
        [HttpPost]
        public IActionResult NewPassword(string NewPassword, int a = 1)
        {
            var recordsAffected = userContext.Database.ExecuteSqlCommand("sp_resset @email, @NewPass ",
            new SqlParameter("@email", EmailSet),
            new SqlParameter("@NewPass", ComputeSha256Hash(NewPassword)));

            return RedirectToAction("Tournament", "Home"); 
        }
        #endregion

        // db connection via json for autocomplete
        public JsonResult FillAutocomplete()
        {
            UserTeamFill userTeamFill = new UserTeamFill(configuration["ConnectionStrings:FFTourDb_Connection"]);
            return Json(userTeamFill.FillTeam(TeamId));
        }

        // 
        public ActionResult<IList<TournamentDetails>> Tournament()
        {
            TournamentDetailsManage manage = new TournamentDetailsManage(configuration["ConnectionStrings:FFTourDb_Connection"]);
            return View(manage.GetTournamentDetails());
        }

        //
        public IActionResult TeamDetails(int? id, string all_teams, string hdd)
        {

            List<Team> teams;
            List<PlayerModel> players;
            List<TournamentModel> matche;
            TournamentDetails tournamentDetails;


            if (id != 0 || id != null)
            {

                TeamId = (int)id;
                NavForTurDetailsManage navForTurDetailsManage = new NavForTurDetailsManage(configuration["ConnectionStrings:FFTourDb_Connection"]);
                teams = navForTurDetailsManage.GetTeams(TeamId);
                players = navForTurDetailsManage.GetPlayers(TeamId, all_teams, CheckPlayerRole.GetRole(hdd));
                matche = navForTurDetailsManage.GetMatchDetails(TeamId);
                tournamentDetails = navForTurDetailsManage.GetTurDet(TeamId);

            }
            else
            {
                TeamId = (int)id;
                NavForTurDetailsManage navForTurDetailsManage = new NavForTurDetailsManage(configuration["ConnectionStrings:FFTourDb_Connection"]);
                teams = navForTurDetailsManage.GetTeams(TeamId);
                players = navForTurDetailsManage.GetPlayers(TeamId, all_teams, CheckPlayerRole.GetRole(hdd));
                matche = navForTurDetailsManage.GetMatchDetails(TeamId);
                tournamentDetails = navForTurDetailsManage.GetTurDet(TeamId);

            }

            NavForTurDetailsModel navForTurDetailsModel = new NavForTurDetailsModel()
            {
                Teams = new SelectList(teams, "TeamName", "TeamName"),
                Players = players.ToList(),
                TournamentDetails = tournamentDetails,
                Matches = matche
            };

            return View(navForTurDetailsModel);
        }

        #region Registration
        // Open registration view
        public IActionResult Registration()
        {
            return View();
        }

        // Encript the password for security
        private static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        // Send post request and create user
        [HttpPost]
        public IActionResult Registration(User model)
        {
            // Get user properties
            UserRepository userRepository = new UserRepository(userContext);

            // Call the method for encriting and put encriypted password to DB
            model.Password = ComputeSha256Hash(model.Password);

            // Create new user
            userRepository.CreateUser(model);

            // Jump to home page after registration
            return RedirectToAction("Tournament", "Home");
        }
        #endregion


        #region Admin Page
        // Open Admin Page
        public IActionResult Admin()
        {
            return View();
        }
        #endregion

        //
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
