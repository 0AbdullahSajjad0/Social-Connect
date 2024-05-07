using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Notifications : Form
    {
        private string connectionString = "Data Source=DESKTOP-7KK116N\\SQLEXPRESS;Initial Catalog=SocialConnect;Integrated Security=True";
        
        public Notifications()
        {
            InitializeComponent();
            SetupDataGridView();
        }

        private void SetupDataGridView()
        {
            //dataGridView1.Columns.Add("Notification", "Notification");
            dataGridView1.AutoResizeColumns();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowHeadersVisible = false;
        }

        private void Notifications_Load(object sender, EventArgs e)
        {
            int currentUserId = SessionData.CurrentUser.Id;

            // Clear existing rows
            dataGridView1.Rows.Clear();

            // Get followers
            string followersQuery = "SELECT Users.name FROM Followers INNER JOIN Users ON Followers.followerId = Users.id WHERE Followers.userId = @currentUserId";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(followersQuery, connection))
                {
                    command.Parameters.AddWithValue("@currentUserId", currentUserId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        int serialNo = 1;
                        while (reader.Read())
                        {
                            string followerName = reader.GetString(0);
                            dataGridView1.Rows.Add(serialNo++, followerName + " has followed you.");
                        }
                    }
                }
            }

            // Get post likes
            string likesQuery = "SELECT Users.name FROM Likes INNER JOIN Users ON Likes.userId = Users.id INNER JOIN Posts ON Likes.postId = Posts.postId WHERE Posts.userId = @currentUserId";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(likesQuery, connection))
                {
                    command.Parameters.AddWithValue("@currentUserId", currentUserId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        int serialNo = dataGridView1.Rows.Count + 1; // Start serial number after previous rows
                        while (reader.Read())
                        {
                            string likerName = reader.GetString(0);
                            dataGridView1.Rows.Add(serialNo++, likerName + " has liked your post.");
                        }
                    }
                }
            }
        }


        private void AddNotification(string notification)
        {
            dataGridView1.Rows.Add(new object[] { notification });
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // This method can be used if you want to handle clicks on the cell contents, such as opening a detailed view.
        }

        private void button6_Click(object sender, EventArgs e)
        {
            HomepageScreen homepageScreen = new HomepageScreen();
            homepageScreen.Show();
            this.Close();
        }
    }
}
