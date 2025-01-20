namespace Self_Ordering_Kiosk.employee
{
    partial class AddEmployee
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
            label7 = new Label();
            textBox2 = new TextBox();
            label4 = new Label();
            label2 = new Label();
            label3 = new Label();
            label1 = new Label();
            textBox1 = new TextBox();
            button2 = new Button();
            button1 = new Button();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            SuspendLayout();
            // 
            // label7
            // 
            label7.BackColor = Color.Black;
            label7.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = Color.Red;
            label7.Location = new Point(141, 100);
            label7.Name = "label7";
            label7.Size = new Size(790, 44);
            label7.TabIndex = 66;
            label7.TextAlign = ContentAlignment.MiddleCenter;
            label7.Visible = false;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Arial", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            textBox2.Location = new Point(387, 320);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(494, 32);
            textBox2.TabIndex = 61;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(114, 444);
            label4.Name = "label4";
            label4.Size = new Size(172, 24);
            label4.TabIndex = 58;
            label4.Text = "RODZAJ KONTA";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(164, 328);
            label2.Name = "label2";
            label2.Size = new Size(122, 24);
            label2.TabIndex = 57;
            label2.Text = "NAZWISKO";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(235, 214);
            label3.Name = "label3";
            label3.Size = new Size(51, 24);
            label3.TabIndex = 56;
            label3.Text = "IMIĘ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(28, 35);
            label1.Name = "label1";
            label1.Size = new Size(439, 37);
            label1.TabIndex = 55;
            label1.Text = "DODAWANIE PRACOWNIKA";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Arial", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.Location = new Point(387, 206);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(494, 32);
            textBox1.TabIndex = 54;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // button2
            // 
            button2.BackColor = Color.Black;
            button2.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button2.ForeColor = SystemColors.ButtonHighlight;
            button2.Location = new Point(957, 35);
            button2.Name = "button2";
            button2.Size = new Size(95, 30);
            button2.TabIndex = 52;
            button2.Text = "Wstecz";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.Black;
            button1.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button1.ForeColor = SystemColors.ButtonHighlight;
            button1.Location = new Point(878, 499);
            button1.Name = "button1";
            button1.Size = new Size(95, 30);
            button1.TabIndex = 51;
            button1.Text = "Zapisz";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            radioButton1.Location = new Point(387, 485);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(160, 23);
            radioButton1.TabIndex = 67;
            radioButton1.Text = "ADMINISTRATOR";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Checked = true;
            radioButton2.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            radioButton2.Location = new Point(387, 445);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(198, 23);
            radioButton2.TabIndex = 68;
            radioButton2.TabStop = true;
            radioButton2.Text = "ZWYKŁY PRACOWNIK";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // AddEmployee
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            Controls.Add(label7);
            Controls.Add(textBox2);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "AddEmployee";
            Size = new Size(1084, 611);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label7;
        private TextBox textBox2;
        private Label label4;
        private Label label2;
        private Label label3;
        private Label label1;
        private TextBox textBox1;
        private Button button2;
        private Button button1;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
    }
}
