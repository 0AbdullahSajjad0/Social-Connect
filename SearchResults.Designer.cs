namespace WinFormsApp1
{
    partial class SearchResults
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
            label2 = new Label();
            pictureBox2 = new PictureBox();
            button6 = new Button();
            button1 = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI Black", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.SeaShell;
            label3.Location = new Point(249, 9);
            label3.Name = "label3";
            label3.Padding = new Padding(0, 20, 20, 20);
            label3.Size = new Size(157, 94);
            label3.TabIndex = 24;
            label3.Text = "Social";
            label3.TextAlign = ContentAlignment.TopCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.DarkOrange;
            label2.Location = new Point(286, 103);
            label2.Name = "label2";
            label2.Size = new Size(117, 20);
            label2.TabIndex = 26;
            label2.Text = "Abdullah Sajjad";
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.BackgroundImageLayout = ImageLayout.None;
            pictureBox2.Location = new Point(300, 145);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(202, 208);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 25;
            pictureBox2.TabStop = false;
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
            button6.TabIndex = 29;
            button6.Text = "Back";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.DarkMagenta;
            button1.BackgroundImageLayout = ImageLayout.None;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Popup;
            button1.ForeColor = Color.DarkOrange;
            button1.Location = new Point(286, 374);
            button1.Name = "button1";
            button1.Size = new Size(108, 29);
            button1.TabIndex = 30;
            button1.Text = "View account";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Black", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.DarkOrange;
            label1.Location = new Point(375, 9);
            label1.Name = "label1";
            label1.Padding = new Padding(0, 20, 20, 20);
            label1.Size = new Size(202, 94);
            label1.TabIndex = 31;
            label1.Text = "Connect";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // SearchResults
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources._2768031;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(button6);
            Controls.Add(label2);
            Controls.Add(pictureBox2);
            Controls.Add(label3);
            Name = "SearchResults";
            Text = "SearchResults";
            Load += SearchResults_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label3;
        private Label label2;
        private PictureBox pictureBox2;
        private Button button6;
        private Button button1;
        private Label label1;
    }
}