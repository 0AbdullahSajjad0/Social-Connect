using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class UserFeed : Form
    {
        private string connectionString = "Data Source=DESKTOP-7KK116N\\SQLEXPRESS;Initial Catalog=SocialConnect;Integrated Security=True";
        private int currentUserId; // Store the current user's ID
        private List<Post> userPosts; // Store the user's posts
        private int currentIndex = 0;

        public UserFeed()
        {
            InitializeComponent();
            DisplayCurrentUserName();
            currentUserId = SessionData.CurrentUser.Id; // Get the current user's ID
            userPosts = new List<Post>(); // Initialize the list of user's posts
            LoadUserPosts(); // Load the user's posts from the database
            DisplayCurrentPost();
        }

        private void LoadUserPosts()
        {
            string query = "SELECT postId, image FROM Posts WHERE userId = @userId";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@userId", currentUserId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int postId = (int)reader["postId"];
                                byte[] imageData = (byte[])reader["image"];
                                Image image;
                                using (var ms = new System.IO.MemoryStream(imageData))
                                {
                                    image = Image.FromStream(ms);
                                }
                                userPosts.Add(new Post { PostId = postId, Image = image }); // Add post to the list of user's posts
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading user posts: " + ex.Message);
                }
            }
        }

        private void DisplayCurrentPost()
        {
            if (userPosts.Count > 0)
            {
                pictureBox1.Image = userPosts[currentIndex].Image;
                UpdateLikesCount(); // Update the likes count for the current post
            }
            else
            {
                pictureBox1.Image = null; // Display nothing if there are no posts
                label2.Text = "0 likes";
            }
        }

        private void DisplayCurrentUserName()
        {
            if (SessionData.CurrentUser == null)
            {
                Console.WriteLine("No user is currently logged in.");
                return;
            }

            currentUserId = SessionData.CurrentUser.Id;

            // SQL query to retrieve the user's name based on their ID.
            string query = "SELECT name FROM Users WHERE id = @userId";

            // Using statement to handle the SQL connection and command.
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Parameterized query to prevent SQL injection.
                    cmd.Parameters.AddWithValue("@userId", currentUserId);

                    // Execute the query and retrieve the user's name.
                    string currentUserName = cmd.ExecuteScalar() as string; // Safely cast as string.

                    // Check if the result is not null or empty.
                    if (!string.IsNullOrEmpty(currentUserName))
                    {
                        label1.Text = currentUserName; // Assuming label1 is where you want to display the name.
                    }
                    else
                    {
                        Console.WriteLine("User not found.");
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e) // Previous Post
        {
            currentIndex--;
            if (currentIndex < 0)
            {
                // If currentIndex becomes less than 0, loop back to the last post
                currentIndex = userPosts.Count - 1;
            }
            DisplayCurrentPost();
        }

        private void button2_Click(object sender, EventArgs e) // Next Post
        {
            currentIndex++;
            if (currentIndex >= userPosts.Count)
            {
                // If currentIndex exceeds the number of posts, loop back to the first post
                currentIndex = 0;
            }
            DisplayCurrentPost();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Placeholder for any future implementation related to pictureBox1 click
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Profile profile = new Profile();
            profile.Show();
            this.Close();
        }

        // Event handlers for label2 and button3, to share like toggling functionality
        private void label2_Click(object sender, EventArgs e)
        {
            ToggleLike();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            ToggleLike();
        }

        private void ToggleLike()
        {
            if (userPosts.Count == 0) return; // No posts to like

            int postId = userPosts[currentIndex].PostId;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Check if the user already liked the current post
                    string checkQuery = "SELECT COUNT(*) FROM Likes WHERE postId = @postId AND userId = @userId";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@postId", postId);
                        checkCmd.Parameters.AddWithValue("@userId", currentUserId);
                        int likeCount = (int)checkCmd.ExecuteScalar();
                        if (likeCount > 0)
                        {
                            // User already liked the post, so unlike it
                            string unlikeQuery = "DELETE FROM Likes WHERE postId = @postId AND userId = @userId";
                            using (SqlCommand unlikeCmd = new SqlCommand(unlikeQuery, conn))
                            {
                                unlikeCmd.Parameters.AddWithValue("@postId", postId);
                                unlikeCmd.Parameters.AddWithValue("@userId", currentUserId);
                                unlikeCmd.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            // User hasn't liked the post yet, so like it
                            string likeQuery = "INSERT INTO Likes (userId, postId) VALUES (@userId, @postId)";
                            using (SqlCommand likeCmd = new SqlCommand(likeQuery, conn))
                            {
                                likeCmd.Parameters.AddWithValue("@userId", currentUserId);
                                likeCmd.Parameters.AddWithValue("@postId", postId);
                                likeCmd.ExecuteNonQuery();
                            }
                        }
                    }

                    // Refresh the likes count display after like/unlike
                    UpdateLikesCount();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error toggling like: " + ex.Message);
            }
        }

        private void UpdateLikesCount()
        {
            if (userPosts.Count == 0) return; // No posts to display

            int postId = userPosts[currentIndex].PostId;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM Likes WHERE postId = @postId";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@postId", postId);
                        int likesCount = (int)cmd.ExecuteScalar();

                        // If likesCount is zero, display '0 likes'
                        if (likesCount == 0)
                        {
                            label2.Text = "0 likes";
                        }
                        else
                        {
                            label2.Text = $"{likesCount} likes"; // Display like count with text
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating likes count: " + ex.Message);
            }
        }

        // Empty event handlers
        private void label1_Click(object sender, EventArgs e) { }
        private void button4_Click(object sender, EventArgs e) { }
        private void button3_Click(object sender, EventArgs e) { }
        private void UserFeed_Load(object sender, EventArgs e) { }
    }
}
