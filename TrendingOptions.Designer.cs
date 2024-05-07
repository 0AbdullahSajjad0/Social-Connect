namespace WinFormsApp1
{
    partial class TrendingOptions
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
            button5 = new Button();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            label3 = new Label();
            button7 = new Button();
            label1 = new Label();
            SuspendLayout();
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
            button6.TabIndex = 24;
            button6.Text = "Back";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // button5
            // 
            button5.BackColor = Color.DarkOrange;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button5.ForeColor = Color.SeaShell;
            button5.Location = new Point(347, 334);
            button5.Name = "button5";
            button5.Size = new Size(112, 29);
            button5.TabIndex = 23;
            button5.Text = "Memes";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // button4
            // 
            button4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button4.ForeColor = Color.DarkOrange;
            button4.Location = new Point(347, 274);
            button4.Name = "button4";
            button4.Size = new Size(112, 29);
            button4.TabIndex = 22;
            button4.Text = "Entertainment";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.DarkOrange;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button3.ForeColor = Color.SeaShell;
            button3.Location = new Point(347, 215);
            button3.Name = "button3";
            button3.Size = new Size(112, 29);
            button3.TabIndex = 21;
            button3.Text = "Clothing";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button2.ForeColor = Color.DarkOrange;
            button2.Location = new Point(347, 155);
            button2.Name = "button2";
            button2.Size = new Size(112, 29);
            button2.TabIndex = 20;
            button2.Text = "Food";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click_1;
            // 
            // button1
            // 
            button1.BackColor = Color.DarkOrange;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button1.ForeColor = Color.SeaShell;
            button1.Location = new Point(347, 95);
            button1.Name = "button1";
            button1.Size = new Size(112, 29);
            button1.TabIndex = 19;
            button1.Text = "Sports";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI Black", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.SeaShell;
            label3.Location = new Point(266, -2);
            label3.Name = "label3";
            label3.Padding = new Padding(0, 20, 20, 20);
            label3.Size = new Size(157, 94);
            label3.TabIndex = 18;
            label3.Text = "Social";
            label3.TextAlign = ContentAlignment.TopCenter;
            // 
            // button7
            // 
            button7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button7.ForeColor = Color.DarkOrange;
            button7.Location = new Point(347, 388);
            button7.Name = "button7";
            button7.Size = new Size(112, 29);
            button7.TabIndex = 25;
            button7.Text = "News";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Black", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.DarkOrange;
            label1.Location = new Point(397, -2);
            label1.Name = "label1";
            label1.Padding = new Padding(0, 20, 20, 20);
            label1.Size = new Size(202, 94);
            label1.TabIndex = 26;
            label1.Text = "Connect";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // TrendingOptions
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Screenshot_2024_05_03_094555;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label3);
            ForeColor = SystemColors.ControlText;
            Name = "TrendingOptions";
            Text = "TrendingOptions";
            Load += TrendingOptions_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button6;
        private Button button5;
        private Button button4;
        private Button button3;
        private Button button2;
        private Button button1;
        private Label label3;
        private Button button7;
        private Label label1;
    }
}