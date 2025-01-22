using Self_Ordering_Kiosk.db.Model;
using Self_Ordering_Kiosk.db;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using Self_Ordering_Kiosk.db.ModelEmployee;
using System.Security.Cryptography;

namespace Self_Ordering_Kiosk.employee
{
    public partial class AddEmployee : UserControl
    {
        public AddEmployee()
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
            if (textBox1.Text == string.Empty || textBox2.Text == string.Empty)
            {
                label7.Text = "WSZYSTKIE POLA MUSZĄ BYĆ UZUPEŁNIONE";
                label7.Visible = true;
                return;
            }

            string patternName = @"^[A-ZŁŚŻ]{1}[a-ząęśłżźćńó]+$";
            if (!Regex.IsMatch(textBox1.Text, patternName))
            {
                label7.Text = "W POLU 'IMIĘ' NALEŻY WPISAĆ SAME LITERY ZGODNIE ZE WZOREM: Xxxxxxxx";
                label7.Visible = true;
                return;
            }

            string patternSurname = @"^[A-ZŚŁŻŹĆ]{1}[a-ząęśłżźćńó]+$";
            if (!Regex.IsMatch(textBox2.Text, patternSurname))
            {
                label7.Text = "W POLU 'NAZWISKO' NALEŻY WPISAĆ SAME LITERY ZGODNIE ZE WZOREM: Xxxxxxxx";
                label7.Visible = true;
                return;
            }

            using (KioskContext db = new KioskContext())
            {
                string login = textBox2.Text.ToLower() + textBox1.Text.ToLower()[0];

                while (db.Employees.SingleOrDefault(x => x.Login == login) != null)
                {
                    if (Char.IsDigit(login[^1]))
                    {
                        int lastChar = int.Parse(login[^1].ToString()) + 1;
                        login = login.Remove(login.Length - 1);
                        login += lastChar;
                    }

                    if (Char.IsLetter(login[^1]))
                    {
                        login += 1;
                    }
                }

                string password = GeneratePassword();
                string hashPassword = HashPassword(password);

                var newEmployee = new Employee
                {
                    Name = textBox1.Text,
                    Surname = textBox2.Text,
                    Login = login,
                    Password = hashPassword,
                    IsAdmin = radioButton1.Checked ? true : false
                };

                db.Employees.Add(newEmployee);
                db.SaveChanges();

                MessageBox.Show("Dodano nowego pracownika o loginie: " + newEmployee.Login + " i haśle: " + password);
                var form = (Form1)this.Parent.Parent;
                form.GoToMainScreenEmployee();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label7.Visible = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label7.Visible = false;
        }

        private string GeneratePassword()
        {
            const string lowerCase = "abcdefghijklmnopqrstuvwxyz";
            const string upperCase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string digits = "0123456789";
            const string specialChars = "@#$%^&*()";
            const string allChars = lowerCase + upperCase + digits + specialChars;

            Random random = new Random();

            char[] password = new char[8];
            password[0] = lowerCase[random.Next(lowerCase.Length)];
            password[1] = upperCase[random.Next(upperCase.Length)];
            password[2] = digits[random.Next(digits.Length)];
            password[3] = specialChars[random.Next(specialChars.Length)];

            for (int i = 4; i < 8; i++)
            {
                password[i] = allChars[random.Next(allChars.Length)];
            }

            return new string(password.OrderBy(_ => random.Next()).ToArray());
        }

        private static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var passwordBytes = Encoding.UTF8.GetBytes(password);
                var hashBytes = sha256.ComputeHash(passwordBytes);

                return Convert.ToBase64String(hashBytes);
            }
        }
    }
}
