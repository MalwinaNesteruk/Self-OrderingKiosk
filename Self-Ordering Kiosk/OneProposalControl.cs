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
    public partial class OneProposalControl : UserControl
    {
        public OneProposalControl()
        {
            InitializeComponent();
        }

        public OneProposalControl(string name, decimal price)
        {
            InitializeComponent();
            label1.Text = name + Environment.NewLine + price;
        }
    }
}
