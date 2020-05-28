using Akavache.Sqlite3;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SQLite;

namespace FAS
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }


        private void ToStrenght(object sender, EventArgs e)
        {
            App.Current.MainPage = new Strength_StartPage();
        }

        private void ToMoving(object sender, EventArgs e)
        {
            App.Current.MainPage = new Moving_StartPage();
        }
    }
}
