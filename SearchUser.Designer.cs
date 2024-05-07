namespace WinFormsApp1
{
    partial class SearchUser
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
            textBox1 = new TextBox();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            button4 = new Button();
            button6 = new Button();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI Black", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.SeaShell;
            label3.Location = new Point(243, 33);
            label3.Name = "label3";
            label3.Padding = new Padding(0, 20, 20, 20);
            label3.Size = new Size(157, 94);
            label3.TabIndex = 20;
            label3.Text = "Social";
            label3.TextAlign = ContentAlignment.TopCenter;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(270, 190);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(246, 27);
            textBox1.TabIndex = 21;
            // 
            // button4
            // 
            button4.BackColor = Color.DarkOrange;
            button4.BackgroundImageLayout = ImageLayout.None;
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Popup;
            button4.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button4.ForeColor = Color.DarkMagenta;
            button4.Location = new Point(344, 257);
            button4.Name = "button4";
            button4.Size = new Size(94, 29);
            button4.TabIndex = 22;
            button4.Text = "Search";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
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
            button6.TabIndex = 23;
            button6.Text = "Back";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.DarkMagenta;
            label1.Location = new Point(270, 167);
            label1.Name = "label1";
            label1.Size = new Size(91, 20);
            label1.TabIndex = 24;
            label1.Text = "Search User";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI Black", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.DarkMagenta;
            label2.Location = new Point(371, 33);
            label2.Name = "label2";
            label2.Padding = new Padding(0, 20, 20, 20);
            label2.Size = new Size(202, 94);
            label2.TabIndex = 25;
            label2.Text = "Connect";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // SearchUser
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Orange_and_purple__horizontal_;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button6);
            Controls.Add(button4);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Name = "SearchUser";
            Text = "SearchUser";
            Load += SearchUser_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label3;
        private TextBox textBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Button button4;
        private Button button6;
        private Label label1;
        private Label label2;
    }
}