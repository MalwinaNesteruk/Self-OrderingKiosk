using Microsoft.EntityFrameworkCore;
using Self_Ordering_Kiosk.db;
using Self_Ordering_Kiosk.db.Model;
using Self_Ordering_Kiosk.Properties;
using Self_Ordering_Kiosk.user;
using System.Data;
using System.Linq;

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
                if(!Cart.contentsOfCart.ContainsKey(product))
                {
                    ProductControl productControl = new ProductControl(product);
                    products.Add(productControl);
                }
                else
                {
                    ProductControl productControl = new ProductControl(product, Cart.contentsOfCart[product]);
                    products.Add(productControl);
                    valueOfCounter += Cart.contentsOfCart[product];
                    valueOfBasket += Cart.contentsOfCart[product] * product.Price;
                    koszykToolStripMenuItem.Text = "(" + valueOfCounter.ToString() + ")      " + valueOfBasket.ToString();
                }

                
            }
            AbilityToClickOnCart();
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
            List<int> idFromDictionary = new List<int>();
            foreach (var product in Cart.contentsOfCart.Keys)
            {
                idFromDictionary.Add(product.Id);
            }

            for (int i = 0; i < idFromDictionary.Count; i++)
            {
                if (idList.Contains(idFromDictionary[i]))
                {
                    idList.Remove(idFromDictionary[i]);
                }
            }

            Random rnd = new Random(); 
            if (idList.Count == 0)
            {
                int rand = products.Select(x => x.productId).OrderBy(x => rnd.Next()).FirstOrDefault();
                return products.Where(p => p.productId == rand).Select(x => new OneProposalControl(x.productName, x.productPrice, x.product)).ToList();
            }

            var drawId = idList.OrderBy(x => rnd.Next()).Take(idList.Count > 8 ? 8 : idList.Count).ToList();
            var proposalProductList = products.Where(p => drawId.Contains(p.productId)).Select(x => new OneProposalControl(x.productName, x.productPrice, x.product)).ToList();
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
            AbilityToClickOnCart();
            valueOfBasket = Cart.contentsOfCart.Select(a => a.Key.Price * a.Value).Sum();
            valueOfCounter = Cart.contentsOfCart.Values.Sum();
            koszykToolStripMenuItem.Text = "(" + valueOfCounter.ToString() + ")      " + valueOfBasket.ToString();
        }

        public void AbilityToClickOnCart()
        {
            if (Cart.contentsOfCart.Count > 0)
            {
                koszykToolStripMenuItem.Enabled = true;
            }
            else
            {
                koszykToolStripMenuItem.Enabled = false;
            }
        }
    }
}