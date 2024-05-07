namespace WinFormsApp1
{
    partial class Profile
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
            button6 = new Button();
            label3 = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            button1 = new Button();
            label7 = new Label();
            checkBox1 = new CheckBox();
            button2 = new Button();
            label8 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // button6
            // 
            button6.BackColor = Color.DarkMagenta;
            button6.BackgroundImageLayout = ImageLayout.None;
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatStyle = FlatStyle.Popup;
            button6.ForeColor = Color.DarkOrange;
            button6.Location = new Point(12, 411);
            button6.Name = "button6";
            button6.Size = new Size(94, 29);
            button6.TabIndex = 39;
            button6.Text = "Back";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI Black", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.SeaShell;
            label3.Location = new Point(371, 21);
            label3.Name = "label3";
            label3.Padding = new Padding(0, 20, 20, 20);
            label3.Size = new Size(157, 94);
            label3.TabIndex = 34;
            label3.Text = "Social";
            label3.TextAlign = ContentAlignment.TopCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.SeaShell;
            label1.Location = new Point(492, 169);
            label1.Name = "label1";
            label1.Size = new Size(160, 28);
            label1.TabIndex = 33;
            label1.Text = "Abdullah Sajjad";
            label1.Click += label1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.BackgroundImageLayout = ImageLayout.None;
            pictureBox1.Image = Properties.Resources.handsome_young_man_with_arms_crossed_white_background;
            pictureBox1.Location = new Point(309, 169);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(168, 161);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 30;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.ForeColor = Color.SeaShell;
            label2.Location = new Point(492, 205);
            label2.Name = "label2";
            label2.RightToLeft = RightToLeft.No;
            label2.Size = new Size(72, 20);
            label2.TabIndex = 40;
            label2.Text = "Followers";
            label2.Click += label2_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.ForeColor = Color.SeaShell;
            label4.Location = new Point(621, 205);
            label4.Name = "label4";
            label4.Size = new Size(74, 20);
            label4.TabIndex = 41;
            label4.Text = "Following";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.ForeColor = Color.SeaShell;
            label5.Location = new Point(492, 236);
            label5.Name = "label5";
            label5.RightToLeft = RightToLeft.No;
            label5.Size = new Size(25, 20);
            label5.TabIndex = 42;
            label5.Text = "50";
            label5.Click += label5_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.ForeColor = Color.SeaShell;
            label6.Location = new Point(621, 236);
            label6.Name = "label6";
            label6.RightToLeft = RightToLeft.No;
            label6.Size = new Size(25, 20);
            label6.TabIndex = 43;
            label6.Text = "81";
            // 
            // button1
            // 
            button1.AutoSize = true;
            button1.BackColor = Color.DarkMagenta;
            button1.BackgroundImageLayout = ImageLayout.None;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button1.ForeColor = Color.DarkOrange;
            button1.Location = new Point(492, 298);
            button1.Name = "button1";
            button1.Size = new Size(149, 32);
            button1.TabIndex = 44;
            button1.Text = "Edit Profile Picture";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.ForeColor = Color.SeaShell;
            label7.Location = new Point(492, 265);
            label7.Name = "label7";
            label7.RightToLeft = RightToLeft.No;
            label7.Size = new Size(54, 20);
            label7.TabIndex = 45;
            label7.Text = "Private";
            label7.Click += label7_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.FlatStyle = FlatStyle.Flat;
            checkBox1.ForeColor = Color.Black;
            checkBox1.Location = new Point(633, 272);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(14, 13);
            checkBox1.TabIndex = 46;
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // button2
            // 
            button2.AutoSize = true;
            button2.BackColor = Color.DarkMagenta;
            button2.BackgroundImageLayout = ImageLayout.None;
            button2.FlatStyle = FlatStyle.Popup;
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button2.ForeColor = Color.DarkOrange;
            button2.Location = new Point(655, 298);
            button2.Name = "button2";
            button2.Size = new Size(98, 32);
            button2.TabIndex = 47;
            button2.Text = "View Posts";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Segoe UI Black", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label8.ForeColor = Color.DarkOrange;
            label8.Location = new Point(507, 21);
            label8.Name = "label8";
            label8.Padding = new Padding(0, 20, 20, 20);
            label8.Size = new Size(202, 94);
            label8.TabIndex = 48;
            label8.Text = "Connect";
            label8.TextAlign = ContentAlignment.TopCenter;
            // 
            // Profile
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Screenshot_2024_05_03_0903442;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(label8);
            Controls.Add(button2);
            Controls.Add(checkBox1);
            Controls.Add(label7);
            Controls.Add(button1);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(button6);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Name = "Profile";
            Text = "Profile";
            Load += Profile_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button6;
        private Label label3;
        private Label label1;
        private PictureBox pictureBox1;
        private Label label2;
        private Label label4;
        private Label label5;
        private Label label6;
        private Button button1;
        private Label label7;
        private CheckBox checkBox1;
        private Button button2;
        private Label label8;
    }
}