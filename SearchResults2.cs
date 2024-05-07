using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class SearchResults2 : Form
    {
        private string connectionString = "Data Source=DESKTOP-7KK116N\\SQLEXPRESS;Initial Catalog=SocialConnect;Integrated Security=True";

        public SearchResults2()
        {
            InitializeComponent();
        }

        private void SearchResults2_Load(object sender, EventArgs e)
        {
            LoadFollowCounts();
            SetFollowButtonText();
            LoadProfilePicture();
            LoadProfileName();
        }

        private void LoadProfilePicture()
        {
            int userId = SearchClass.SearchId;

            string query = "SELECT image FROM ProfilePicture WHERE UserId = @userId";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@userId", userId);
                        byte[] imageData = (byte[])command.ExecuteScalar();

                        if (imageData != null)
                        {
                            // Convert byte array to image and display it
                            using (MemoryStream ms = new MemoryStream(imageData))
                            {
                                pictureBox1.Image = Image.FromStream(ms);
                            }
                        }
                        else
                        {
                            // No profile picture found, display default image or leave it empty
                            // For example, pictureBox1.Image = Properties.Resources.DefaultProfileImage;
                            // Or pictureBox1.Image = null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading profile picture: " + ex.Message);
            }
        }


        private void LoadFollowCounts()
        {
            int userId = SearchClass.SearchId;

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

        private void SetFollowButtonText()
        {
            int currentUser = SessionData.CurrentUser.Id;
            int searchedUser = SearchClass.SearchId;

            string query = "SELECT COUNT(*) FROM Followers WHERE userId = @userId AND followerId = @followerId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@userId", searchedUser);
                    cmd.Parameters.AddWithValue("@followerId", currentUser);

                    int result = (int)cmd.ExecuteScalar();
                    button1.Text = result > 0 ? "Unfollow" : "Follow";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }



        private void ExecuteQuery(string query, int currentUser, int searchedUser)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userId", searchedUser);
                    command.Parameters.AddWithValue("@followerId", currentUser);
                    command.ExecuteNonQuery();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int searchedUser = SearchClass.SearchId;
            bool isPrivate = CheckIfPrivate(searchedUser);
            bool isFollowed = button1.Text == "Unfollow";

            if (isPrivate && !isFollowed)
            {
                MessageBox.Show("Private account. Follow to see posts.");
            }
            else
            {
                Posts posts = new Posts();
                posts.Show();
                this.Close();
            }
        }

        private bool CheckIfPrivate(int userId)
        {
            string query = "SELECT private FROM Users WHERE id = @userId";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);
                    object result = command.ExecuteScalar();
                    return result != DBNull.Value && Convert.ToBoolean(result);
                }
            }
        }

        private void LoadProfileName()
        {
            int currentUserId = SearchClass.SearchId;
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
            SearchResults searchResults = new SearchResults();
            searchResults.Show();
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int currentUser = SessionData.CurrentUser.Id;
            int searchedUser = SearchClass.SearchId;

            

            try
            {
                if (button1.Text == "Follow")
                {
                    // Add follow relationship
                    string insertQuery = "INSERT INTO Followers (userId, followerId) VALUES (@userId, @followerId)";
                    ExecuteQuery(insertQuery, currentUser, searchedUser);
                    button1.Text = "Unfollow";
                }
                else
                {
                    // Remove follow relationship
                    string deleteQuery = "DELETE FROM Followers WHERE userId = @userId AND followerId = @followerId";
                    ExecuteQuery(deleteQuery, currentUser, searchedUser);
                    button1.Text = "Follow";
                }

                // Update the follower count label
                LoadFollowCounts();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
