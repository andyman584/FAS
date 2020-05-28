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
    public partial class SE_Excercises : ContentPage
    {
        public SE_Excercises()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ReadExcercises();
        }

        private void SaveExce(object sender, EventArgs e)
        {
            Excercise exc = new Excercise()
            {
                name = exce.Text
            };

            using (SQLiteConnection conn = new SQLiteConnection(App.filePath))
            {
                conn.CreateTable<Excercise>();
                int RowsAdded = conn.Insert(exc);
            }
            exce.Text = "";
            ReadExcercises();
            
        }

        private void ReadExcercises()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.filePath))
            {
                conn.CreateTable<Excercise>();
                var exces = conn.Table<Excercise>().ToList();
                lv_Exercise_Overview.ItemsSource = exces;
            }
        }
        private void BacktoStart(object sender, EventArgs e)
        {
            App.Current.MainPage = new Strength_StartPage();
        }

        /*
        // ----------------------- TO DO -> Umstellung PK für Datenbanken --------------------
        private void DeleteSelected(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.filePath))
            {
                Excercise ex = (Excercise) lv_Exercise_Overview.SelectedItem;
                string sex = ex.name;

                conn.CreateTable<Excercise>();
                conn.Delete<Excercise>(sex);
            }

            ReadExcercises();
        }
        */
    }
}
