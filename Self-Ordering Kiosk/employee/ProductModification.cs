using Microsoft.EntityFrameworkCore;
using Self_Ordering_Kiosk.db;
using Self_Ordering_Kiosk.db.Model;
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
    public partial class productModification : UserControl
    {
        public Product product;
        public int productId;
        public string category;
        public string productName;
        public decimal productPrice;
        public string productPicture;
        public string productCategory;

        public productModification(Product product, bool isSpecjal)
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            this.product = product;
            textBox1.Text = product.Name;
            textBox2.Text = product.Price.ToString();
            textBox3.Text = product.Picture;
            textBox5.Text = product.Description;
            comboBox1.Text = product.Category.Name;
            checkBox1.Checked = isSpecjal;

            productId = product.Id;
            category = product.Category.Name;
            productName = product.Name;
            productPrice = product.Price;
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
            if (textBox1.Text == string.Empty || textBox2.Text == string.Empty || textBox5.Text == string.Empty)
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
                var product = db.Products.Include(a => a.Category).FirstOrDefault(x => x.Id == productId);
                string selectedText = comboBox1.Text;
                var selectedCategory = db.Categories.FirstOrDefault(x => x.Name == selectedText);
                product.Name = textBox1.Text;
                product.Price = decimal.Parse(textBox2.Text);
                product.Picture = textBox3.Text;
                product.Description = textBox5.Text;
                product.Category = selectedCategory;
                CheckedChanged();

                var confirmResult = MessageBox.Show("Czy na pewno chcesz zapisać zmiany?",
                            "Potwierdzenie",
                            MessageBoxButtons.YesNo);
                switch (confirmResult)
                {
                    case DialogResult.Yes:
                        db.SaveChanges();
                        var form = (Form1)this.Parent.Parent;
                        form.GoToMainScreenEmployee();
                        break;

                    case DialogResult.No:
                        break;
                }
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label7.Visible = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label7.Visible = false;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            label7.Visible = false;
        }

        public void CheckedChanged()
        {
            if (checkBox1.Checked)
            {
                using (KioskContext db = new KioskContext())
                {
                    var specialProductAdded = db.Products.FirstOrDefault(x => x.Id == productId);
                    if (db.SpecialOffers.FirstOrDefault(x => x.Product.Id == specialProductAdded.Id) == null)
                    {
                        db.SpecialOffers.Add(new SpecialOffer { Product = specialProductAdded });
                        db.SaveChanges();
                    }
                }
            }
            else
            {
                using (KioskContext db = new KioskContext())
                {
                    var specialProductRemoved = db.Products.FirstOrDefault(x => x.Id == productId);
                    if (db.SpecialOffers.FirstOrDefault(x => x.Product.Id == specialProductRemoved.Id) != null)
                    {
                        db.SpecialOffers.Remove(db.SpecialOffers.FirstOrDefault(x => x.Product.Id == specialProductRemoved.Id));
                        db.SaveChanges();
                    }
                }
            }
        }
    }
}