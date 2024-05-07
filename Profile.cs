using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Profile : Form
    {
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private string connectionString = "Data Source=DESKTOP-7KK116N\\SQLEXPRESS;Initial Catalog=SocialConnect;Integrated Security=True";

        public Profile()
        {
            InitializeComponent();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            LoadProfileName();
            LoadProfileImage(); // Load the profile image when the form loads
            LoadPrivacySetting(); // Load the privacy setting when the form loads
            LoadFollowCounts();
        }

        private void LoadProfileImage()
        {
            int currentUserId = SessionData.CurrentUser.Id;
            byte[] imageData = GetProfileImageData(currentUserId);

            if (imageData != null)
            {
                using (MemoryStream ms = new MemoryStream(imageData))
                {
                    pictureBox1.Image = Image.FromStream(ms);
                }
            }
            else
            {
                pictureBox1.Image = null;
            }
        }

        private byte[] GetProfileImageData(int userId)
        {
            byte[] imageData = null;

            string query = "SELECT image FROM ProfilePicture WHERE UserId = @UserId";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            imageData = (byte[])reader["image"];
                        }
                    }
                }
            }

            return imageData;
        }

        private void LoadPrivacySetting()
        {
            int currentUserId = SessionData.CurrentUser.Id;
            bool isPrivate = GetUserPrivacy(currentUserId);

            checkBox1.Checked = isPrivate;
        }

        private bool GetUserPrivacy(int userId)
        {
            bool isPrivate = false;

            string query = "SELECT private FROM Users WHERE id = @UserId";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);
                    connection.Open();

                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        isPrivate = (bool)result;
                    }
                }
            }

            return isPrivate;
        }

        private void LoadFollowCounts()
        {
            int userId = SessionData.CurrentUser.Id;

            // Query to count followers and followings
            string queryFollowers = "SELECT COUNT(*) FROM Followers WHERE userId = @userId";
            string queryFollowing = "SELECT COUNT(*) FROM Followers WHERE followerId = @userId";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmdFollowers = new SqlCommand(queryFollowers, connection))
                    {
                        cmdFollowers.Parameters.AddWithValue("@userId", userId);
                        int followersCount = (int)cmdFollowers.ExecuteScalar();
                        label5.Text = followersCount.ToString();
                    }

                    using (SqlCommand cmdFollowing = new SqlCommand(queryFollowing, connection))
                    {
                        cmdFollowing.Parameters.AddWithValue("@userId", userId);
                        int followingCount = (int)cmdFollowing.ExecuteScalar();
                        label6.Text = followingCount.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading follower/following counts: " + ex.Message);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Event handler for profile picture click
        }

        private void label2_Click(object sender, EventArgs e)
        {
            // Event handler for label click
        }

        private void label7_Click(object sender, EventArgs e)
        {
            // Event handler for label click
        }

        private void Profile_Load(object sender, EventArgs e)
        {
            // Event handler for form load
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = false;  // Allow only single file selection
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog1.FileName;

                byte[] imageData = File.ReadAllBytes(imagePath);

                int currentUserId = SessionData.CurrentUser.Id;

                if (HasProfilePicture(currentUserId))
                {
                    UpdateProfilePicture(currentUserId, imageData);
                }
                else
                {
                    InsertProfilePicture(currentUserId, imageData);
                }

                pictureBox1.Image = Image.FromFile(imagePath);
            }
        }

        private bool HasProfilePicture(int userId)
        {
            string query = "SELECT COUNT(*) FROM ProfilePicture WHERE UserId = @UserId";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);
                    connection.Open();

                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        private void UpdateProfilePicture(int userId, byte[] imageData)
        {
            string query = "UPDATE ProfilePicture SET image = @Image WHERE UserId = @UserId";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);
                    command.Parameters.AddWithValue("@Image", imageData);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        private void InsertProfilePicture(int userId, byte[] imageData)
        {
            string query = "INSERT INTO ProfilePicture (UserId, image) VALUES (@UserId, @Image)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);
                    command.Parameters.AddWithValue("@Image", imageData);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        private void LoadProfileName()
        {
            int currentUserId = SessionData.CurrentUser.Id;
            string userName = GetUserName(currentUserId);

            if (!string.IsNullOrEmpty(userName))
            {
                // Assuming there is a Label control named labelName to display the user's name
                label1.Text = userName;
            }
        }

        private string GetUserName(int userId)
        {
            string userName = null;
            string query = "SELECT Name FROM Users WHERE Id = @UserId";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@UserId", userId);
                    conn.Open();

                    object result = command.ExecuteScalar(); // Retrieve a single value
                    if (result != null && result != DBNull.Value)
                    {
                        userName = result.ToString(); // Convert the result to string
                    }
                }
            }

            return userName;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            HomepageScreen homepageScreen = new HomepageScreen();
            homepageScreen.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserFeed userFeed = new UserFeed();
            userFeed.Show();
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // Event handler for checkbox state change
            if (checkBox1.Focused) // Ensures the change was user-generated, not code-generated
            {
                UpdateUserPrivacy(SessionData.CurrentUser.Id, checkBox1.Checked);
            }
        }

        private void UpdateUserPrivacy(int userId, bool isPrivate)
        {
            string query = "UPDATE Users SET private = @IsPrivate WHERE id = @UserId";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);
                    command.Parameters.AddWithValue("@IsPrivate", isPrivate);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
