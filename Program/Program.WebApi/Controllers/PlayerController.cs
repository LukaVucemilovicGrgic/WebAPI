using Program.WebApi.Controllers;
using Program.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.UI.WebControls;

namespace Program.WebApi.Controllers
{

    public class PlayerController : ApiController
    {
        public static List<FootballPlayer> players = new List<FootballPlayer>
        {
            new FootballPlayer { Name = "Luka Lukic", Number = 1, Position = "goalkeeper", YearsInContract = 1, Club = "NK Osijek"},
            new FootballPlayer { Name = "Kruno Skoro", Number = 4, Position = "forward", YearsInContract = 4, Club = "NK Varazdin"},
            new FootballPlayer { Name = "Pero Peric", Number = 7, Position = "midfield", YearsInContract = 2, Club = "NK Hajduk"},
            new FootballPlayer { Name = "Bruno Bukic", Number = 5, Position = "defense", YearsInContract = 2, Club = "NK Dinamo"},
            new FootballPlayer { Name = "Matej Jukic", Number = 8, Position = "defense", YearsInContract = 1, Club = "NK Rijeka"}
        };

        // GET api/players/

        [HttpGet]
        public HttpResponseMessage Get()
        {

            return Request.CreateResponse(HttpStatusCode.OK, players);
        }
        // GET api/players/1
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var newPlayer = players.FirstOrDefault(p => p.Number == id);
            if (newPlayer != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, newPlayer);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "The number you typed does not exist in the list.");
            }
        }


        // POST api/players
        [HttpPost]
        public HttpResponseMessage Post([FromBody] FootballPlayer footballPlayer)
        {
            var existingPlayer = players.FirstOrDefault(p => p.Number == footballPlayer.Number);
            if (existingPlayer == null)
            {   
                players.Add(footballPlayer);
                return Request.CreateResponse(HttpStatusCode.OK, players);  //WebApiConfig->name:"DefaultApi"
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "The number you typed does not exist in the list.");
            }
        }

        // PUT api/players/5
        [HttpPut]
        public HttpResponseMessage Put(int id, [FromBody] FootballPlayer updatedPlayer)
        {
            var playerToUpdate = players.FirstOrDefault(p => p.Number == id);
            if (playerToUpdate != null)
            {

                playerToUpdate.Name = updatedPlayer.Name;
                playerToUpdate.Number = updatedPlayer.Number;
                playerToUpdate.Position = updatedPlayer.Position;
                playerToUpdate.YearsInContract = updatedPlayer.YearsInContract;
                playerToUpdate.Club = updatedPlayer.Club;

                return Request.CreateResponse(HttpStatusCode.OK, players);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "The number you typed does not exist in the list.");
            }
        }

        // DELETE api/players/5
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            var playerToDelete = players.FirstOrDefault(p => p.Number == id);
            if (playerToDelete != null)
            {
                players.Remove(playerToDelete);
                return Request.CreateResponse(HttpStatusCode.OK, players);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "The number you typed does not exist in the list.");
            }
        }
    }
}