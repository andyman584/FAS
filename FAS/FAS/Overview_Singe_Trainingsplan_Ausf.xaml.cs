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
    public partial class Overview_Singe_Trainingsplan_Ausf : ContentPage
    {
        private Trainingsplan_Basic tp;

        public Overview_Singe_Trainingsplan_Ausf(Trainingsplan_Basic tp)
        {
            InitializeComponent();
            this.tp = tp;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            try { 
                var db = new SQLiteConnection(App.filePath);
                IEnumerable<Ausführung> foo = db.Query<Ausführung>("select * from Ausführung where trainingsplan_id = ?", tp.tp_id);
                List<Ausführung> ausf = foo.ToList<Ausführung>();

                lv_Done.ItemsSource = ausf;
            } catch { 

            }
        }

        private void ToStartPage(object sender, EventArgs e)
        {
            App.Current.MainPage = new Strength_StartPage();
        }

        private void GoGoStatistics(object sender, EventArgs e)
        {
            App.Current.MainPage = new Strength_StartPage();
        }
    }
}
