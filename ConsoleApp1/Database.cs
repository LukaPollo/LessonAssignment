using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace ConsoleApp1
{
    internal class Database
    {
        /*
        sorrend
        1. Users.csv
        2. Product.csv
        3. Service.csv
        4. Address.csv
        5. Orders.csv
        6. Delivery.csv
        7. Payment.csv
        8. Cart.csv
         */
        public static void DatabaseConn(string connection)
        {
            using (MySqlConnection conn = new MySqlConnection(connection))
            {
                conn.Open();
                Console.WriteLine("Connection to the database successful.");

                string dataLoadUsers = "INSERT INTO users (UserId INT, Username VARCHAR(255), UserEmail VARCHAR(255), UserPassword VARCHAR(255) VALUES (@UserId, @Username, @UserEmail, @UserPassword))";
                using (MySqlCommand cmd = new MySqlCommand(dataLoadUsers, conn))
                {

                    cmd.ExecuteNonQuery();
                }
                string dataLoadProduct = "INSERT INTO product () VALUES ()";
                using (MySqlCommand cmd = new MySqlCommand(dataLoadProduct, conn))
                {
                    cmd.ExecuteNonQuery();
                }
                string dataLoadService = "INSERT INTO service () VALUES ()";
                using (MySqlCommand cmd = new MySqlCommand(dataLoadService, conn))
                {
                    cmd.ExecuteNonQuery();
                }
                string dataLoadAddress = "INSERT INTO address () VALUES ()";
                using (MySqlCommand cmd = new MySqlCommand(dataLoadAddress, conn))
                {
                    cmd.ExecuteNonQuery();
                }
                string dataLoadOrders = "INSERT INTO orders () VALUES ()";
                using (MySqlCommand cmd = new MySqlCommand(dataLoadOrders, conn))
                {
                    cmd.ExecuteNonQuery();
                }
                string dataLoadDelivery = "INSERT INTO delivery () VALUES ()";
                using (MySqlCommand cmd = new MySqlCommand(dataLoadDelivery, conn))
                {
                    cmd.ExecuteNonQuery();
                }
                string dataLoadPayment = "INSERT INTO payment () VALUES ()";
                using (MySqlCommand cmd = new MySqlCommand(dataLoadPayment, conn))
                {
                    cmd.ExecuteNonQuery();
                }
                string dataLoadCart = "INSERT INTO cart () VALUES ()";
                using (MySqlCommand cmd = new MySqlCommand(dataLoadCart, conn))
                {
                    cmd.ExecuteNonQuery();
                }
                Console.WriteLine("Data in :D");
                Console.ReadKey();
            }
        }
    }
}
