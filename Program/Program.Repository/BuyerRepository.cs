using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net;
using Program.Model;
using Program.Model.Common;
using Program.Repository.Common;

namespace Program.Repository
{
    public class BuyerRepository : IBuyerRepository
    {
        public  List<Buyer> GetAllBuyers()      //async
        {
            string connectionString = "Data Source=st-07\\MSSQLSERVER01;Initial Catalog=ZadatakGPP;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionString);

            using (connection)
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Buyer", connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();     //await

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
                    return buyers;
                }
                else
                {
                    reader.Close();
                    return null;
                }
            }
        }

        public List<Buyer> GetBuyer(Guid Id)
        {
            string connectionString = "Data Source=st-07\\MSSQLSERVER01;Initial Catalog=ZadatakGPP;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionString);

            using (connection)
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Buyer WHERE Id=@Id", connection);
                command.Parameters.AddWithValue("@Id", Id);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                List<Buyer> buyers = new List<Buyer>();

                if (reader.HasRows)
                {
                    reader.Read();
                    Buyer buyer = new Buyer();

                    buyer.Id = reader.GetGuid(0);
                    buyer.BuyerName = reader.GetString(1);
                    buyer.PersonalIdentificationNumber = reader.GetInt32(2);
                    buyer.TicketId = reader.GetGuid(3);

                    buyers.Add(buyer);

                    reader.Close();
                    return buyers;
                }
                else
                {
                    reader.Close();
                    return null;
                }
            }
        }
        public bool AddBuyer(Buyer buyer)
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
                if (rowsAffected > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public bool UpdateBuyer(Guid id, Buyer buyer)
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
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public bool DeleteBuyer(Guid id)
        {
            string connectionString = "Data Source=st-07\\MSSQLSERVER01;Initial Catalog=ZadatakGPP;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);

            using (connection)
            {
                SqlCommand command = new SqlCommand("DELETE FROM Buyer WHERE Id=@Id", connection);

                command.Parameters.AddWithValue("@Id", id);
                connection.Open();


                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}