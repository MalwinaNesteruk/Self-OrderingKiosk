using Microsoft.EntityFrameworkCore;
using Self_Ordering_Kiosk.db;
using System.Data;

namespace Self_Ordering_Kiosk
{
    public partial class MainScreenControl : UserControl
    {
        public MainScreenControl()
        {
            InitializeComponent();
        }

        public async Task LoadData()
        {
            tableForProductsControl1.SetOneProduct(await InfoSpecialProduct());
        }

        public async Task<List<ProductControl>> InfoProduct(string categoryName)
        {
            using KioskContext db = new KioskContext();
            tableForProductsControl1.Clear();
            var allProductsInCategory = await db.Products.Include(a => a.Category).Where(x => x.Category.Name.Equals(categoryName)).ToListAsync();
            List<ProductControl> products = new List<ProductControl>();
            foreach (var product in allProductsInCategory)
            {
                ProductControl productControl = new ProductControl();
                productControl.SetProduct(product);
                products.Add(productControl);
            }
            return products;
        }

        public async Task<List<ProductControl>> InfoSpecialProduct()
        {
            using KioskContext db = new KioskContext();
            tableForProductsControl1.Clear();
            var allProductsInCategory = await db.SpecialOffers.Include(a => a.Product).ToListAsync();
            List<ProductControl> products = new List<ProductControl>();
            foreach (var product in allProductsInCategory)
            {
                ProductControl productControl = new ProductControl();
                productControl.SetProduct(product.Product);
                products.Add(productControl);
            }
            return products;
        }

        private async void ofertySpecjalneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ofertySpecjalneToolStripMenuItem.BackColor = Color.FromArgb(255, 128, 0);
            hamburgeryToolStripMenuItem.BackColor = SystemColors.ActiveCaption;
            dodatkiToolStripMenuItem.BackColor = SystemColors.ActiveCaption;
            napojeToolStripMenuItem.BackColor = SystemColors.ActiveCaption;
            koszykToolStripMenuItem.BackColor = SystemColors.ActiveCaption;
            tableForProductsControl1.SetLabel("Zapraszamy do zapoznania się z naszą ofertą sezonową.");
            tableForProductsControl1.SetOneProduct(await InfoSpecialProduct());
        }

        private async void hamburgeryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ofertySpecjalneToolStripMenuItem.BackColor = SystemColors.ActiveCaption;
            hamburgeryToolStripMenuItem.BackColor = Color.FromArgb(255, 128, 0);
            dodatkiToolStripMenuItem.BackColor = SystemColors.ActiveCaption;
            napojeToolStripMenuItem.BackColor = SystemColors.ActiveCaption;
            koszykToolStripMenuItem.BackColor = SystemColors.ActiveCaption;
            tableForProductsControl1.SetLabel("Spróbuj najlepszych burgerów w mieście!");
            tableForProductsControl1.SetOneProduct(await InfoProduct("hamburgery"));
        }

        private async void dodatkiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ofertySpecjalneToolStripMenuItem.BackColor = SystemColors.ActiveCaption;
            hamburgeryToolStripMenuItem.BackColor = SystemColors.ActiveCaption;
            dodatkiToolStripMenuItem.BackColor = Color.FromArgb(255, 128, 0);
            napojeToolStripMenuItem.BackColor = SystemColors.ActiveCaption;
            koszykToolStripMenuItem.BackColor = SystemColors.ActiveCaption;
            tableForProductsControl1.SetLabel("Czym byłby burger bez frytek?! A może surówka do tego? :)");
            tableForProductsControl1.SetOneProduct(await InfoProduct("dodatki"));
        }

        private async void napojeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ofertySpecjalneToolStripMenuItem.BackColor = SystemColors.ActiveCaption;
            hamburgeryToolStripMenuItem.BackColor = SystemColors.ActiveCaption;
            dodatkiToolStripMenuItem.BackColor = SystemColors.ActiveCaption;
            napojeToolStripMenuItem.BackColor = Color.FromArgb(255, 128, 0);
            koszykToolStripMenuItem.BackColor = SystemColors.ActiveCaption;
            tableForProductsControl1.SetLabel("Mamy szeroką ofertę napojów.");
            tableForProductsControl1.SetOneProduct(await InfoProduct("napoje"));

        }

        private void koszykToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ofertySpecjalneToolStripMenuItem.BackColor = SystemColors.ActiveCaption;
            hamburgeryToolStripMenuItem.BackColor = SystemColors.ActiveCaption;
            dodatkiToolStripMenuItem.BackColor = SystemColors.ActiveCaption;
            napojeToolStripMenuItem.BackColor = SystemColors.ActiveCaption;
            koszykToolStripMenuItem.BackColor = Color.FromArgb(255, 128, 0);
            tableForProductsControl1.SetLabel("");
        }
    }
}