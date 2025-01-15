using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Self_Ordering_Kiosk.employee
{
    public partial class TableForProductsEmployee : UserControl
    {
        public TableForProductsEmployee()
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

        public void SetOneProduct(List<ProductEmployee> productControl)
        {
            tableLayoutPanel1.AutoScrollPosition = new Point(0, tableLayoutPanel1.VerticalScroll.Minimum);
            foreach (ProductEmployee element in productControl)
            {
                tableLayoutPanel1.Controls.Add(element);
            }
        }
    }
}
