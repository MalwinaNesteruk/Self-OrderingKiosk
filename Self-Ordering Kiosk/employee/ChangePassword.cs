using Self_Ordering_Kiosk.db;
using Self_Ordering_Kiosk.db.ModelEmployee;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Self_Ordering_Kiosk.employee
{
    public partial class ChangePassword : UserControl
    {
        bool passwordIsInvisibleButton3 = true;
        bool passwordIsInvisibleButton4 = true;
        bool passwordIsInvisibleButton5 = true;
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Czy na pewno chcesz wyjść?",
                        "Potwierdzenie",
                        MessageBoxButtons.YesNo);
            switch (confirmResult)
            {
                case DialogResult.Yes:
                    var form = (Form1)this.Parent.Parent;
                    form.GoToMainScreenEmployee();
                    break;

                case DialogResult.No:
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty || textBox2.Text == string.Empty || textBox3.Text == string.Empty)
            {
                label7.Text = "WSZYSTKIE POLA MUSZĄ BYĆ UZUPEŁNIONE";
                label7.Visible = true;
                return;
            }

            using (KioskContext db = new KioskContext())
            {
                var employee = db.Employees.SingleOrDefault(x => x.Login == Logging.login && x.Password == HashPassword(textBox1.Text));
                if (employee == null)
                {
                    textBox1.Text = string.Empty;
                    label7.Text = "BŁĘDNE DANE W POLU 'STARE HASŁO'. WPISZ JE PONOWNIE.";
                    return;
                }

                if (textBox2.Text.Equals(textBox1.Text))
                {
                    textBox2.Text = string.Empty;
                    label7.Text = "POLA 'STARE HASŁO' i 'NOWE HASŁO' NIE MOGĄ ZAWIERAĆ TEGO SAMEGO TEKSTU.";
                    return;
                }

                string passwordPattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#\$%\^&\*\(\)])[A-Za-z\d!@#\$%\^&\*\(\)]{8,}$";
                if (!Regex.IsMatch(textBox2.Text, passwordPattern))
                {
                    textBox2.Text = string.Empty;
                    label7.Text = "BŁĘDNE DANE W POLU 'NOWE HASŁO'. HASŁO MUSI SIĘ ZAWIERAĆ MINIMUM: 8 ZNAKÓW, 1 MAŁĄ LITERĘ, 1 DUŻĄ LITERĘ, 1 CYFRĘ i 1 ZNAK: !@#$%^&*()";
                    return;
                }

                if (!textBox3.Text.Equals(textBox2.Text))
                {
                    textBox2.Text = string.Empty;
                    textBox3.Text = string.Empty;
                    label7.Text = "POLA 'NOWE HASŁO' i 'POWTÓRZ NOWE HASŁO' MUSZĄ ZAWIERAĆ TEN SAM TEKST.";
                    return;
                }

                employee.Password = HashPassword(textBox2.Text);

                var confirmResult = MessageBox.Show("Czy na pewno chcesz zapisać zmiany?",
                            "Potwierdzenie",
                            MessageBoxButtons.YesNo);
                switch (confirmResult)
                {
                    case DialogResult.Yes:
                        db.SaveChanges();
                        var form = (Form1)this.Parent.Parent;
                        form.GoToFirstScreen();
                        break;

                    case DialogResult.No:
                        break;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (passwordIsInvisibleButton3 == false)
            {
                textBox1.PasswordChar = '*';
                button3.BackgroundImage = Image.FromFile("C:\\Users\\Malwina\\source\\repos\\Self-Ordering Kiosk\\oko2.png");
                passwordIsInvisibleButton3 = true;
            }

            else
            {
                textBox1.PasswordChar = '\0';
                button3.BackgroundImage = Image.FromFile("C:\\Users\\Malwina\\source\\repos\\Self-Ordering Kiosk\\oko.png");
                passwordIsInvisibleButton3 = false;
            }
            button3.BackgroundImageLayout = ImageLayout.Zoom;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (passwordIsInvisibleButton4 == false)
            {
                textBox2.PasswordChar = '*';
                button4.BackgroundImage = Image.FromFile("C:\\Users\\Malwina\\source\\repos\\Self-Ordering Kiosk\\oko2.png");
                passwordIsInvisibleButton4 = true;
            }

            else
            {
                textBox2.PasswordChar = '\0';
                button4.BackgroundImage = Image.FromFile("C:\\Users\\Malwina\\source\\repos\\Self-Ordering Kiosk\\oko.png");
                passwordIsInvisibleButton4 = false;
            }
            button3.BackgroundImageLayout = ImageLayout.Zoom;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (passwordIsInvisibleButton5 == false)
            {
                textBox3.PasswordChar = '*';
                button5.BackgroundImage = Image.FromFile("C:\\Users\\Malwina\\source\\repos\\Self-Ordering Kiosk\\oko2.png");
                passwordIsInvisibleButton5 = true;
            }

            else
            {
                textBox3.PasswordChar = '\0';
                button5.BackgroundImage = Image.FromFile("C:\\Users\\Malwina\\source\\repos\\Self-Ordering Kiosk\\oko.png");
                passwordIsInvisibleButton5 = false;
            }
            button3.BackgroundImageLayout = ImageLayout.Zoom;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label7.Text = "Pamiętaj! Po zmianie hasła zostaniesz wylogowany!";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label7.Text = "Pamiętaj! Po zmianie hasła zostaniesz wylogowany!";
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            label7.Text = "Pamiętaj! Po zmianie hasła zostaniesz wylogowany!";
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
    }
}
