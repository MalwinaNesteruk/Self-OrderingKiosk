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
    public partial class ProposalControl : UserControl
    {
        public ProposalControl()
        {
            InitializeComponent();
        }
        public void SetOneProduct(List<OneProposalControl> productControl)
        {
            foreach (OneProposalControl element in productControl)
            {
                tableLayoutPanel1.Controls.Add(element);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = (Form1)this.Parent.Parent.Parent;
            form.GoToFourthScreen();
        }
    }
}
