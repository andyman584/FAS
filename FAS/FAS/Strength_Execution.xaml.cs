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
    public partial class Strength_Execution : ContentPage
    {
        //Get Exercise ID for Database
        int exce_id;
        //Current Exercise Number during Run
        int cur_exercise;
        //ID for creating the current run
        int cur_execution;
        Trainingsplan_Basic cur_tp;

        //Constructor for First Excercise
        public Strength_Execution(Trainingsplan_Basic tp, int excerciseNumber)
        {
            InitializeComponent();
            cur_exercise = excerciseNumber;
            cur_tp = tp;
            LTrainingsplan.Text = tp.name;
            LExcerciseNumber.Text = excerciseNumber.ToString();

            GetTrainingsplanData();
            //Get or Create Execution ID
            try
            {
                var db_execution = new SQLiteConnection(App.filePath);
                IEnumerable<Excercise_Ausführung> ausf = db_execution.Query<Excercise_Ausführung>("Select execution_id FROM Excercise_Ausführung");
                List<Excercise_Ausführung> af = ausf.ToList<Excercise_Ausführung>();

                foreach (Excercise_Ausführung element in af)
                {
                    cur_execution = element.execution_id;
                }
                cur_execution++;
            }
            catch
            {
                using (SQLiteConnection conn = new SQLiteConnection(App.filePath))
                {
                    conn.CreateTable<Excercise_Ausführung>();
                    cur_execution = 0;
                }
            }
        }
        public Strength_Execution(Trainingsplan_Basic tp, int excerciseNumber, int excecutionNumber)
        {
            InitializeComponent();
            cur_exercise = excerciseNumber;
            cur_tp = tp;
            LTrainingsplan.Text = tp.name;
            LExcerciseNumber.Text = excerciseNumber.ToString();
            GetTrainingsplanData();

            cur_execution = excecutionNumber;
        }

        private void Last_Excercise(object sender, EventArgs e)
        {
            Excercise_Ausführung a = new Excercise_Ausführung()
            {
                execution_id = cur_execution,
                trainingsplan_id = cur_tp.tp_id,
                excercise_id = exce_id,
                excercise_name = LExcercise.Text,
                sets = int.Parse(Esets.Text),
                reps = int.Parse(Ereps.Text),
                wheight = int.Parse(Ewheight.Text),
                start = DateTime.Now.Date
            };

            using (SQLiteConnection conn = new SQLiteConnection(App.filePath))
            {
                conn.CreateTable<Excercise_Ausführung>();
                int RowsAdded = conn.Insert(a);
            }

            App.Current.MainPage = new Overview_Done_Trainingsplan(a);
        }

        private void Next_Excercise(object sender, EventArgs e)
        {
            Excercise_Ausführung a = new Excercise_Ausführung()
            {
                execution_id = cur_execution,
                trainingsplan_id = cur_tp.tp_id,
                excercise_id = exce_id,
                excercise_name = LExcercise.Text,
                sets = int.Parse(Esets.Text),
                reps = int.Parse(Ereps.Text),
                wheight = int.Parse(Ewheight.Text),
                start = DateTime.Now.Date
            };

            using (SQLiteConnection conn = new SQLiteConnection(App.filePath))
            {
                conn.CreateTable<Excercise_Ausführung>();
                int RowsAdded = conn.Insert(a);
            }

            cur_exercise++;
            App.Current.MainPage = new Strength_Execution(cur_tp, cur_exercise, cur_execution);
        }

        protected override bool OnBackButtonPressed()
        {
            App.Current.MainPage = new Strength_StartPage();
            return true;
        }

        private void GetTrainingsplanData()
        {
            //Get the Trainingsplan Data
            var db = new SQLiteConnection(App.filePath);
            IEnumerable<Trainingsplan> foo = db.Query<Trainingsplan>("select exce_id from Trainingsplan where name = ?", cur_tp.name);
            List<Trainingsplan> tpe = foo.ToList<Trainingsplan>();

            //Count Exercises and check if current exercise is last
            if (cur_exercise == tpe.Count)
            {
                Next.IsVisible = false;
                Last.IsVisible = true;
            }

            int i = 1;
            //Get the Excercise
            foreach (Trainingsplan element in tpe)
            {
                //Check if correct exercise is selected
                if (i == cur_exercise)
                {
                    db = new SQLiteConnection(App.filePath);
                    IEnumerable<Excercise> doo = db.Query<Excercise>("select name from Excercise where exc_id = ?", element.exce_id);
                    List<Excercise> exces = doo.ToList<Excercise>();
                    foreach (Excercise excercise in exces)
                    {
                        exce_id = excercise.exc_id;
                        LExcercise.Text = excercise.name;
                    }
                    i++;

                }
                else
                {
                    i++;
                }
            }
        }
    }
}

