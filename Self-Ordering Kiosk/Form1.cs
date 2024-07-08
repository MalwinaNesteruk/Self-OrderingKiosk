namespace Self_Ordering_Kiosk
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void GoToSecondScreen()
        {
            panel1.Controls[0].Dispose();
            panel1.Controls.Add(new ChooseScreenOnSiteOrTakeAwayControl());
        }

        public void GoToThirdScreen()
        {
            panel1.Controls[0].Dispose();
            panel1.Controls.Add(new MainScreenControl());
        }
    }
}
