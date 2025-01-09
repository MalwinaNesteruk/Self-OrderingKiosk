using Self_Ordering_Kiosk.db.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Self_Ordering_Kiosk
{
    public partial class OneSummaryControl : UserControl
    {
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        Product product;
        int textToLabel;
        decimal priceToOne;

        public OneSummaryControl()
        {
            InitializeComponent();

        }
        
        public OneSummaryControl(string name, decimal price, int quantity, Product product)
        {
            InitializeComponent();
            this.Price = price;
            this.Quantity = quantity;
            this.product = product;
            priceToOne = this.product.Price;
            label1.Text = name;
            label2.Text = quantity.ToString();
            label3.Text = price.ToString();
            textToLabel = Int32.Parse(label2.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //minus
            Price = Convert.ToDecimal(label3.Text) - priceToOne;
            Quantity = Int32.Parse(label2.Text) - 1;
            
            if (Quantity == 0)
            {
                button1.Visible = false;
            }
            else if (Quantity == 98)
            {
                button2.Enabled = true;
            }

            textToLabel--;
            label2.Text = textToLabel.ToString();
            label3.Text = Price.ToString();

            if (Quantity == 0)
            {
                Cart.contentsOfCart.Remove(product);
            }
            else
            {
                Cart.contentsOfCart[product] = Quantity;
            }
            InvokeOrderValue();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Price = Convert.ToDecimal(label3.Text) + priceToOne;
            Quantity = Int32.Parse(label2.Text) + 1;

            if (Quantity == 1)
            {
                button1.Visible = true;
            }
            else if (Quantity == 99)
            {
                button2.Enabled = false;
            }

            textToLabel++;
            label2.Text = textToLabel.ToString();
            label3.Text = Price.ToString();

            if (!Cart.contentsOfCart.ContainsKey(product))
            {
                Cart.contentsOfCart.Add(product, Quantity);
            }
            else
            {
                Cart.contentsOfCart[product] = Quantity;
            }

            InvokeOrderValue();
        }

        private void InvokeOrderValue()
        {
            var summaryControl = (SummaryControl)Parent.Parent;
            summaryControl.UpdateOrderValueEvent();
        }
    }
}
