using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;

namespace FAS
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class Moving_StartPage : ContentPage
    {
        public Moving_StartPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (SQLiteConnection conn = new SQLiteConnection(App.filePath))
            {

                try
                {
                    var db = new SQLiteConnection(App.filePath);
                    IEnumerable<Move> foo = db.Query<Move>("SELECT * from Move");
                    List<Move> moves = foo.ToList<Move>();
                    lv_Overview.ItemsSource = moves;
                }
                catch
                {

                }
            }
        }

        private void NewExercise(object sender, EventArgs e)
        {
            App.Current.MainPage = new New_Move();
        }

        private void ToMoveOrNotToMove(object sender, EventArgs e)
        {
            Move m = (Move)lv_Overview.SelectedItem;
            App.Current.MainPage = new Moving_Execution(m);
        }

        //TO DO
        private void ToAusfOverview(object sender, EventArgs e)
        {
        }

        protected override bool OnBackButtonPressed()
        {
            App.Current.MainPage = new StartPage();
            return true;
        }


        private void lv_Overview_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Do.IsEnabled = true;
            Check.IsEnabled = true;
        }
    }
}
