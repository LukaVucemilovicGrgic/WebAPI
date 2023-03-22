using Program.WebApi.Controllers;
using Program.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        //public static List<FootballPlayer> players = new List<FootballPlayer>
        //{
        //    new FootballPlayer { Name = "Luka Lukic", Number = 1, Position = "goalkeeper", YearsInContract = 1, Club = "NK Osijek"},
        //    new FootballPlayer { Name = "Kruno Skoro", Number = 4, Position = "forward", YearsInContract = 4, Club = "NK Varazdin"},
        //    new FootballPlayer { Name = "Pero Peric", Number = 7, Position = "midfield", YearsInContract = 2, Club = "NK Hajduk"},
        //    new FootballPlayer { Name = "Bruno Bukic", Number = 5, Position = "defense", YearsInContract = 2, Club = "NK Dinamo"},
        //    new FootballPlayer { Name = "Matej Jukic", Number = 8, Position = "defense", YearsInContract = 1, Club = "NK Rijeka"}
        //};

        // GET api/players/

        [HttpGet]
        public HttpResponseMessage Get()
        {
            string connectionString = "Data Source=st-07\\MSSQLSERVER01;Initial Catalog=ZadatakGPP;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionString);

            using (connection)
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Buyer", connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                List<Buyer> buyers = new List<Buyer>();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Buyer buyer = new Buyer();

                        buyer.Id = reader.GetGuid(0);
                        buyer.BuyerName = reader.GetString(1);
                        buyer.PersonalIdentificationNumber = reader.GetInt32(2);
                        buyer.TicketId = reader.GetGuid(3);

                        buyers.Add(buyer);
                    }
                    reader.Close();
                    return Request.CreateResponse(HttpStatusCode.OK, buyers);
                }
                else
                {
                    reader.Close();
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Wrong input");
                }
            }
        }

        [HttpGet]
        public HttpResponseMessage Get(Guid id)
        {
            string connectionString = "Data Source=st-07\\MSSQLSERVER01;Initial Catalog=ZadatakGPP;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionString);

            using (connection)
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Buyer WHERE Id=@Id", connection);
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    Buyer buyer = new Buyer();

                    buyer.Id = reader.GetGuid(0);
                    buyer.BuyerName = reader.GetString(1);
                    buyer.PersonalIdentificationNumber = reader.GetInt32(2);
                    buyer.TicketId = reader.GetGuid(3);

                    reader.Close();
                    return Request.CreateResponse(HttpStatusCode.OK, buyer);
                }
                else
                {
                    reader.Close();
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Buyer with Id " + id + " not found.");
                }
            }
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody] Buyer buyer)
        {
            string connectionString = "Data Source=st-07\\MSSQLSERVER01;Initial Catalog=ZadatakGPP;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionString);

            using (connection)
            {
                SqlCommand command = new SqlCommand("INSERT INTO Buyer (Id, BuyerName, PersonalIdentificationNumber, TicketId)" +
                " VALUES (@Id, @BuyerName, @PersonalIdentificationNumber, @TicketId)", connection);
                buyer.Id = Guid.NewGuid();                          //izbacili smo Id iz Body-a 
                command.Parameters.AddWithValue("@Id", buyer.Id);
                command.Parameters.AddWithValue("@BuyerName", buyer.BuyerName);
                command.Parameters.AddWithValue("@PersonalIdentificationNumber", buyer.PersonalIdentificationNumber);
                command.Parameters.AddWithValue("@TicketId", buyer.TicketId);

                connection.Open();

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected >= 0)
                {
                    return Request.CreateResponse(HttpStatusCode.Created, buyer);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Failed to create buyer.");
                }
            }
        }

        [HttpPut]
        public HttpResponseMessage Put(Guid id, [FromBody] Buyer buyer)
        {
            string connectionString = "Data Source=st-07\\MSSQLSERVER01;Initial Catalog=ZadatakGPP;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionString);

            using (connection)
            {
                SqlCommand command = new SqlCommand("UPDATE Buyer SET BuyerName=@BuyerName, " +
                "PersonalIdentificationNumber=@PersonalIdentificationNumber, TicketId=@TicketId WHERE Id=@Id", connection);
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@BuyerName", buyer.BuyerName);
                command.Parameters.AddWithValue("@PersonalIdentificationNumber", buyer.PersonalIdentificationNumber);
                command.Parameters.AddWithValue("@TicketId", buyer.TicketId);

                connection.Open();

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, buyer);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Buyer with Id " + id + " not found.");
                }
            }
        }




        //return Request.CreateResponse(HttpStatusCode.OK, players);

        // GET api/players/1
        //[HttpGet]
        //public HttpResponseMessage Get(int id)
        //{
        //    var newPlayer = players.FirstOrDefault(p => p.Number == id);
        //    if (newPlayer != null)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.OK, newPlayer);
        //    }
        //    else
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "The number you typed does not exist in the list.");
        //    }
        //}


        //// POST api/players
        //[HttpPost]
        //public HttpResponseMessage Post([FromBody] FootballPlayer footballPlayer)
        //{
        //    var existingPlayer = players.FirstOrDefault(p => p.Number == footballPlayer.Number);
        //    if (existingPlayer == null)
        //    {   
        //        players.Add(footballPlayer);
        //        return Request.CreateResponse(HttpStatusCode.OK, players);  
        //    }
        //    else
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "The number you typed does not exist in the list.");
        //    }
        //}

        //// PUT api/players/5
        //[HttpPut]
        //public HttpResponseMessage Put(int id, [FromBody] FootballPlayer updatedPlayer)
        //{
        //    var playerToUpdate = players.FirstOrDefault(p => p.Number == id);
        //    if (playerToUpdate != null)
        //    {

        //        playerToUpdate.Name = updatedPlayer.Name;
        //        playerToUpdate.Number = updatedPlayer.Number;
        //        playerToUpdate.Position = updatedPlayer.Position;
        //        playerToUpdate.YearsInContract = updatedPlayer.YearsInContract;
        //        playerToUpdate.Club = updatedPlayer.Club;

        //        return Request.CreateResponse(HttpStatusCode.OK, players);
        //    }
        //    else
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "The number you typed does not exist in the list.");
        //    }
        //}

        //// DELETE api/players/5
        //[HttpDelete]
        //public HttpResponseMessage Delete(int id)
        //{
        //    var playerToDelete = players.FirstOrDefault(p => p.Number == id);
        //    if (playerToDelete != null)
        //    {
        //        players.Remove(playerToDelete);
        //        return Request.CreateResponse(HttpStatusCode.OK, players);
        //    }
        //    else
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "The number you typed does not exist in the list.");
        //    }
        //}

    }
}


