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
using Microsoft.EntityFrameworkCore;

namespace Self_Ordering_Kiosk.employee
{
    public partial class ProductAdding : UserControl
    {
        public ProductAdding()
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;
                textBox3.Text = filePath;
                openFileDialog1.FileName = "";
            }
            else
            {
                openFileDialog1.Dispose();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty || textBox2.Text == string.Empty || textBox3.Text == string.Empty || textBox5.Text == string.Empty || comboBox1.Text == string.Empty)
            {
                label7.Text = "WSZYSTKIE POLA MUSZĄ BYĆ UZUPEŁNIONE";
                label7.Visible = true;
                return;
            }

            string pattern = @"^[0-9]{1,2},[0-9]{2}$";
            if (!Regex.IsMatch(textBox2.Text, pattern))
            {
                label7.Text = "W POLU 'CENA' NALEŻY WPISAĆ LICZBĘ ZGODNĄ ZE WZOREM: xx,xx";
                label7.Visible = true;
                return;
            }

            using (KioskContext db = new KioskContext())
            {
                string selectedText = comboBox1.Text;
                var selectedCategory = db.Categories.FirstOrDefault(x => x.Name == selectedText);

                var newProduct = new Product
                {
                    Name = textBox1.Text,
                    Price = decimal.Parse(textBox2.Text),
                    Picture = textBox3.Text,
                    Description = textBox5.Text,
                    Category = selectedCategory,
                };

                db.Products.Add(newProduct);

                if (checkBox1.Checked)
                {
                    db.SpecialOffers.Add(new SpecialOffer { Product = newProduct });
                }
                            
                db.SaveChanges();

                MessageBox.Show("Produkt został pomyślnie dodany!");
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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            label7.Visible = false;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            label7.Visible = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label7.Visible = false;
        }
    }
}
