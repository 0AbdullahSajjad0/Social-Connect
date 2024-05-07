using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class SearchUser : Form
    {
        private string connectionString = "Data Source=DESKTOP-7KK116N\\SQLEXPRESS;Initial Catalog=SocialConnect;Integrated Security=True";

        public SearchUser()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string searchUserName = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(searchUserName))
            {
                MessageBox.Show("Please enter a username to search.");
                return;
            }

            SearchUserByUsername(searchUserName);
        }

        private void SearchUserByUsername(string username)
        {
            string query = "SELECT id, name FROM Users WHERE username = @username";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            int userId = reader.GetInt32(0);
                            string name = reader.GetString(1);

                            // Store search results in SearchClass
                            SearchClass.SearchId = userId;
                            SearchClass.SearchIdName = name;

                            // Open the search results form
                            SearchResults searchResults = new SearchResults();
                            searchResults.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("No user found with the provided username.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error searching for user: " + ex.Message);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Clear the SearchClass data before leaving the page
            SearchClass.SearchId = 0;        // Resetting the ID to default value
            SearchClass.SearchIdName = null; // Resetting the Name to null

            // Navigate to HomepageScreen
            HomepageScreen homepageScreen = new HomepageScreen();
            homepageScreen.Show();
            this.Close();
        }


        private void SearchUser_Load(object sender, EventArgs e)
        {

        }
    }
}
