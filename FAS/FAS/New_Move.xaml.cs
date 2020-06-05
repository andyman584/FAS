using SQLite;
using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace FAS
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class New_Move : ContentPage
    {
        public New_Move()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        void SaveMove(object sender, System.EventArgs e)
        {
            var db = new SQLiteConnection(App.filePath);
            var move_name = move.Text;

            Move m = new Move()
            {
                name = move_name
            };

            //Insert the Trainingsplan
            using (SQLiteConnection conn = new SQLiteConnection(App.filePath))
            {
                conn.CreateTable<Move>();
                int RowsAdded = conn.Insert(m);
            }

            App.Current.MainPage = new Moving_StartPage();
        }

        private void BackToStart(object sender, EventArgs e)
        {
            App.Current.MainPage = new Moving_StartPage();
        }
    }
}
