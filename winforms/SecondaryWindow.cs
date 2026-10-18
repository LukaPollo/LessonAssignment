using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Windows.Forms;

namespace winforms
{
    public partial class SecondaryWindow : Form
    {
        public class Users
        {
            public int UserId { get; set; }
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
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }

        public string connString = "server=localhost;port=3306;database=webaruhaz;uid=root";
        public void Database1()
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                string selectString = "SELECT users.UserId, users.Username FROM users;";
                using (MySqlCommand cmd = new MySqlCommand(selectString, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int userId = reader.GetInt32(0);
                            string username = reader.GetString(1);
                            Users newUser = new Users();
                            newUser.UserId = userId;
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

                int userId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["UserId"].Value);

                string folderUsersImg = "C:\\Users\\explo\\Documents\\Iskola\\Mas\\LessonAssignment\\winforms\\winforms\\UserPictures\\";
                string imagePath = "C:\\Users\\explo\\Documents\\Iskola\\Mas\\LessonAssignment\\winforms\\winforms\\UserPictures\\user_" + userId + ".jpg";
                string link = "https://cataas.com/cat";
                pictureBox1.Image = ApiService(link, imagePath);
            }
        }
        /*
         https://cataas.com/cat api with /cat for random cat create profile picture for every user when clicked on (dataGridView1_CellContentClick_1) and cache in UserPictures folder 
         */

        public static Image ApiService(string link, string imagePath)
        {
            HttpClient client = new HttpClient();

            if (File.Exists(imagePath))
            {
                return Image.FromFile(imagePath);
            }

            var downloadedImage = client.GetByteArrayAsync(link).Result;
            File.WriteAllBytes(imagePath, downloadedImage);

            return Image.FromFile(imagePath);
        }

    }
}
