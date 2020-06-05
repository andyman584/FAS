using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace FAS
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class Overview_Singe_Trainingsplan_Ausf : ContentPage
    {
        private Trainingsplan_Basic tpb;

        public Overview_Singe_Trainingsplan_Ausf(Trainingsplan_Basic tp)
        {
            InitializeComponent();
            this.tpb = tp;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
        private void GoGoStatistics(object sender, System.EventArgs e)
        {
            //App.Current.MainPage = new Overview_Singe_Trainingsplan_Ausf_Change(tpb);          
        }

        protected override bool OnBackButtonPressed()
        {
            App.Current.MainPage = new Overview_Singe_Trainingsplan_Ausf_Change(tpb);
            return true;
        }

    }
}
