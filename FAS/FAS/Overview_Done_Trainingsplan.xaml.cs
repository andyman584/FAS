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
    public partial class Overview_Done_Trainingsplan : ContentPage
    {
        private Ausführung af;

        public Overview_Done_Trainingsplan(Ausführung af)
        {
            InitializeComponent();
            this.af = af;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var db = new SQLiteConnection(App.filePath);
            IEnumerable<Ausführung> foo = db.Query<Ausführung>("select * from Ausführung where execution_id = ?", af.execution_id);
            List<Ausführung> ausf = foo.ToList<Ausführung>();

            lv_Done.ItemsSource = ausf;

        }

        private void ToStartPage(object sender, EventArgs e)
        {
            App.Current.MainPage = new Strength_StartPage();
        }

    }
}
