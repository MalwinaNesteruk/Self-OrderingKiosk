using Self_Ordering_Kiosk.db;
using Self_Ordering_Kiosk.db.Model;
using Self_Ordering_Kiosk.user;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Self_Ordering_Kiosk
{
    public partial class SummaryControl : UserControl
    {
        decimal totalValue;
        public SummaryControl()
        {
            InitializeComponent();
            var summaryCartList = Cart.contentsOfCart.Select(x => new OneSummaryControl(x.Key.Name, x.Key.Price * x.Value, x.Value, x.Key)).ToList();
            foreach (OneSummaryControl element in summaryCartList)
            {
                tableLayoutPanel1.Controls.Add(element);
                totalValue += element.Price;
            }
            label3.Text = totalValue.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using KioskContext db = new KioskContext();
            var order = new Order()
            {
                DateOfOrder = DateTime.Now,
                IsTakeaway = Cart.isTakeaway,
                OrderValue  = totalValue
            };
            db.Orders.Add(order);

            foreach (var product in Cart.contentsOfCart.Keys)
            {
                var productOrder = new ProductsOrders
                {
                    Product = db.Products.FirstOrDefault(a => a.Id == product.Id),
                    Order = order,
                    //IdProduct = product.Id,
                    //IdOrder = order.IdOrder,
                    Quantity = Cart.contentsOfCart[product]
                };

                db.ProductsOrders.Add(productOrder);
            }

            db.SaveChanges();
            var form = (Form1)this.Parent.Parent;
            form.GoToPaymentProcessingScreen();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form = (Form1)this.Parent.Parent;
            form.GoToThirdScreen();
        }

        public void UpdateOrderValueEvent()
        {
            if (Cart.contentsOfCart.Count == 0)
            {
                button1.Visible = false;
            }
            else
            {
                button1.Visible = true;
            }
            totalValue = Cart.contentsOfCart.Select(a => a.Key.Price * a.Value).Sum();
            label3.Text = totalValue.ToString();
        }
    }
}
