using SQLite;
using System;
using Xamarin.Forms;

namespace FAS
{
    internal class Excercise
    {
        public Excercise()
        {
        }

        [PrimaryKey, AutoIncrement]
        public int exc_id { get; set; }
        public string name { get; set; }

        /*
        public string cat { get; set; }
        public string bpart { get; set; }
        public Boolean bodywheight { get; set; }
        */
    }
}