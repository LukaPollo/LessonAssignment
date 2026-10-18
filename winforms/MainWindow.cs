using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;

namespace winforms
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /*
         button opens form2 , we select user and show their orders
        */

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1_CellContentClick_1(sender, new DataGridViewCellEventArgs(0, 0));
            RedirectBtn_Click_1(sender, e);
        }
        private List<UsersOrder> usersOrders = new List<UsersOrder>();
        public void Database(string dbPath) 
        {
            using (MySqlConnection conn = new MySqlConnection(dbPath))
            {
                conn.Open();
                string selectString = "SELECT users.Username, orders.OrderId, orders.TotalAmount, orders.OrderDate FROM users JOIN orders ON users.UserId = orders.UserId;";
                using (MySqlCommand cmd = new MySqlCommand(selectString, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            UsersOrder userOrder = new UsersOrder();
                            userOrder.UserName = reader.GetString(0);
                            userOrder.OrderId = reader.GetInt32(1);
                            userOrder.OrderValue = reader.GetDecimal(2);
                            userOrder.OrderDate = reader.GetDateTime(3);
                            usersOrders.Add(userOrder);
                        }
                    }
                }
            }
        }
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            string dbPath = "server=localhost;port=3306;database=webaruhaz;uid=root"; 
            Database(dbPath); 
            dataGridView1.DataSource = usersOrders; 
        }
        private void RedirectBtn_Click_1(object sender, EventArgs e)
        {
            SecondaryWindow secondaryWindow = new SecondaryWindow();
            secondaryWindow.Show();
        }
    }
}
