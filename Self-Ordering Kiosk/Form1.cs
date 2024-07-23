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

        public async Task GoToThirdScreen()
        {
            panel1.Controls[0].Dispose();
            var mainScreen = new MainScreenControl();
            await mainScreen.LoadData();
            panel1.Controls.Add(mainScreen);
        }

        public async Task GoToFirstScreen()
        {
            panel1.Controls[0].Dispose();
            panel1.Controls.Add(new WelcomeControl());
        }
    }
}
