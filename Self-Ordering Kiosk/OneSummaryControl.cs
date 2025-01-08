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
    public partial class OneSummaryControl : UserControl
    {
        public decimal Price { get; set; }

        public OneSummaryControl()
        {
            InitializeComponent();

        }

        public OneSummaryControl(string name, decimal price, int quantity)
        {
            InitializeComponent();
            this.Price = price;
            label1.Text = name;
            label2.Text = quantity.ToString();
            label3.Text = price.ToString();
        }
    }
}
