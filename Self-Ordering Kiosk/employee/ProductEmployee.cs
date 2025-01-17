using Self_Ordering_Kiosk.db;
using Self_Ordering_Kiosk.db.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Self_Ordering_Kiosk.employee
{
    public partial class ProductEmployee : UserControl
    {
        public Product product;
        public int productId;
        public string category;
        public string productName;
        public decimal productPrice;
        public bool isSpecial;
        

        public ProductEmployee(Product product, bool isSpecial)
        {
            InitializeComponent();
            this.product = product;
            label1.Text = product.Name;
            label2.Text = product.Description;
            label4.Text = product.Price.ToString();
            pictureBox1.ImageLocation = product.Picture;
            checkBox1.Checked = isSpecial;

            productId = product.Id;
            category = product.Category.Name;
            productName = product.Name;
            productPrice = product.Price;
            this.isSpecial = isSpecial;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = (Form1)this.Parent.Parent.Parent.Parent.Parent.Parent;
            form.GoToProductModification(product, isSpecial);
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            using (KioskContext db = new KioskContext())
            {
                var productRemoved = db.Products.FirstOrDefault(x => x.Id == productId);

                var confirmResult = MessageBox.Show("Czy na pewno chcesz usunąć rekord?",
                                    "Potwierdzenie",
                                    MessageBoxButtons.YesNo);
                switch (confirmResult)
                {
                    case DialogResult.Yes:
                        var specialProduct = db.SpecialOffers.FirstOrDefault(x => x.Product.Id == productRemoved.Id);
                        if (specialProduct != null)
                        {
                            db.SpecialOffers.Remove(specialProduct);
                        }
                        db.Products.Remove(productRemoved);
                        db.SaveChanges();
                        var form = (MainScreenEmployee)Parent.Parent.Parent.Parent;
                        await form.RefreshDataAsync();
                        break;
                    case DialogResult.No:
                        break;
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                using (KioskContext db = new KioskContext())
                {
                    var specialProductAdded = db.Products.FirstOrDefault(x => x.Id == productId);
                    db.SpecialOffers.Add(new SpecialOffer { Product = specialProductAdded });
                    db.SaveChanges();
                }
            }
            else
            {
                using (KioskContext db = new KioskContext())
                {
                    var specialProductRemoved = db.Products.FirstOrDefault(x => x.Id == productId);
                    db.SpecialOffers.Remove(db.SpecialOffers.FirstOrDefault(x => x.Product.Id == specialProductRemoved.Id));
                    db.SaveChanges();
                }
            }
        }
    }
}
