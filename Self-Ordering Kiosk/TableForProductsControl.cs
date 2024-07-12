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
using System.Xml.Linq;

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
            tableLayoutPanel1.RowCount = 0;
            tableLayoutPanel1.RowStyles.Clear();
        }

        public void SetOneProduct(List<ProductControl> productControl)
        {
            tableLayoutPanel1.AutoScrollPosition = new Point(0, tableLayoutPanel1.VerticalScroll.Minimum);

            foreach (ProductControl element in productControl) 
            {
                tableLayoutPanel1.Controls.Add(element);
            }
        }
    }
}
