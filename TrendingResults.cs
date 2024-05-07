using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class TrendingResults : Form
    {
        private string connectionString = "Data Source=DESKTOP-7KK116N\\SQLEXPRESS;Initial Catalog=SocialConnect;Integrated Security=True";
        private List<byte[]> postsImages;
        private List<int> postIds;
        private List<string> postUsernames; // List to store usernames
        private int currentIndex = 0;

        public TrendingResults()
        {
            InitializeComponent();
        }

        private void TrendingResults_Load(object sender, EventArgs e)
        {
            string trend = Trends.Trend;
            LoadPosts(trend);
            DisplayCurrentPost();
        }

        private void LoadPosts(string trend)
        {
            postsImages = new List<byte[]>();
            postIds = new List<int>();
            postUsernames = new List<string>(); // List of usernames for posts

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Primary query to get public posts and private posts from followed users
                string primaryQuery = @"
        SELECT p.postId, p.image, u.username
        FROM Posts p
        JOIN Users u ON p.userId = u.id
        LEFT JOIN Followers f ON u.id = f.userId AND f.followerId = @currentUserId
        WHERE p.trend = @trend 
        AND (u.private = 0 OR f.id IS NOT NULL)
        ";

                using (SqlCommand command = new SqlCommand(primaryQuery, connection))
                {
                    command.Parameters.AddWithValue("@trend", trend);
                    command.Parameters.AddWithValue("@currentUserId", SessionData.CurrentUser.Id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int postId = reader.GetInt32(0);
                            byte[] imageBytes = (byte[])reader["image"];
                            string username = reader.GetString(2);
                            postIds.Add(postId);
                            postsImages.Add(imageBytes);
                            postUsernames.Add(username);
                        }
                    }
                }

                // Query to get public posts from users that the current user does not follow
                string unfollowedPublicPostsQuery = @"
        SELECT p.postId, p.image, u.username
        FROM Posts p
        JOIN Users u ON p.userId = u.id
        WHERE u.private is NULL
        OR u.private = 0    
        AND p.trend = @trend  
        AND u.id NOT IN ( 
          SELECT userId FROM Followers WHERE followerId = @currentUserId
        )
        ";

                using (SqlCommand publicCommand = new SqlCommand(unfollowedPublicPostsQuery, connection))
                {
                    publicCommand.Parameters.AddWithValue("@trend", trend);
                    publicCommand.Parameters.AddWithValue("@currentUserId", SessionData.CurrentUser.Id);
                    using (SqlDataReader publicReader = publicCommand.ExecuteReader())
                    {
                        while (publicReader.Read())
                        {
                            int postId = publicReader.GetInt32(0);  // Retrieve the post ID
                            byte[] imageBytes = (byte[])publicReader["image"];  // Retrieve the image data
                            string publicUsername = publicReader.GetString(2);  // Retrieve the username

                            postIds.Add(postId);  // Add the post ID to the list
                            postsImages.Add(imageBytes);  // Add the image data to the list
                            postUsernames.Add(publicUsername);  // Add the username to the list
                        }
                    }
                }
            }
        }


        private void UpdateLikeCount(int postId)
        {
            string query = "SELECT COUNT(*) FROM Likes WHERE postId = @postId";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@postId", postId);
                    int likeCount = (int)command.ExecuteScalar();

                    if(likeCount > 0)
                    {
                        label5.Text = $"Likes: {likeCount}";
                    }
                    else
                    {
                        label5.Text = $"Likes: 0";
                    }
                    
                }
            }
        }


        private void DisplayCurrentPost()
        {
            if (currentIndex >= 0 && currentIndex < postsImages.Count)
            {
                using (MemoryStream ms = new MemoryStream(postsImages[currentIndex]))
                {
                    pictureBox1.Image = Image.FromStream(ms);
                }
                label1.Text = postUsernames[currentIndex]; // Display username
                UpdateLikeCount(postIds[currentIndex]);
            }
            else
            {
                pictureBox1.Image = null;
                label1.Text = "No Posts Found";
                label5.Text = $"Likes: 0";
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (currentIndex > 0)
                currentIndex--;
            else
                currentIndex = postsImages.Count - 1;

            DisplayCurrentPost();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (currentIndex < postsImages.Count - 1)
                currentIndex++;
            else
                currentIndex = 0;

            DisplayCurrentPost();
        }

        // Implement the rest of your methods here

        // ... (rest of the methods unchanged)

        private void label5_Click(object sender, EventArgs e) { }
        private void button1_Click(object sender, EventArgs e) { }
        private void button2_Click(object sender, EventArgs e) { }
        private void button3_Click(object sender, EventArgs e) { }

        private void button3_Click_1(object sender, EventArgs e)
        {
            int postId = postIds[currentIndex];
            int currentUserId = SessionData.CurrentUser.Id;  // Ensure you have a mechanism to fetch the current user's ID.

            if (CheckIfLiked(postId, currentUserId))
            {
                UnlikePost(postId, currentUserId);
            }
            else
            {
                LikePost(postId, currentUserId);
            }

            UpdateLikeCount(postId);
        }

        private bool CheckIfLiked(int postId, int userId)
        {
            string query = "SELECT COUNT(*) FROM Likes WHERE postId = @postId AND userId = @userId";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@postId", postId);
                    command.Parameters.AddWithValue("@userId", userId);
                    int likeCount = (int)command.ExecuteScalar();
                    return likeCount > 0;
                }
            }
        }

        private void LikePost(int postId, int userId)
        {
            string insertQuery = "INSERT INTO Likes (postId, userId) VALUES (@postId, @userId)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@postId", postId);
                    command.Parameters.AddWithValue("@userId", userId);
                    command.ExecuteNonQuery();
                }
            }
        }

        private void UnlikePost(int postId, int userId)
        {
            string deleteQuery = "DELETE FROM Likes WHERE postId = @postId AND userId = @userId";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@postId", postId);
                    command.Parameters.AddWithValue("@userId", userId);
                    command.ExecuteNonQuery();
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

            TrendingOptions options = new TrendingOptions();
            options.Show();
            this.Close();

        }
    }
}