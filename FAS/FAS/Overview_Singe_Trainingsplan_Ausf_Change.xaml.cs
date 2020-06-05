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
    public partial class Overview_Singe_Trainingsplan_Ausf_Change : ContentPage
    {
        private Trainingsplan_Basic tpb;

        public Overview_Singe_Trainingsplan_Ausf_Change(Trainingsplan_Basic tp)
        {
            InitializeComponent();
            this.tpb = tp;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                //List of Body Parts?
                List<String> bpart_List = new List<string>();
                bpart_List.Add("Bizeps");
                bpart_List.Add("Trizeps");
                bpart_List.Add("Brust");
                bpart_List.Add("Rücken");
                bpart_List.Add("Schultern");
                bpart_List.Add("Glutes");
                bpart_List.Add("Beine");
                bpart_List.Add("Abs");
                bpart_List.Add("Compound");
                bpart_List.Add("Cardio");
                ltp.Text = "Trainingsplan " + tpb.name;

                var db = new SQLiteConnection(App.filePath);
                //Join ToDo
                IEnumerable<Excercise_Ausführung> foo = db.Query<Excercise_Ausführung>("select * from Excercise_Ausführung where trainingsplan_id = ? ORDER BY excercise_name", tpb.tp_id);
                List<Excercise_Ausführung> ausf = foo.ToList<Excercise_Ausführung>();

                //Group and Sum up the Excercises
                Excercise_Ausführung last = new Excercise_Ausführung();
                string name = "";

                //Changes
                int c_sets = 0;
                int c_reps = 0;
                int c_wheight = 0;

                //Counter
                int cnt = 1;
                int ausfcnt = 1;
                List<Strength_Statistic_Change> list_summen = new List<Strength_Statistic_Change>();

                foreach (Excercise_Ausführung element in ausf)
                {
                    //First Element
                    if (last.excercise_name == null)
                    {
                        name = element.excercise_name;
                        c_sets = 0;
                        c_reps = 0;
                        c_wheight = 0;

                        Strength_Statistic_Change s = new Strength_Statistic_Change();
                        s.sets = element.sets.ToString() + " (" + c_sets + ")";
                        s.reps = element.reps.ToString() + " (" + c_reps + ")";
                        s.wheight = element.wheight.ToString() + " (" + c_wheight + ")";
                        s.name = name;
                        list_summen.Add(s);
                    }

                    //Nexte Group - Change
                    else if (cnt == ausf.Count() || !element.excercise_name.Equals(last.excercise_name))
                    {
                        lcnt.Text = "Ausführungen " + ausfcnt.ToString();
                        ausfcnt = 1;

                        //Define
                        name = element.excercise_name;
                        c_sets = 0;
                        c_reps = 0;
                        c_wheight = 0;

                        Strength_Statistic_Change s = new Strength_Statistic_Change();
                        s.sets = element.sets.ToString() + " (" + c_sets + ")";
                        s.reps = element.reps.ToString() + " (" + c_reps + ")";
                        s.wheight = element.wheight.ToString() + " (" + c_wheight + ")";
                        s.name = name;
                        list_summen.Add(s);

                        //Element of Exercisegroup - Change 
                    }
                    else if (element.excercise_name.Equals(last.excercise_name))
                    {
                        //Change Data
                        name = element.excercise_name;
                        c_sets = element.sets - last.sets;
                        c_reps = element.reps - last.reps;
                        c_wheight = element.wheight - last.wheight;

                        Strength_Statistic_Change s = new Strength_Statistic_Change();

                        //Positive or Negativ Change
                        if (c_sets > 0)
                        {
                            s.sets = element.sets.ToString() + " (+" + c_sets + ")";
                        }
                        else
                        {
                            s.sets = element.sets.ToString() + " (" + c_sets + ")";
                        }

                        if (c_reps > 0)
                        {
                            s.reps = element.reps.ToString() + " (+" + c_reps + ")";
                        }
                        else
                        {
                            s.reps = element.reps.ToString() + " (" + c_reps + ")";
                        }

                        if (c_wheight > 0)
                        {
                            s.wheight = element.wheight.ToString() + " (+" + c_wheight + ")";
                        }
                        else
                        {
                            s.wheight = element.wheight.ToString() + " (" + c_wheight + ")";
                        }

                        s.name = name;
                        list_summen.Add(s);

                    }
                    //Counter
                    ausfcnt++;
                    cnt++;
                    last = element;
                }

                lv_Done.ItemsSource = list_summen;
            }
            catch
            {

            }
        }

        private void ToStartPage(object sender, EventArgs e)
        {
            App.Current.MainPage = new Strength_StartPage();
        }

        private void GoGoStatistics(object sender, EventArgs e)
        {
            //App.Current.MainPage = new Overview_Singe_Trainingsplan_Ausf_Statistic(tpb);
        }

        protected override bool OnBackButtonPressed()
        {
            App.Current.MainPage = new Strength_StartPage();
            return true;
        }
    }
}
