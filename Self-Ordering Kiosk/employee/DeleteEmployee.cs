using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Self_Ordering_Kiosk.db;
using Self_Ordering_Kiosk.db.Model;
using Self_Ordering_Kiosk.db.ModelEmployee;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Self_Ordering_Kiosk.employee
{
    public partial class DeleteEmployee : UserControl
    {
        List<int> employeeIds = new List<int>();
        List<Employee> employees = new List<Employee>();
        CheckBox checkBox = new CheckBox();
        public DeleteEmployee()
        {
            InitializeComponent();
            LoadDataIntoTable();
        }

        private void LoadDataIntoTable()
        {
            tableLayoutPanel1.RowCount = 0;
            tableLayoutPanel1.RowCount++;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50));

            Label labelName = new Label { Text = "Imię", Font = new Font("Arial", 16), AutoSize = true };
            Label labelSurname = new Label { Text = "Nazwisko", Font = new Font("Arial", 16), AutoSize = true };
            Label labelLogin = new Label { Text = "Login", Font = new Font("Arial", 16), AutoSize = true };

            tableLayoutPanel1.Controls.Add(labelName, 0, tableLayoutPanel1.RowCount - 1);
            tableLayoutPanel1.Controls.Add(labelSurname, 1, tableLayoutPanel1.RowCount - 1);
            tableLayoutPanel1.Controls.Add(labelLogin, 2, tableLayoutPanel1.RowCount - 1);

            using (KioskContext db = new KioskContext())
            {
                employees = db.Employees.ToList();
                employees.Remove(employees.Where(x => x.Login == Logging.login).FirstOrDefault());
                foreach (var employee in employees)
                {
                    tableLayoutPanel1.RowCount++;
                    tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50));

                    labelName = new Label { Text = employee.Name, Font = new Font("Arial", 16), AutoSize = true };
                    labelSurname = new Label { Text = employee.Surname, Font = new Font("Arial", 16), AutoSize = true };
                    labelLogin = new Label { Text = employee.Login, Font = new Font("Arial", 16), AutoSize = true };
                    checkBox = new CheckBox();
                    checkBox.CheckAlign = ContentAlignment.MiddleCenter;

                    tableLayoutPanel1.Controls.Add(labelName, 0, tableLayoutPanel1.RowCount - 1);
                    tableLayoutPanel1.Controls.Add(labelSurname, 1, tableLayoutPanel1.RowCount - 1);
                    tableLayoutPanel1.Controls.Add(labelLogin, 2, tableLayoutPanel1.RowCount - 1);
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

            foreach (var employee in employees)
            {
                Control control = tableLayoutPanel1.GetControlFromPosition(column, row);
                if (control is CheckBox checkBox)
                {
                    if (checkBox.Checked)
                    {
                        employeeIds.Add(employee.Id);
                    }
                }
                row++;
            }

            using (KioskContext db = new KioskContext())
            {
                var confirmResult = MessageBox.Show("Czy na pewno chcesz usunąć wybranych pracowników?",
                                    "Potwierdzenie",
                                    MessageBoxButtons.YesNo);
                switch (confirmResult)
                {
                    case DialogResult.Yes:
                        var employeeToRemove = db.Employees.Where(x => employeeIds.Contains(x.Id)).ToList();
                        db.Employees.RemoveRange(employeeToRemove);
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
