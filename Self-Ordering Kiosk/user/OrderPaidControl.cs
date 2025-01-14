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
    public partial class OrderPaidControl : UserControl
    {
        int timeToNextScreen = 3;
        public OrderPaidControl()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timeToNextScreen--;
            if (timeToNextScreen == 0)
            {
                timer1.Stop();
                var form = (Form1)this.Parent.Parent;
                form.GoToFirstScreen();
            }
        }
    }
}
