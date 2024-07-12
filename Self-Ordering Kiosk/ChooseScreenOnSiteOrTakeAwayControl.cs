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
    public partial class ChooseScreenOnSiteOrTakeAwayControl : UserControl
    {
        public ChooseScreenOnSiteOrTakeAwayControl()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var form = (Form1)this.Parent.Parent;
            await form.GoToThirdScreen();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            var form = (Form1)this.Parent.Parent;
            await form.GoToThirdScreen();
        }
    }
}