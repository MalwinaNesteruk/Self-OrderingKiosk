using Self_Ordering_Kiosk.db.Model;
using Self_Ordering_Kiosk.db;
using Self_Ordering_Kiosk.user;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;

namespace Self_Ordering_Kiosk.employee
{
    public partial class MainScreenEmployee : UserControl
    {
        List<ProductEmployee> products = new List<ProductEmployee>();
        private Bookmark bookmark = Bookmark.HAMBURGERS;

        public MainScreenEmployee()
        {
            InitializeComponent();
            if (Logging.isAdmin == false)
            {
                dodajPracownikaToolStripMenuItem.Visible = false;
                usuńPracownikaToolStripMenuItem.Visible = false;
            }
        }

        public async Task LoadData()
        {
            using KioskContext db = new KioskContext();
            var productsFromDb = await db.Products.Include(a => a.Category).ToListAsync();
            foreach (var product in productsFromDb)
            {
                var isSpecial = db.SpecialOffers.Any(a => a.Product.Id == product.Id);
                ProductEmployee productControl = new ProductEmployee(product, isSpecial);
                products.Add(productControl);
            }

            tableForProductsEmployee1.SetLabel("Spróbuj najlepszych burgerów w mieście!");
            tableForProductsEmployee1.SetOneProduct(await InfoProduct("hamburgery"));

        }

        public async Task<List<ProductEmployee>> InfoProduct(string categoryName)
        {
            tableForProductsEmployee1.Clear();
            return products.Where(p => p.category.Equals(categoryName)).ToList();
        }

        private async void hamburgeryToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            tableForProductsEmployee1.Visible = true;
            bookmark = Bookmark.HAMBURGERS;
            hamburgeryToolStripMenuItem.BackColor = Color.FromArgb(255, 128, 0);
            dodatkiToolStripMenuItem.BackColor = SystemColors.ActiveCaption;
            napojeToolStripMenuItem.BackColor = SystemColors.ActiveCaption;
            panelToolStripMenuItem.BackColor = SystemColors.ActiveCaption;
            wylogowanieToolStripMenuItem.BackColor = SystemColors.ActiveCaption;
            tableForProductsEmployee1.SetLabel("Spróbuj najlepszych burgerów w mieście!");
            tableForProductsEmployee1.SetOneProduct(await InfoProduct("hamburgery"));
        }

        private async void dodatkiToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            tableForProductsEmployee1.Visible = true;
            bookmark = Bookmark.EXTRAS;
            hamburgeryToolStripMenuItem.BackColor = SystemColors.ActiveCaption;
            dodatkiToolStripMenuItem.BackColor = Color.FromArgb(255, 128, 0);
            napojeToolStripMenuItem.BackColor = SystemColors.ActiveCaption;
            panelToolStripMenuItem.BackColor = SystemColors.ActiveCaption;
            wylogowanieToolStripMenuItem.BackColor = SystemColors.ActiveCaption;
            tableForProductsEmployee1.SetLabel("Czym byłby burger bez frytek?! A może surówka do tego? :)");
            tableForProductsEmployee1.SetOneProduct(await InfoProduct("dodatki"));
        }

        private async void napojeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            tableForProductsEmployee1.Visible = true;
            bookmark = Bookmark.SODAS;
            hamburgeryToolStripMenuItem.BackColor = SystemColors.ActiveCaption;
            dodatkiToolStripMenuItem.BackColor = SystemColors.ActiveCaption;
            napojeToolStripMenuItem.BackColor = Color.FromArgb(255, 128, 0);
            panelToolStripMenuItem.BackColor = SystemColors.ActiveCaption;
            wylogowanieToolStripMenuItem.BackColor = SystemColors.ActiveCaption;
            tableForProductsEmployee1.SetLabel("Mamy szeroką ofertę napojów.");
            tableForProductsEmployee1.SetOneProduct(await InfoProduct("napoje"));
        }

        private void wylogowanieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = (Form1)this.Parent.Parent;
            form.GoToFirstScreen();
        }

        internal async Task RefreshDataAsync()
        {
            using KioskContext db = new KioskContext();
            products.Clear();
            var productsFromDb = await db.Products.Include(a => a.Category).ToListAsync();
            foreach (var product in productsFromDb)
            {
                var isSpecial = db.SpecialOffers.Any(a => a.Product.Id == product.Id);
                ProductEmployee productControl = new ProductEmployee(product, isSpecial);
                products.Add(productControl);
            }

            switch (bookmark)
            {
                case Bookmark.HAMBURGERS:
                    hamburgeryToolStripMenuItem_Click_1(null, null);
                    break;
                case Bookmark.EXTRAS:
                    dodatkiToolStripMenuItem_Click_1(null, null);
                    break;
                case Bookmark.SODAS:
                    napojeToolStripMenuItem_Click_1(null, null);
                    break;
                default:
                    break;
            }
        }

        private void dodajOfertęToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = (Form1)this.Parent.Parent;
            form.GoToProductAdding();
        }

        private void dodajPracownikaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = (Form1)this.Parent.Parent;
            form.GoToAddEmplyee();
        }

        private void zmieńHasłoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = (Form1)this.Parent.Parent;
            form.GoToChangePassword();
        }

        private void usuńPracownikaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = (Form1)this.Parent.Parent;
            form.GoToDeleteEmplyee();
        }
    }
}
