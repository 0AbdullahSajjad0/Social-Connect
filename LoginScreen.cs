using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class LoginScreen : Form
    {
        // Connection string to the database
        private string connectionString = "Data Source=DESKTOP-7KK116N\\SQLEXPRESS;Initial Catalog=SocialConnect;Integrated Security=True";
        
        public LoginScreen()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Get the entered username and password
            string enteredUsername = textBox1.Text; // Change the variable name here
            string password = textBox2.Text;

            // Create a SQL query to check if the username and password exist in the database
            string query = "SELECT Id, Username FROM Users WHERE username=@Username AND password=@Password";

            // Create and open a connection to the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters to the query to prevent SQL injection
                    command.Parameters.AddWithValue("@Username", enteredUsername); // Change the variable name here
                    command.Parameters.AddWithValue("@Password", password);

                    try
                    {
                        // Open the connection
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        // If there is a record returned, set the logged-in user information
                        // Inside the login process after successful authentication
                        if (reader.Read())
                        {
                            // Set the logged-in user information in the SessionData class
                            int userId = reader.GetInt32(reader.GetOrdinal("Id"));
                            string username = reader.GetString(reader.GetOrdinal("Username"));
                            SessionData.CurrentUser = new User(userId, username);

                            // Close the reader
                            reader.Close();

                            // Close the current form
                            this.Hide();

                            // Open the HomepageScreen
                            HomepageScreen homepage = new HomepageScreen();
                            homepage.Show();
                        }

                        else
                        {
                            // If no record found, display an error message
                            MessageBox.Show("Invalid username or password. Please try again.");
                        }
                    }
                    catch (Exception ex)
                    {
                        // If an exception occurs, display the error message
                        MessageBox.Show("Error: " + ex.Message);
                    }
                    finally
                    {
                        // Close the connection if it's still open
                        if (connection.State == System.Data.ConnectionState.Open)
                            connection.Close();
                    }
                }
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            // If the "Sign Up" button is clicked, open the RegistrationScreen
            RegisterationScreen registrationForm = new RegisterationScreen();
            registrationForm.Show();
            this.Close();
        }
    }
}
