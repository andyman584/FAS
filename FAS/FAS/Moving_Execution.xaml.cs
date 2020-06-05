using Plugin.Geolocator;
using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace FAS
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class Moving_Execution : ContentPage
    {
        Move cur_move;

        public Moving_Execution(Move m)
        {
            InitializeComponent();
            cur_move = m;
            LMove.Text = cur_move.name;
        }

        private async void Start_Clicked(object sender, EventArgs e)
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;

            var position = await locator.GetPositionAsync();
            Start_Long.Text = position.Longitude.ToString();
            Start_Lat.Text = position.Latitude.ToString();
        }

        private void Stop_Clicked(object sender, EventArgs e)
        {

        }
    }
}

