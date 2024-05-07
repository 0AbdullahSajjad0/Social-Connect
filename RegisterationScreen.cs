using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class RegisterationScreen : Form
    {
        private string connectionString = "Data Source=DESKTOP-7KK116N\\SQLEXPRESS;Initial Catalog=SocialConnect;Integrated Security=True";

        public RegisterationScreen()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Navigate to the login screen
            LoginScreen loginForm = new LoginScreen();
            loginForm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string email = textBox2.Text;
            string username = textBox3.Text;
            string password = textBox4.Text;

            // SQL query to check if the username or email already exists
            string checkQuery = "SELECT COUNT(1) FROM Users WHERE username = @Username OR email = @Email";

            // SQL query to insert data
            string insertQuery = "INSERT INTO Users (name, email, username, password) VALUES (@Name, @Email, @Username, @Password)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Create a command for checking existing username or email
                using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                {
                    checkCommand.Parameters.AddWithValue("@Username", username);
                    checkCommand.Parameters.AddWithValue("@Email", email);

                    int exists = Convert.ToInt32(checkCommand.ExecuteScalar());

                    if (exists > 0)
                    {
                        MessageBox.Show("A user with the same username or email already exists. Please use a different username or email.");
                        return; // Stop further execution
                    }
                }

                // Create a command for inserting data
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        // Open the connection
                        conn.Open();

                        // Insert user details into the database
                        string iQuery = "INSERT INTO Users (Name, Email, Username, Password) VALUES (@Name, @Email, @Username, @Password)";
                        using (SqlCommand insertCommand = new SqlCommand(iQuery, conn))
                        {
                            insertCommand.Parameters.AddWithValue("@Name", name);
                            insertCommand.Parameters.AddWithValue("@Email", email);
                            insertCommand.Parameters.AddWithValue("@Username", username);
                            insertCommand.Parameters.AddWithValue("@Password", password);

                            int rowsAffected = insertCommand.ExecuteNonQuery();

                            // If rows were inserted, proceed with authentication
                            if (rowsAffected > 0)
                            {
                                string query = "SELECT Id, Username FROM Users WHERE Username = @Username AND Password = @Password";

                                using (SqlCommand command = new SqlCommand(query, conn))
                                {
                                    command.Parameters.AddWithValue("@Username", username);
                                    command.Parameters.AddWithValue("@Password", password);

                                    using (SqlDataReader reader = command.ExecuteReader())
                                    {
                                        if (reader.Read())
                                        {
                                            // Successfully found the user
                                            int userId = reader.GetInt32(reader.GetOrdinal("Id"));
                                            string uname = reader.GetString(reader.GetOrdinal("Username"));
                                            SessionData.CurrentUser = new User(userId, uname);

                                            // Navigate to the HomepageScreen
                                            this.Hide();
                                            HomepageScreen homepage = new HomepageScreen();
                                            homepage.Show();
                                        }
                                        else
                                        {
                                            MessageBox.Show("Invalid username or password. Please try again.");
                                        }
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Failed to register user.");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }

            }
        }


        private void RegisterationScreen_Load(object sender, EventArgs e)
        {

        }
    }
}
