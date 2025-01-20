namespace Self_Ordering_Kiosk.employee
{
    partial class ProductAdding
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
            button3 = new Button();
            comboBox1 = new ComboBox();
            textBox5 = new TextBox();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label2 = new Label();
            label3 = new Label();
            label1 = new Label();
            textBox1 = new TextBox();
            checkBox1 = new CheckBox();
            button2 = new Button();
            button1 = new Button();
            openFileDialog1 = new OpenFileDialog();
            SuspendLayout();
            // 
            // label7
            // 
            label7.BackColor = Color.Black;
            label7.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = Color.Red;
            label7.Location = new Point(143, 68);
            label7.Name = "label7";
            label7.Size = new Size(790, 44);
            label7.TabIndex = 50;
            label7.TextAlign = ContentAlignment.MiddleCenter;
            label7.Visible = false;
            // 
            // button3
            // 
            button3.BackColor = Color.Black;
            button3.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button3.ForeColor = SystemColors.ButtonHighlight;
            button3.Location = new Point(753, 288);
            button3.Name = "button3";
            button3.Size = new Size(147, 30);
            button3.TabIndex = 49;
            button3.Text = "Wybierz z pliku";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Font = new Font("Arial", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "hamburgery", "dodatki", "napoje" });
            comboBox1.Location = new Point(253, 365);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(149, 32);
            comboBox1.TabIndex = 48;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // textBox5
            // 
            textBox5.Font = new Font("Arial", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            textBox5.Location = new Point(253, 450);
            textBox5.Multiline = true;
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(494, 108);
            textBox5.TabIndex = 47;
            textBox5.TextChanged += textBox5_TextChanged;
            // 
            // textBox3
            // 
            textBox3.Enabled = false;
            textBox3.Font = new Font("Arial", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            textBox3.Location = new Point(253, 288);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(494, 32);
            textBox3.TabIndex = 46;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Arial", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            textBox2.Location = new Point(253, 206);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(494, 32);
            textBox2.TabIndex = 45;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(143, 450);
            label6.Name = "label6";
            label6.Size = new Size(59, 24);
            label6.TabIndex = 44;
            label6.Text = "OPIS";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(70, 369);
            label5.Name = "label5";
            label5.Size = new Size(132, 24);
            label5.TabIndex = 43;
            label5.Text = "KATEGORIA";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(94, 296);
            label4.Name = "label4";
            label4.Size = new Size(108, 24);
            label4.TabIndex = 42;
            label4.Text = "RYSUNEK";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(134, 214);
            label2.Name = "label2";
            label2.Size = new Size(68, 24);
            label2.TabIndex = 41;
            label2.Text = "CENA";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(116, 133);
            label3.Name = "label3";
            label3.Size = new Size(86, 24);
            label3.TabIndex = 40;
            label3.Text = "NAZWA";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(30, 31);
            label1.Name = "label1";
            label1.Size = new Size(396, 37);
            label1.TabIndex = 39;
            label1.Text = "DODAWANIE PRODUKTU";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Arial", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.Location = new Point(253, 125);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(494, 32);
            textBox1.TabIndex = 38;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            checkBox1.Location = new Point(556, 374);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(151, 23);
            checkBox1.TabIndex = 37;
            checkBox1.Text = "Oferta specjalna";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.BackColor = Color.Black;
            button2.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button2.ForeColor = SystemColors.ButtonHighlight;
            button2.Location = new Point(959, 31);
            button2.Name = "button2";
            button2.Size = new Size(95, 30);
            button2.TabIndex = 36;
            button2.Text = "Wstecz";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.Black;
            button1.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button1.ForeColor = SystemColors.ButtonHighlight;
            button1.Location = new Point(880, 495);
            button1.Name = "button1";
            button1.Size = new Size(95, 30);
            button1.TabIndex = 35;
            button1.Text = "Zapisz";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // ProductAdding
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label7);
            Controls.Add(button3);
            Controls.Add(comboBox1);
            Controls.Add(textBox5);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(checkBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "ProductAdding";
            Size = new Size(1084, 611);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label7;
        private Button button3;
        private ComboBox comboBox1;
        private TextBox textBox5;
        private TextBox textBox3;
        private TextBox textBox2;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label2;
        private Label label3;
        private Label label1;
        private TextBox textBox1;
        private CheckBox checkBox1;
        private Button button2;
        private Button button1;
        private OpenFileDialog openFileDialog1;
    }
}
