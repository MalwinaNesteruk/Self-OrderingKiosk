using Self_Ordering_Kiosk.db.ModelEmployee;
using Self_Ordering_Kiosk.db;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Self_Ordering_Kiosk.db.Model;

namespace Self_Ordering_Kiosk.employee
{
    public partial class DeleteProducts : UserControl
    {
        List<int> productIds = new List<int>();
        List<Product> products = new List<Product>();
        List<Category> categories = new List<Category>();
        CheckBox checkBox = new CheckBox();
        public DeleteProducts()
        {
            InitializeComponent();
            LoadDataIntoTable();
        }

        private void LoadDataIntoTable()
        {
            tableLayoutPanel1.RowCount = 0;
            tableLayoutPanel1.RowCount++;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50));

            Label labelName = new Label { Text = "Nazwa", Font = new Font("Arial", 16), AutoSize = true };
            Label labelPrice = new Label { Text = "Cena", Font = new Font("Arial", 16), AutoSize = true };
            Label labelCategory = new Label { Text = "Kategoria", Font = new Font("Arial", 16), AutoSize = true };

            tableLayoutPanel1.Controls.Add(labelName, 0, tableLayoutPanel1.RowCount - 1);
            tableLayoutPanel1.Controls.Add(labelPrice, 1, tableLayoutPanel1.RowCount - 1);
            tableLayoutPanel1.Controls.Add(labelCategory, 2, tableLayoutPanel1.RowCount - 1);

            using (KioskContext db = new KioskContext())
            {
                products = db.Products.OrderBy(x => x.Category.Id).ToList();
                categories = db.Categories.ToList();
                foreach (var product in products)
                {
                    tableLayoutPanel1.RowCount++;
                    tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50));

                    labelName = new Label { Text = product.Name, Font = new Font("Arial", 16), AutoSize = true };
                    labelPrice = new Label { Text = product.Price.ToString(), Font = new Font("Arial", 16), AutoSize = true };
                    labelCategory = new Label { Text = categories.Where(x => x.Id == product.Category.Id).Select(x => x.Name).FirstOrDefault(), Font = new Font("Arial", 16), AutoSize = true };
                    checkBox = new CheckBox();
                    checkBox.CheckAlign = ContentAlignment.MiddleCenter;

                    tableLayoutPanel1.Controls.Add(labelName, 0, tableLayoutPanel1.RowCount - 1);
                    tableLayoutPanel1.Controls.Add(labelPrice, 1, tableLayoutPanel1.RowCount - 1);
                    tableLayoutPanel1.Controls.Add(labelCategory, 2, tableLayoutPanel1.RowCount - 1);
                    tableLayoutPanel1.Controls.Add(checkBox, 3, tableLayoutPanel1.RowCount - 1);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Czy na pewno chcesz wyjść?",
            "Potwierdzenie",
            MessageBoxButtons.YesNo);
            switch (confirmResult)
            {
                case DialogResult.Yes:
                    var form = (Form1)this.Parent.Parent;
                    form.GoToMainScreenEmployee();
                    break;

                case DialogResult.No:
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int column = 3;
            int row = 1;

            foreach (var product in products)
            {
                Control control = tableLayoutPanel1.GetControlFromPosition(column, row);
                if (control is CheckBox checkBox)
                {
                    if (checkBox.Checked)
                    {
                        productIds.Add(product.Id);
                    }
                }
                row++;
            }

            using (KioskContext db = new KioskContext())
            {
                var confirmResult = MessageBox.Show("Czy na pewno chcesz usunąć wybrane produkty?",
                                    "Potwierdzenie",
                                    MessageBoxButtons.YesNo);
                switch (confirmResult)
                {
                    case DialogResult.Yes:

                        var specialProductToRemove = db.SpecialOffers.Where(x => productIds.Contains(x.Product.Id)).ToList();
                        if (specialProductToRemove != null)
                        {
                            db.SpecialOffers.RemoveRange(specialProductToRemove);
                        }
                        var productsToRemove = db.Products.Where(x => productIds.Contains(x.Id)).ToList();
                        db.Products.RemoveRange(productsToRemove);
                        db.SaveChanges();
                        var form = (Form1)this.Parent.Parent;
                        form.GoToMainScreenEmployee();
                        break;
                    case DialogResult.No:
                        break;
                }
            }
        }
    }
}
