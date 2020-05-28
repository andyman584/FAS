using Akavache.Sqlite3;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SQLite;
using System.Linq.Expressions;

namespace FAS
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class SE_Trainingsplan : ContentPage
    {
        Trainingsplan_Basic cur_tp;
        public SE_Trainingsplan(Trainingsplan_Basic tp)
        {
            InitializeComponent();
            cur_tp = tp;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            readExercises();

            //Read the Exercises
            using (SQLiteConnection conn = new SQLiteConnection(App.filePath)) 
            {
                conn.CreateTable<Excercise>();
                var exces = conn.Table<Excercise>().ToList();
             
                foreach (Excercise element in exces)
                {
                    pExce.Items.Add(element.name);
                }
            }
        }

        void readExercises()
        {
            //Read the already chosen Exercises
            List<String> cur_exces = new List<string>();
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(App.filePath))
                {
                    var db = new SQLiteConnection(App.filePath);
                    IEnumerable<Trainingsplan> foo = db.Query<Trainingsplan>("select * from Trainingsplan where name = ?", cur_tp.name);
                    List<Trainingsplan> tpe = foo.ToList<Trainingsplan>();

                    foreach (Trainingsplan element in tpe)
                    {
                        db = new SQLiteConnection(App.filePath);
                        IEnumerable<Excercise> doo = db.Query<Excercise>("select name from Excercise where exc_id = ?", element.exce_id);
                        foreach (Excercise ex in doo)
                        {
                            cur_exces.Add(ex.name);
                        }
                    }
                    lv_Overview.ItemsSource = cur_exces;
                }
            }
            catch { }
        }

        void SaveTp(object sender, System.EventArgs e)
        {
            int eID = 0;
            var db = new SQLiteConnection(App.filePath);
            var exceName = pExce.SelectedItem.ToString();
            IEnumerable<Excercise> foo = db.Query<Excercise>("select * from Excercise where name = ?", exceName);
            List<Excercise> exces = foo.ToList<Excercise>();
            
            foreach (Excercise element in exces)
            {
                eID = element.exc_id;             
            }

            //Übung finden und Trainingsplan Element mit Übung erstellen
            Trainingsplan trainingsplan = new Trainingsplan()
            {
                name = cur_tp.name,
                exce_id = eID
            };

            //Insert the Trainingsplan
            using (SQLiteConnection conn = new SQLiteConnection(App.filePath))
            {
                conn.CreateTable<Trainingsplan>();
                int RowsAdded = conn.Insert(trainingsplan);
            }
            readExercises();
        }

        private void BackToStart(object sender, EventArgs e)
        {
            App.Current.MainPage = new Strength_StartPage();
        }
    }
}
