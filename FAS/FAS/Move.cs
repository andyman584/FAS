using SQLite;
using System;
using Xamarin.Forms;

namespace FAS
{
    internal class Move
    {
        public Move()
        {
        }

        [PrimaryKey, AutoIncrement]
        public int move_id { get; set; }
        public string name { get; set; }
    }
}