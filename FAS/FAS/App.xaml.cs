using Xamarin.Forms;

namespace FAS
{
    public partial class App : Application
    {
        public static string filePath;

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Strength_StartPage());
        }

        public App(string completePath)
        {
            InitializeComponent();
            filePath = completePath;
            MainPage = new NavigationPage(new StartPage());
        }

        protected override void OnStart()
        {
            //To DO
            //Database 
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {

        }
    }
}
