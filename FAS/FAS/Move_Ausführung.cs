using SQLite;
using System;

namespace FAS
{
    public class Move_Ausführung
    {
        public Move_Ausführung()
        {
        }

        [PrimaryKey, AutoIncrement]
        public int counter_id { get; set; }
        public int move_id { get; set; }
        public DateTime start { get; set; }
    }
}