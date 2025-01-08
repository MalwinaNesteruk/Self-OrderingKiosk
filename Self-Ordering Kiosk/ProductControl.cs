using Self_Ordering_Kiosk.db.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Self_Ordering_Kiosk
{
    public partial class ProductControl : UserControl
    {
        public int counter = 0;
        int textToLabel = 1;
        public decimal productsPrice = 0;
        public int productId;
        public string category;
        public string productName;
        public decimal productPrice;
        Product product;

        public ProductControl(Product product)
        {
            InitializeComponent();
            this.product = product;
            label1.Text = product.Name;
            label2.Text = product.Description;
            label4.Text = product.Price.ToString();
            pictureBox1.ImageLocation = product.Picture;
            productId = product.Id;
            category = product.Category.Name;
            productName = product.Name;
            productPrice = product.Price;
        }
        
        public ProductControl(Product product, int quantity)
        {
            InitializeComponent();
            this.product = product;
            label1.Text = product.Name;
            label2.Text = product.Description;
            label4.Text = product.Price.ToString();
            pictureBox1.ImageLocation = product.Picture;
            productId = product.Id;
            category = product.Category.Name;
            productName = product.Name;
            productPrice = product.Price;

            counter = quantity;
            textToLabel = quantity;
            label5.Text = textToLabel.ToString();
            label5.Visible = true;
            button2.Visible = true;
        }

        public decimal ReturnPrice()
        { 
            return productsPrice; 
        }

        public int ReturnCounter()
        {
            return counter;
        }

        private void button1_Click(object sender, EventArgs e)
        {


            productsPrice += Convert.ToDecimal(label4.Text);
            counter++;
            if (counter == 1)
            {
                button2.Visible = true;
                label5.Visible = true;
            }
            else if (counter > 1 && counter < 99)
            {
                textToLabel++;
                label5.Text = textToLabel.ToString();
            }
            else if (counter == 99)
            {
                textToLabel++;
                label5.Text = textToLabel.ToString();
                button1.Enabled = false;
            }

            if (!Cart.contentsOfCart.ContainsKey(product))
            {
                Cart.contentsOfCart.Add(product, counter);
            }
            else
            {
                Cart.contentsOfCart[product] = counter;
            }

            InvokeCart();
        }

        private void InvokeCart()
        {
            var mainControl = (MainScreenControl)Parent.Parent.Parent.Parent;
            mainControl.UpdateCartEvent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            productsPrice -= Convert.ToDecimal(label4.Text);
            counter--;
            if (counter == 0)
            {
                button2.Visible = false;
                label5.Visible = false;
            }
            else if (counter > 0 && counter < 98)
            {
                textToLabel--;
                label5.Text = textToLabel.ToString();
            }
            else if (counter == 98)
            {
                button1.Enabled = true;
                textToLabel--;
                label5.Text = textToLabel.ToString();
            }

            if (counter == 0)
            {
                Cart.contentsOfCart.Remove(product);
            }
            else
            {
                Cart.contentsOfCart[product] = counter;
            }

            InvokeCart();
        }
    }
}
