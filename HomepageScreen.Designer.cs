namespace WinFormsApp1
{
    partial class HomepageScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label3 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI Black", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.SeaShell;
            label3.Location = new Point(265, 9);
            label3.Name = "label3";
            label3.Padding = new Padding(0, 20, 20, 20);
            label3.Size = new Size(157, 94);
            label3.TabIndex = 6;
            label3.Text = "Social";
            label3.TextAlign = ContentAlignment.TopCenter;
            // 
            // button1
            // 
            button1.BackColor = Color.DarkOrange;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button1.ForeColor = Color.SeaShell;
            button1.Location = new Point(355, 131);
            button1.Name = "button1";
            button1.Size = new Size(103, 29);
            button1.TabIndex = 7;
            button1.Text = "Trending";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button2.ForeColor = Color.DarkOrange;
            button2.Location = new Point(355, 191);
            button2.Name = "button2";
            button2.Size = new Size(103, 29);
            button2.TabIndex = 8;
            button2.Text = "Search";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.DarkOrange;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button3.ForeColor = Color.SeaShell;
            button3.Location = new Point(355, 247);
            button3.Name = "button3";
            button3.Size = new Size(103, 29);
            button3.TabIndex = 9;
            button3.Text = "Notification";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button4.ForeColor = Color.DarkOrange;
            button4.Location = new Point(355, 310);
            button4.Name = "button4";
            button4.Size = new Size(103, 29);
            button4.TabIndex = 10;
            button4.Text = "Create Post";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.BackColor = Color.DarkOrange;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button5.ForeColor = Color.SeaShell;
            button5.Location = new Point(355, 370);
            button5.Name = "button5";
            button5.Size = new Size(103, 29);
            button5.TabIndex = 11;
            button5.Text = "Profile";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.BackColor = Color.DarkMagenta;
            button6.BackgroundImageLayout = ImageLayout.None;
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatStyle = FlatStyle.Popup;
            button6.ForeColor = Color.DarkOrange;
            button6.Location = new Point(12, 409);
            button6.Name = "button6";
            button6.Size = new Size(94, 29);
            button6.TabIndex = 17;
            button6.Text = "Logout";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Black", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.DarkOrange;
            label1.Location = new Point(391, 9);
            label1.Name = "label1";
            label1.Padding = new Padding(0, 20, 20, 20);
            label1.Size = new Size(202, 94);
            label1.TabIndex = 18;
            label1.Text = "Connect";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // HomepageScreen
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Screenshot_2024_05_03_094555;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label3);
            Name = "HomepageScreen";
            Text = "HomepageScreen";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label3;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Label label1;
    }
}