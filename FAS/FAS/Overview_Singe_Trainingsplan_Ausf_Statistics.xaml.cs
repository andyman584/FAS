using Microcharts;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Entry = Microcharts.Entry;

namespace FAS
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class Overview_Singe_Trainingsplan_Ausf_Statistics : ContentPage
    {
        private Trainingsplan_Basic tpb;

        public Overview_Singe_Trainingsplan_Ausf_Statistics(Trainingsplan_Basic tp)
        {
            InitializeComponent();
            this.tpb = tp;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            List<Entry> entries = new List<Entry> {
                new Entry(200)
                {
                     Label = "January",
                     ValueLabel = "200",
                },
                new Entry(400)
                {
                    Label = "February",
                    ValueLabel = "400",
                },
                new Entry(-100)
                {
                    Label = "March",
                    ValueLabel = "-100",
                }
            };

            balken.Chart = new BarChart() { Entries = entries };
        }

        protected override bool OnBackButtonPressed()
        {
            App.Current.MainPage = new Overview_Singe_Trainingsplan_Ausf_Change(tpb);
            return true;
        }

        private void GoGoStatistics(object sender, System.EventArgs e)
        {
            //App.Current.MainPage = new Overview_Singe_Trainingsplan_Ausf_Change(tpb);          
        }
    }
}
