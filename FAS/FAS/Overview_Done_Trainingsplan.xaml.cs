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
    public partial class Overview_Done_Trainingsplan : ContentPage
    {
        private Excercise_Ausführung af;

        public Overview_Done_Trainingsplan(Excercise_Ausführung af)
        {
            InitializeComponent();
            this.af = af;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var db = new SQLiteConnection(App.filePath);
            IEnumerable<Excercise_Ausführung> foo = db.Query<Excercise_Ausführung>("select * from Excercise_Ausführung where execution_id = ?", af.execution_id);
            List<Excercise_Ausführung> ausf = foo.ToList<Excercise_Ausführung>();

            lv_Done.ItemsSource = ausf;

        }

        private void ToStartPage(object sender, EventArgs e)
        {
            App.Current.MainPage = new Strength_StartPage();
        }

    }
}
