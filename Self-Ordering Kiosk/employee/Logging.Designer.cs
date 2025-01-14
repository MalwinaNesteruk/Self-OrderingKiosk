namespace Self_Ordering_Kiosk
{
    partial class Logging
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Logging));
            label1 = new Label();
            label3 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            label4 = new Label();
            button3 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 36F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(377, 75);
            label1.Name = "label1";
            label1.Size = new Size(319, 56);
            label1.TabIndex = 1;
            label1.Text = "LOGOWANIE";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 26.25F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(278, 222);
            label3.Name = "label3";
            label3.Size = new Size(126, 41);
            label3.TabIndex = 4;
            label3.Text = "LOGIN";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 26.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(268, 327);
            label2.Name = "label2";
            label2.Size = new Size(136, 41);
            label2.TabIndex = 5;
            label2.Text = "HASŁO";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Arial", 26.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.Location = new Point(456, 215);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(352, 48);
            textBox1.TabIndex = 6;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Arial", 26.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBox2.Location = new Point(456, 320);
            textBox2.Name = "textBox2";
            textBox2.PasswordChar = '*';
            textBox2.Size = new Size(352, 48);
            textBox2.TabIndex = 7;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // button1
            // 
            button1.BackColor = Color.Black;
            button1.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button1.ForeColor = SystemColors.ButtonHighlight;
            button1.Location = new Point(846, 578);
            button1.Name = "button1";
            button1.Size = new Size(235, 30);
            button1.TabIndex = 8;
            button1.Text = "Powrót do strony startowej";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Black;
            button2.Font = new Font("Arial", 21.75F, FontStyle.Bold, GraphicsUnit.Point);
            button2.ForeColor = SystemColors.ButtonHighlight;
            button2.Location = new Point(467, 439);
            button2.Name = "button2";
            button2.Size = new Size(200, 55);
            button2.TabIndex = 9;
            button2.Text = "ZALOGUJ";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label4
            // 
            label4.BackColor = Color.Black;
            label4.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.Red;
            label4.Location = new Point(418, 145);
            label4.Name = "label4";
            label4.Size = new Size(235, 44);
            label4.TabIndex = 10;
            label4.TextAlign = ContentAlignment.MiddleCenter;
            label4.Visible = false;
            // 
            // button3
            // 
            button3.BackgroundImage = (Image)resources.GetObject("button3.BackgroundImage");
            button3.BackgroundImageLayout = ImageLayout.Zoom;
            button3.Location = new Point(814, 320);
            button3.Name = "button3";
            button3.Size = new Size(48, 48);
            button3.TabIndex = 11;
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // Logging
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 255, 128);
            Controls.Add(button3);
            Controls.Add(label4);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(label1);
            Name = "Logging";
            Size = new Size(1084, 611);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label3;
        private Label label2;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button button1;
        private Button button2;
        private Label label4;
        private Button button3;
    }
}
