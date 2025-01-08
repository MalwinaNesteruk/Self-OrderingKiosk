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
using System.Xml.Linq;

namespace Self_Ordering_Kiosk
{
    public partial class SummaryControl : UserControl
    {
        decimal totalValue;
        public SummaryControl()
        {
            InitializeComponent();
            var summaryCartList = Cart.contentsOfCart.Select(x => new OneSummaryControl(x.Key.Name, x.Key.Price * x.Value, x.Value)).ToList();
            foreach (OneSummaryControl element in summaryCartList)
            {
                tableLayoutPanel1.Controls.Add(element);
                totalValue += element.Price;
            }
            label3.Text = totalValue.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = (Form1)this.Parent.Parent;
            form.GoToPaymentProcessingScreen();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form = (Form1)this.Parent.Parent;
            form.GoToThirdScreen();
        }
    }
}
