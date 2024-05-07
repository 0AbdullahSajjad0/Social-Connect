using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class HomepageScreen : Form
    {
        public HomepageScreen()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Notifications notifications = new Notifications();
            notifications.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            Profile profile = new Profile();
            profile.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SearchUser searchUser = new SearchUser();
            searchUser.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            LoginScreen loginScreen = new LoginScreen();
            loginScreen.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CreatePost createPost = new CreatePost();
            createPost.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TrendingOptions trendingOptions = new TrendingOptions();    
            trendingOptions.Show();
            this.Close();
        }
    }
}
