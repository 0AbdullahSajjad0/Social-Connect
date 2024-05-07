using System;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class TrendingOptions : Form
    {
        public TrendingOptions()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StoreAndNavigate("Sports");
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            StoreAndNavigate("Food");
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            StoreAndNavigate("Clothing");
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            StoreAndNavigate("Entertainment");
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            StoreAndNavigate("Memes");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            StoreAndNavigate("News");
        }

        private void StoreAndNavigate(string trend)
        {
            Trends.Trend = trend;
            TrendingResults trendingResults = new TrendingResults();
            trendingResults.Show();
            this.Close();
        }

        private void TrendingOptions_Load(object sender, EventArgs e)
        {
            // Additional initialization code if needed
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            StoreAndNavigate("Clothing");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            StoreAndNavigate("Entertainment");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            StoreAndNavigate("Memes");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            HomepageScreen loginForm = new HomepageScreen();
            loginForm.Show();
            this.Hide();
        }
    }
}
