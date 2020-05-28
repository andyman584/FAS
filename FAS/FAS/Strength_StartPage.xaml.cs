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
    public partial class Strength_StartPage : ContentPage
    {
        public Strength_StartPage()
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
                    IEnumerable<Trainingsplan_Basic> foo = db.Query<Trainingsplan_Basic>("SELECT * from Trainingsplan_Basic");
                    List<Trainingsplan_Basic> trainingsplans = foo.ToList<Trainingsplan_Basic>();
                    lv_Overview.ItemsSource = trainingsplans;
                } catch {

                } 
            }
        }

        private void ToExcercises(object sender, EventArgs e)
        {
            App.Current.MainPage = new SE_Excercises();
        }

        private void ToTrainingsplan(object sender, EventArgs e)
        {
            Trainingsplan_Basic tp = (Trainingsplan_Basic)lv_Overview.SelectedItem;
            App.Current.MainPage = new SE_Trainingsplan(tp);
        }

        private void ToOverview(object sender, EventArgs e)
        {
            Trainingsplan_Basic tp = (Trainingsplan_Basic) lv_Overview.SelectedItem;
            App.Current.MainPage = new Overview_Single_Trainingsplan(tp);
        }

        private void ToAusfOverview(object sender, EventArgs e)
        {
            Trainingsplan_Basic tp = (Trainingsplan_Basic) lv_Overview.SelectedItem;
            App.Current.MainPage = new Overview_Singe_Trainingsplan_Ausf(tp);
        }

        private void lv_Overview_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Do.IsEnabled = true;
            Check.IsEnabled = true;
            AddExceToTP.IsEnabled = true;
        }

        private void NewTrainingsplan(object sender, EventArgs e)
        {
            App.Current.MainPage = new New_Trainingsplan();
        }
    }
}
