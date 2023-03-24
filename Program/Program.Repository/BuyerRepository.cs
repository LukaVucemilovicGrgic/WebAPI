﻿using System;
using System.Threading.Tasks;
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
        public async Task<List<Buyer>> GetAllBuyersAsync()      //async Task<T>
        {
            string connectionString = "Data Source=st-07\\MSSQLSERVER01;Initial Catalog=ZadatakGPP;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionString);

            using (connection)
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Buyer", connection);
                connection.Open();

                SqlDataReader reader = await command.ExecuteReaderAsync();     //await

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

        public async Task<List<Buyer>> GetBuyerAsync(Guid Id)
        {
            string connectionString = "Data Source=st-07\\MSSQLSERVER01;Initial Catalog=ZadatakGPP;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionString);

            using (connection)
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Buyer WHERE Id=@Id", connection);
                command.Parameters.AddWithValue("@Id", Id);
                connection.Open();

                SqlDataReader reader = await command.ExecuteReaderAsync();

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
        public async Task<bool> AddBuyerAsync(Buyer buyer)
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

                int rowsAffected = await command.ExecuteNonQueryAsync();
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
        public async Task<bool> UpdateBuyerAsync(Guid id, Buyer buyer)
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

                int rowsAffected = await command.ExecuteNonQueryAsync();
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
        public async Task<bool> DeleteBuyerAsync(Guid id)
        {
            string connectionString = "Data Source=st-07\\MSSQLSERVER01;Initial Catalog=ZadatakGPP;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);

            using (connection)
            {
                SqlCommand command = new SqlCommand("DELETE FROM Buyer WHERE Id=@Id", connection);

                command.Parameters.AddWithValue("@Id", id);
                connection.Open();


                int rowsAffected = await command.ExecuteNonQueryAsync();
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