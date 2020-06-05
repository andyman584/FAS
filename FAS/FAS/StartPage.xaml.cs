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
            CreateStandardExercises();
            App.Current.MainPage = new Strength_StartPage();
        }

        private void ToMoving(object sender, EventArgs e)
        {
            App.Current.MainPage = new Moving_StartPage();
        }

        private void CreateStandardExercises()
        {
            int exces_count = -1;
            using (SQLiteConnection conn = new SQLiteConnection(App.filePath))
            {
                try
                {
                    var db = new SQLiteConnection(App.filePath);
                    IEnumerable<Excercise> foo = db.Query<Excercise>("SELECT COUNT (exc_id) from Excercise");
                    List<Excercise> exces = foo.ToList<Excercise>();
                    exces_count = exces.Count();
                }
                catch
                { }

                if (exces_count < 0)
                {
                    conn.CreateTable<Excercise>();
                    Excercise exc = new Excercise()
                    {
                        name = "Bench Press",
                        cat = "Upper Body",
                        bpart = "Brust",
                        bodywheight = false
                    };
                    int RowsAdded = conn.Insert(exc);

                    exc = new Excercise()
                    {
                        name = "Low to High Crossover",
                        cat = "Upper Body",
                        bpart = "Brust",
                        bodywheight = false
                    };
                    RowsAdded = conn.Insert(exc);

                    exc = new Excercise()
                    {
                        name = "High to Low Crossover",
                        cat = "Upper Body",
                        bpart = "Brust",
                        bodywheight = false
                    };
                    RowsAdded = conn.Insert(exc);

                    exc = new Excercise()
                    {
                        name = "Straight Arm Pushdown",
                        cat = "Upper Body",
                        bpart = "Rücken",
                        bodywheight = false
                    };
                    RowsAdded = conn.Insert(exc);

                    exc = new Excercise()
                    {
                        name = "One Arm Cable Row",
                        cat = "Upper Body",
                        bpart = "Rücken",
                        bodywheight = false
                    };
                    RowsAdded = conn.Insert(exc);

                    exc = new Excercise()
                    {
                        name = "Face Pull",
                        cat = "Upper Body",
                        bpart = "Rücken",
                        bodywheight = false
                    };
                    RowsAdded = conn.Insert(exc);

                    exc = new Excercise()
                    {
                        name = "Deadlift",
                        cat = "Full Body",
                        bpart = "Compound",
                        bodywheight = false
                    };
                    RowsAdded = conn.Insert(exc);

                    exc = new Excercise()
                    {
                        name = "Chin Up",
                        cat = "Full Body",
                        bpart = "Compound",
                        bodywheight = false
                    };
                    RowsAdded = conn.Insert(exc);

                    exc = new Excercise()
                    {
                        name = "Bizeps Curl",
                        cat = "Upper Body",
                        bpart = "Bizeps",
                        bodywheight = false
                    };
                    RowsAdded = conn.Insert(exc);

                    exc = new Excercise()
                    {
                        name = "Kick Back",
                        cat = "Upper Body",
                        bpart = "Trizeps",
                        bodywheight = false
                    };
                    RowsAdded = conn.Insert(exc);

                    exc = new Excercise()
                    {
                        name = "Side Cable Pull",
                        cat = "Upper Body",
                        bpart = "Abs",
                        bodywheight = false
                    };
                    RowsAdded = conn.Insert(exc);

                    exc = new Excercise()
                    {
                        name = "Back Raise",
                        cat = "Upper Body",
                        bpart = "Rücken",
                        bodywheight = false
                    };
                    RowsAdded = conn.Insert(exc);
                }
            }
        }
    }
}
