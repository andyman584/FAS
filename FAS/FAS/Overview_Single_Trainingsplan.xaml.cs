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
    public partial class Overview_Single_Trainingsplan : ContentPage
    {
        private Trainingsplan_Basic tp;

        public Overview_Single_Trainingsplan(Trainingsplan_Basic tp)
        {
            InitializeComponent();
            this.tp = tp;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            List<String> exces = new List<string>() ;

            using (SQLiteConnection conn = new SQLiteConnection(App.filePath))
            {

                var db = new SQLiteConnection(App.filePath);
                IEnumerable<Trainingsplan> foo = db.Query<Trainingsplan>("select * from Trainingsplan where name = ?", tp.name);
                List<Trainingsplan> tpe = foo.ToList<Trainingsplan>();

                foreach (Trainingsplan element in tpe)
                {
                    db = new SQLiteConnection(App.filePath);
                    IEnumerable<Excercise> doo = db.Query<Excercise>("select name from Excercise where exc_id = ?", element.exce_id);
                    foreach (Excercise ex in doo)
                    {
                        exces.Add(ex.name);
                    }                    
                }

                lv_Overview.ItemsSource = exces;
            }
        }

        private void ToExcercises(object sender, EventArgs e)
        {
            App.Current.MainPage = new SE_Excercises();
        }

        private void ToTrainingsplan(object sender, EventArgs e)
        {
            App.Current.MainPage = new SE_Trainingsplan(tp);
        }

        private void ToStartPage(object sender, EventArgs e)
        {
            App.Current.MainPage = new Strength_StartPage();
        }
        private void ToMainPage(object sender, EventArgs e)
        {
            App.Current.MainPage = new MainPage(tp, 1);
        }
    }
}
