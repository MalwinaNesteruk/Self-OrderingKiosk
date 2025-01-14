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

namespace Self_Ordering_Kiosk
{
    public partial class OneProposalControl : UserControl
    {
        Product product;
        public OneProposalControl()
        {
            InitializeComponent();
        }

        public OneProposalControl(string name, decimal price, Product product)
        {
            InitializeComponent();
            this.product = product;
            button1.Text = name + Environment.NewLine + price;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cart.contentsOfCart.Add(product, 1);
            var form = (Form1)this.Parent.Parent.Parent.Parent.Parent;
            form.GoToFourthScreen();
        }
    }
}
