using Self_Ordering_Kiosk.db.Model;
using Self_Ordering_Kiosk.employee;
using Self_Ordering_Kiosk.user;

namespace Self_Ordering_Kiosk
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        /// user
        
        
        public void GoToSecondScreen()
        {
            panel1.Controls[0].Dispose();
            panel1.Controls.Add(new ChooseScreenOnSiteOrTakeAwayControl());
        }

        public async Task GoToThirdScreen() 
        {
            panel1.Controls[0].Dispose();
            var mainScreen = new MainScreenControl();
            await mainScreen.LoadData();
            panel1.Controls.Add(mainScreen);
        }

        public async Task GoToFirstScreen()
        {
            Cart.contentsOfCart.Clear();
            panel1.Controls[0].Dispose();
            panel1.Controls.Add(new WelcomeControl());
        }

        public void GoToFourthScreen()
        {
            panel1.Controls[0].Dispose();
            panel1.Controls.Add(new SummaryControl());
        }

        public void GoToPaymentProcessingScreen()
        {
            panel1.Controls[0].Dispose();
            panel1.Controls.Add(new PaymentProcessingControl());
        }

        public void GoToOrderPaidScreen()
        {
            panel1.Controls[0].Dispose();
            panel1.Controls.Add(new OrderPaidControl());
        }

        ///employee

        public void GoToLoggingScreen()
        {
            panel1.Controls[0].Dispose();
            panel1.Controls.Add(new Logging());
        }

        public async Task GoToMainScreenEmployee()
        {
            panel1.Controls[0].Dispose();
            var mainScreenEmployee = new MainScreenEmployee();
            await mainScreenEmployee.LoadData();
            panel1.Controls.Add(mainScreenEmployee);
        }

        public void GoToProductModification(Product product, bool isSpecjal)
        {
            panel1.Controls[0].Dispose();
            panel1.Controls.Add(new productModification(product, isSpecjal));
        }

        public void GoToProductAdding()
        {
            panel1.Controls[0].Dispose();
            panel1.Controls.Add(new ProductAdding());
        }

        public void GoToAddEmplyee()
        { 
            panel1.Controls[0].Dispose();
            panel1.Controls.Add(new AddEmployee());
        }

        public void GoToChangePassword()
        {
            panel1.Controls[0].Dispose();
            panel1.Controls.Add(new ChangePassword());
        }

        public void GoToDeleteEmplyee()
        {
            panel1.Controls[0].Dispose();
            panel1.Controls.Add(new DeleteEmployee());
        }

        public void GoToDeleteProducts()
        {
            panel1.Controls[0].Dispose();
            panel1.Controls.Add(new DeleteProducts());
        }
    }
}
