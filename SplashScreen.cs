using System;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class SplashScreen : Form
    {
        // Timer instance
        private System.Windows.Forms.Timer splashTimer;

        public SplashScreen()
        {
            InitializeComponent();
            InitializeSplashTimer();
        }

        private void InitializeSplashTimer()
        {
            splashTimer = new System.Windows.Forms.Timer();
            splashTimer.Interval = 2500; // Set the timer for 2.5 seconds
            splashTimer.Tick += new EventHandler(SplashTimer_Tick);
            splashTimer.Start(); // Start the timer
        }

        private void SplashTimer_Tick(object? sender, EventArgs e)
        {
            splashTimer.Stop(); // Stop the timer to prevent it from triggering again

            // Assuming LoginScreen is the name of your login form
            LoginScreen loginForm = new LoginScreen();
            loginForm.Show();

            this.Hide(); // Optionally hide the splash screen, or close if you won't need it again
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Event handler content (if needed)
        }

        private void label2_Click(object sender, EventArgs e)
        {
            // Event handler content (if needed)
        }
    }
}
