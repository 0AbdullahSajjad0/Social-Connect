using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class SearchResults : Form
    {
        private string connectionString = "Data Source=DESKTOP-7KK116N\\SQLEXPRESS;Initial Catalog=SocialConnect;Integrated Security=True";

        public SearchResults()
        {
            InitializeComponent();
        }

        private void SearchResults_Load(object sender, EventArgs e)
        {
            // Display the name from the SearchClass in label2
            label2.Text = SearchClass.SearchIdName;

            // Load the profile image from the database based on the ID in SearchClass
            LoadProfileImage();
        }

        private void LoadProfileImage()
        {
            try
            {
                int userId = SearchClass.SearchId;

                // Query to retrieve the profile image from the database
                string query = "SELECT image FROM ProfilePicture WHERE UserId = @userId";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@userId", userId);

                        // Execute the query and read the image data
                        byte[] imageData = (byte[])command.ExecuteScalar();

                        // Check if image data is not null
                        if (imageData != null)
                        {
                            // Convert byte array to Image
                            using (MemoryStream ms = new MemoryStream(imageData))
                            {
                                pictureBox2.Image = Image.FromStream(ms);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading profile image: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Navigate to the next page (SearchResults2)
            SearchResults2 searchResults2 = new SearchResults2();
            searchResults2.Show();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Navigate back to the SearchUser page
            SearchUser searchUser = new SearchUser();
            searchUser.Show();
            this.Close();
        }
    }
}
