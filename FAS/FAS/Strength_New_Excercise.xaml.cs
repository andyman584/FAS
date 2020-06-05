using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

namespace FAS
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class Strength_New_Excercise : ContentPage
    {
        public Strength_New_Excercise()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ReadExcercises();

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

            foreach (String element in bpart_List)
            {
                bpart.Items.Add(element);
            }
        }

        private void SaveExce(object sender, EventArgs e)
        {
            Excercise exc = new Excercise()
            {
                name = exce.Text,
                cat = cat.Text,
                bpart = bpart.SelectedItem.ToString(),
                bodywheight = body.IsChecked
            };

            using (SQLiteConnection conn = new SQLiteConnection(App.filePath))
            {
                conn.CreateTable<Excercise>();
                int RowsAdded = conn.Insert(exc);
            }
            exce.Text = "";
            ReadExcercises();
        }

        private void ReadExcercises()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.filePath))
            {
                conn.CreateTable<Excercise>();
                var exces = conn.Table<Excercise>().ToList();
                lv_Exercise_Overview.ItemsSource = exces;
            }
        }
        private void BacktoStart(object sender, EventArgs e)
        {
            App.Current.MainPage = new Strength_StartPage();
        }

        protected override bool OnBackButtonPressed()
        {
            App.Current.MainPage = new Strength_StartPage();
            return true;
        }
    }
}
