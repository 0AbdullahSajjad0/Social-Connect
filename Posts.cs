using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Posts : Form
    {
        private string connectionString = "Data Source=DESKTOP-7KK116N\\SQLEXPRESS;Initial Catalog=SocialConnect;Integrated Security=True";
        private List<byte[]> postsImages;
        private List<int> postIds;  // Store post IDs
        private int currentIndex = 0;

        public Posts()
        {
            InitializeComponent();
        }

        private void Posts_Load(object sender, EventArgs e)
        {
            label1.Text = SearchClass.SearchIdName;  // Display the username from SearchClass
            LoadPosts();
            DisplayCurrentPost();
        }

        private void LoadPosts()
        {
            postsImages = new List<byte[]>();
            postIds = new List<int>();
            int userId = SearchClass.SearchId;

            string query = "SELECT postId, image FROM Posts WHERE userId = @userId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            postIds.Add(reader.GetInt32(0));  // Correct column name
                            postsImages.Add((byte[])reader["image"]);
                        }
                    }
                }
            }
        }

        private void DisplayCurrentPost()
        {
            if (postsImages.Count > 0)
            {
                using (MemoryStream ms = new MemoryStream(postsImages[currentIndex]))
                {
                    pictureBox1.Image = Image.FromStream(ms);
                }
                UpdateLikeCount();
            }
            else
            {
                pictureBox1.Image = null;
                label2.Text = $"Likes: 0";
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // Left scroll
            if (currentIndex > 0)
                currentIndex--;
            else
                currentIndex = postsImages.Count - 1; // Wrap around to the last image

            DisplayCurrentPost();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            // Right scroll
            if (currentIndex < postsImages.Count - 1)
                currentIndex++;
            else
                currentIndex = 0; // Wrap around to the first image

            DisplayCurrentPost();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            // Toggle like or unlike for the current post
            int postId = postIds[currentIndex];
            ToggleLike(postId);
            UpdateLikeCount();
        }

        private void ToggleLike(int postId)
        {
            int userId = SessionData.CurrentUser.Id; // Assuming you have a current user session data class

            string checkLikeQuery = "SELECT COUNT(*) FROM Likes WHERE postId = @postId AND userId = @userId";
            string insertLikeQuery = "INSERT INTO Likes (postId, userId) VALUES (@postId, @userId)";
            string deleteLikeQuery = "DELETE FROM Likes WHERE postId = @postId AND userId = @userId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(checkLikeQuery, connection))
                {
                    command.Parameters.AddWithValue("@postId", postId);
                    command.Parameters.AddWithValue("@userId", userId);
                    int isLiked = (int)command.ExecuteScalar();

                    SqlCommand cmd = isLiked > 0
                        ? new SqlCommand(deleteLikeQuery, connection)
                        : new SqlCommand(insertLikeQuery, connection);

                    cmd.Parameters.AddWithValue("@postId", postId);
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void UpdateLikeCount()
        {
            int postId = postIds[currentIndex];
            string query = "SELECT COUNT(*) FROM Likes WHERE postId = @postId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@postId", postId);
                    int likeCount = (int)command.ExecuteScalar();


                    if (likeCount > 0)
                    {
                        label2.Text = $"Likes: {likeCount}";
                    }
                    else
                    {
                        label2.Text = $"Likes: 0";
                    }
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SearchResults2 searchResults2 = new SearchResults2();
            searchResults2.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
