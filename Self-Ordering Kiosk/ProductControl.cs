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
    public partial class ProductControl : UserControl
    {
        public ProductControl()
        {
            InitializeComponent();
        }

        public void SetProduct(Product product)
        { 
            label1.Text = product.Name; 
            label2.Text = product.Description;
            label4.Text = product.Price.ToString();
            pictureBox1.ImageLocation = product.Picture;
        }
    }
}
