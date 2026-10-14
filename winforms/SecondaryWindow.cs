using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace winforms
{
    public partial class SecondaryWindow : Form
    {
        public class Users
        {
            public string Username { get; set; }
        }

        public class Orders                                                       
        {
            public int OrderId { get; set; }
            public decimal OrderValue { get; set; }
            public DateTime OrderDate { get; set; }
        }

        private List<Users> users = new List<Users>();
        private List<Orders> orders = new List<Orders>();

        public SecondaryWindow()
        {
            InitializeComponent();
        }

        private void SecondaryWindow_Load(object sender, EventArgs e)
        {
            Database1();
            dataGridView1.DataSource = users;
            //dataGridView1_CellContentClick(sender, new DataGridViewCellEventArgs(0, 0));
        }

        public string connString = "server=localhost;port=3307;database=webaruhaz;uid=root";
        public void Database1()
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                string selectString = "SELECT users.Username FROM users;";
                using (MySqlCommand cmd = new MySqlCommand(selectString, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string username = reader.GetString(0);
                            Users newUser = new Users();
                            newUser.Username = username;
                            users.Add(newUser);
                        }
                    }
                }
            }
        }
        public void Database2(string username)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                string selectString = "SELECT orders.OrderId, orders.TotalAmount, orders.OrderDate FROM orders JOIN users ON users.UserId = orders.UserId WHERE users.Username = @username;";
                using (MySqlCommand cmd = new MySqlCommand(selectString, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int orderId = reader.GetInt32(0);
                            decimal orderValue = reader.GetDecimal(1);
                            DateTime orderDate = reader.GetDateTime(2);
                            Orders newOrder = new Orders();
                            newOrder.OrderId = orderId;
                            newOrder.OrderValue = orderValue;
                            newOrder.OrderDate = orderDate;
                            orders.Add(newOrder);
                        }
                    }
                }
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string selectedUsername = dataGridView1.Rows[e.RowIndex].Cells["Username"].Value.ToString();

                orders.Clear();
                Database2(selectedUsername);
                dataGridView2.DataSource = orders;
                dataGridView2.Refresh();
            }
        }
        /*
         https://cataas.com/cat api with /cat for random cat create profile picture for every user when clicked on (dataGridView1_CellContentClick_1) and cache in UserPictures folder 
         */

        public void ApiService()
        {
            HttpClient client = new HttpClient();
            
        }

    }
}
