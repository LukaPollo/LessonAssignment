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

                string dataLoadUsers = "";
                using (MySqlCommand cmd = new MySqlCommand(dataLoadUsers, conn))
                {
                    cmd.ExecuteNonQuery();
                }
                Console.WriteLine("Data in :D");
                Console.ReadKey();
            }
        }
    }
}
