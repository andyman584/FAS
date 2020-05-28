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
    public partial class New_Trainingsplan : ContentPage
    {
        public New_Trainingsplan()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();        
        }

        void SaveTp(object sender, System.EventArgs e)
        {
            var db = new SQLiteConnection(App.filePath);
            var tpname = tp.Text;

            Trainingsplan_Basic tp_basic = new Trainingsplan_Basic()
            {
                name = tpname
            };

            //Insert the Trainingsplan
            using (SQLiteConnection conn = new SQLiteConnection(App.filePath))
            {
                conn.CreateTable<Trainingsplan_Basic>();
                int RowsAdded = conn.Insert(tp_basic);
            }

            App.Current.MainPage = new Strength_StartPage();
        }

        private void BackToStart(object sender, EventArgs e)
        {
            App.Current.MainPage = new Strength_StartPage();
        }
    }
}
