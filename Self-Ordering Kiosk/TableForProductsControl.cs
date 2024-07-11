using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Self_Ordering_Kiosk
{
    public partial class TableForProductsControl : UserControl
    {
        public TableForProductsControl()
        {
            InitializeComponent();
        }

        public void SetLabel(string label)
        {
            label1.Text = label;
        }

        public void Clear()
        {
            tableLayoutPanel1.Controls.Clear();
        }

        public void SetOneProduct(List<ProductControl> productControl)
        {
            int i = 0;
            int j = 0;
            int counter = 0;

            foreach (ProductControl element in productControl) 
            {
                tableLayoutPanel1.Controls.Add(element, i, j);
                if (counter == 0)
                {
                    j++;
                    counter++;
                }
                else if (counter == 1) 
                {
                    i++;
                    j--;
                    counter--;
                }
            }
        }
    }
}
