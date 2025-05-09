using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bicycleRent.Models;
using MySql.Data.MySqlClient;

namespace bicycleRent.Repositories
{
    public class PaymentRepository
    {
        private readonly MySqlConnection _connection;

        public PaymentRepository(MySqlConnection connection) 
        {
            _connection = connection;
        }

        public bool Add(Payment payment)
        {
            string query = "INSERT INTO Payment (Payment_Amount, Type, Rent_Id) VALUES (@PaymentAmount, @Type, @RentId)";

            using (MySqlCommand cmd = new MySqlCommand(query, _connection)) 
            {
                cmd.Parameters.AddWithValue("@PaymentAmount", payment.PaymentAmount);
                cmd.Parameters.AddWithValue("@Type", payment.Type);
                cmd.Parameters.AddWithValue("@RentId", payment.RentId);

                int rowsInserted = cmd.ExecuteNonQuery();

                if(rowsInserted > 0)
                    return true;
                return false;
            }
        }

        public bool Delete(int id)
        {
            string query = "DELETE FROM Payment WHERE Payment_Id = @PaymentId";

            using (MySqlCommand cmd = new MySqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@PaymentId", id);

                int rowsDeleted = cmd.ExecuteNonQuery();

                if( rowsDeleted > 0) 
                    return true;
                return false;
            }
        }

        public bool DeleteAllPaymentsForRent(int rentId)
        {
            string query = "DELETE FROM Payment WHERE Rent_Id = @Rent_Id";

            using (MySqlCommand cmd = new MySqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@Rent_Id", rentId);

                int rowsDeleted = cmd.ExecuteNonQuery();

                if (rowsDeleted > 0)
                    return true;
                return false;
            }
        }

        public List<Payment> GetAllForRent(int rentId) 
        {
            List<Payment> payments = new List<Payment>();
            string query = "SELECT * FROM Payment WHERE Rent_Id = @RentId";

            using (MySqlCommand cmd = new MySqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@RentId", rentId);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Payment payment = new Payment() 
                        {
                            Id = reader.GetInt32("Payment_Id"),
                            PaymentAmount = reader.GetInt32("Payment_Amount"),
                            Type = reader.GetString("Type"),
                            RentId = reader.GetInt32("Rent_Id"),
                            Created_At = reader.GetDateTime("Created_At")
                        };
                        payments.Add(payment);
                    }
                }
            }
            return payments;
        }
    }
}
