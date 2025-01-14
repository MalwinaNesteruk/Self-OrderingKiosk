using Self_Ordering_Kiosk.db;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Self_Ordering_Kiosk
{
    public partial class Logging : UserControl
    {
        bool flag = true;
        public Logging()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = (Form1)this.Parent.Parent;
            form.GoToFirstScreen();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty || textBox2.Text == string.Empty)
            {
                label4.Text = "POLA LOGIN I HASŁO NIE MOGĄ BYĆ PUSTE";
                label4.Visible = true;
            }
            else
            {
                string inputLogin = textBox1.Text.Trim();
                string inputPassword = textBox2.Text.Trim();

                using (KioskContext db = new KioskContext())
                {
                    string hashedPassword = HashPassword(inputPassword);
                    var employee = db.Employees.SingleOrDefault(x => x.Login == inputLogin && x.Password == hashedPassword);
                    if (employee == null)
                    {
                        textBox1.Text = string.Empty;
                        textBox2.Text = string.Empty;
                        label4.Text = "BŁĘDNE DANE" + Environment.NewLine + "SPRÓBUJ JESZCZE RAZ";
                        label4.Visible = true;
                    }
                    else
                    {
                        var form = (Form1)this.Parent.Parent;
                        form.GoToMainScreenEmployee();
                    }
                }
            }
        }

        private string HashPassword(string password)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label4.Visible = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label4.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (flag == false)
            {
                textBox2.PasswordChar = '*';
                button3.BackgroundImage = Image.FromFile("C:\\Users\\Malwina\\source\\repos\\Self-Ordering Kiosk\\oko2.png");
                flag = true;
            }

            else
            {
                textBox2.PasswordChar = '\0';
                button3.BackgroundImage = Image.FromFile("C:\\Users\\Malwina\\source\\repos\\Self-Ordering Kiosk\\oko.png");
                flag = false;
            }
            button3.BackgroundImageLayout = ImageLayout.Zoom;
        }
    }
}
