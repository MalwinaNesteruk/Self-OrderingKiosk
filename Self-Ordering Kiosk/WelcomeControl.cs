using Microsoft.EntityFrameworkCore;
using Self_Ordering_Kiosk.db;
using Self_Ordering_Kiosk.db.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.AccessControl;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Self_Ordering_Kiosk
{
    public partial class WelcomeControl : UserControl
    {
        public WelcomeControl()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = (Form1)this.Parent.Parent;
            form.GoToSecondScreen();
        }

        private void WelcomeControl_Load(object sender, EventArgs e)
        {

        }

       /* private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using KioskContext db = new KioskContext();

                ////najtańszy burger
                //var firstProduct = db.Products.Where(x => x.Type == 1).OrderBy(x => x.Price).First();

                ////najdroższy dodatek
                //var firstProduct2 = db.Products.Where(x => x.Type == 2).OrderByDescending(x => x.Price).First();

                ////burgery z bułką pszenną pow. 24 zł!!!!!!!!!!!!!!!!!!
                //var firstProduct3 = db.Products.Where(x => x.Description.Contains("bułka pszenna") && x.Price > 24).ToList();

                ////średnia cena burgera
                //var firstProduct4 = db.Products.Where(x => x.Type == 1).Average(x => x.Price);

                ////ile jest wszystkich burgerów
                //var firstProduct5 = db.Products.Where(x => x.Type == 1).Count();

                ////jakie są lemoniady
                //var firstProduct6 = db.Products.Where(x => x.Name.StartsWith("Lemoniada")).Select(x => x.Name).ToList();

                ////jakie są lemoniady
                //var firstProduct7 = db.Products.Where(x => x.Name.StartsWith("Lemoniada")).Select(x => x.Name).ToList();

                ////ile jest burgerów, ile dodatków, ile napojów
                //var firstProduct8 = db.Products.GroupBy(x => x.Type).Select(g => new { category = g.Key, result = g.Count() }).ToList();

                ////nazwa, cena i typ jako nazwa kategorii, gdzie cena między 10 a 25
                //var firstProduct9 = db.Products.Join(db.Categories, product => product.Type, category => category.Id, (product, category) => new { product, category })
                //    .Where(x => x.product.Price > 10 && x.product.Price < 25).Select(g => new { name = g.product.Name, price = g.product.Price, category = g.category.Name }).ToList();

                var tdsada = db.Products.Include(a => a.Category).FirstOrDefault();
                  
                             
                 productControl1.SetProduct(tdsada);
                
            }
            catch (Exception ex)
            {
                var sdasda = ex.Message;
            }


        }*/
    }
}
