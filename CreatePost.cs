using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class CreatePost : Form
    {
        private string connectionString = "Data Source=DESKTOP-7KK116N\\SQLEXPRESS;Initial Catalog=SocialConnect;Integrated Security=True";
        private OpenFileDialog openFileDialog1;
        private Image selectedImage;
        private string selectedCategory;
        private string imagePath;  // Variable to store image path

        public CreatePost()
        {
            InitializeComponent();
            this.openFileDialog1 = new OpenFileDialog();

            // Initialize ComboBox
            comboBox1.Items.AddRange(new string[] { "Sports", "Food", "Clothing", "Entertainment", "Meme", "News" });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = false;  // Allow only single file selection
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                imagePath = openFileDialog1.FileName;  // Save the selected image path
                selectedImage = Image.FromFile(imagePath);
                pictureBox1.Image = selectedImage;  // Display the image
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                selectedCategory = comboBox1.SelectedItem.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (selectedImage == null)
            {
                MessageBox.Show("Please select an image for the post.");
                return;
            }

            if (string.IsNullOrEmpty(selectedCategory))
            {
                MessageBox.Show("Please select a category for the post.");
                return;
            }

            // Save the post to the database
            SavePostToDatabase();
        }


        private void button6_Click(object sender, EventArgs e)
        {
            HomepageScreen homepageScreen = new HomepageScreen();
            homepageScreen.Show();
            this.Close();
        }

        private void SavePostToDatabase()
        {
            byte[] imageData;
            using (var ms = new MemoryStream())
            {
                selectedImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                imageData = ms.ToArray();
            }

            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("INSERT INTO Posts (userId, image, trend, likes) VALUES (@userId, @image, @trend, 0)", connection);
                command.Parameters.AddWithValue("@userId", SessionData.CurrentUser.Id);
                command.Parameters.AddWithValue("@image", imageData);
                command.Parameters.AddWithValue("@trend", selectedCategory);

                connection.Open();
                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Post saved successfully!");
                    pictureBox1.Image = null;  // Clear the image display
                    selectedImage = null;  // Clear the selected image
                }
                else
                {
                    MessageBox.Show("Failed to save the post.");
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void CreatePost_Load(object sender, EventArgs e)
        {

        }
    }
}
