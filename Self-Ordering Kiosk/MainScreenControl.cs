using Microsoft.EntityFrameworkCore;
using Self_Ordering_Kiosk.db;
using Self_Ordering_Kiosk.db.Model;
using Self_Ordering_Kiosk.Properties;
using System.Data;

namespace Self_Ordering_Kiosk
{
    public partial class MainScreenControl : UserControl
    {
        decimal valueOfBasket = 0;
        int valueOfCounter = 0;
        List<ProductControl> products = new List<ProductControl>();

        public MainScreenControl()
        {
            InitializeComponent();
        }

        public async Task LoadData()
        {
            using KioskContext db = new KioskContext();
            var productsFromDb = await db.Products.Include(a => a.Category).ToListAsync();
            foreach (var product in productsFromDb)
            {
                ProductControl productControl = new ProductControl();
                productControl.SetProduct(product);
                products.Add(productControl);
            }

            tableForProductsControl1.SetOneProduct(await InfoSpecialProduct());
        }

        public void SetValueOfBasket()
        {
            valueOfBasket += 1;
        }

        public async Task<List<ProductControl>> InfoProduct(string categoryName)
        {
            tableForProductsControl1.Clear();
            return products.Where(p => p.category.Equals(categoryName)).ToList();
        }

        public List<OneProposalControl> ProposalProduct()
        {
            var idList = products.Select(x => x.productId).ToList();
            Random rnd = new Random();
            var drawId = idList.OrderBy(x => rnd.Next()).Take(8).ToList();
            var proposalProductList = products.Where(p => drawId.Contains(p.productId)).Select(x => new OneProposalControl(x.productName, x.productPrice)).ToList();
            return proposalProductList;
        }

        public async Task<List<ProductControl>> InfoSpecialProduct()
        {
            using KioskContext db = new KioskContext();
            tableForProductsControl1.Clear();
            var allProductsInCategory = await db.SpecialOffers.Include(a => a.Product).ToListAsync();
            var allSpecialProductsId = allProductsInCategory.Select(p => p.Product.Id).ToList();
            return products.Where(p => allSpecialProductsId.Contains(p.productId)).ToList();
        }

        private async void ofertySpecjalneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            proposalControl1.Visible = false;
            tableForProductsControl1.Visible = true;
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
            proposalControl1.Visible = false;
            tableForProductsControl1.Visible = true;
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
            proposalControl1.Visible = false;
            tableForProductsControl1.Visible = true;
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
            proposalControl1.Visible = false;
            tableForProductsControl1.Visible = true;
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
            tableForProductsControl1.Visible = false;
            proposalControl1.Visible = true;
            ofertySpecjalneToolStripMenuItem.BackColor = SystemColors.ActiveCaption;
            hamburgeryToolStripMenuItem.BackColor = SystemColors.ActiveCaption;
            dodatkiToolStripMenuItem.BackColor = SystemColors.ActiveCaption;
            napojeToolStripMenuItem.BackColor = SystemColors.ActiveCaption;
            koszykToolStripMenuItem.BackColor = Color.FromArgb(255, 128, 0);
            proposalControl1.SetOneProduct(ProposalProduct());
        }

        public void UpdateCartEvent()
        {
            valueOfBasket = products.Sum(p => p.productsPrice);
            valueOfCounter = products.Sum(p => p.counter);
            koszykToolStripMenuItem.Text = "(" + valueOfCounter.ToString() + ")      " + valueOfBasket.ToString();
        }
    }
}